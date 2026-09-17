"""Local role-aware authentication for the barcode viewer.

The application intentionally keeps authentication local so that the same
source can run on a production PC without requiring a network service. User
passwords are stored as salted SHA-256 hashes. Existing ``users.json`` files
that do not contain a role are treated as operator accounts for backwards
compatibility.
"""

from __future__ import annotations

import hashlib
import json
import secrets
import sys
from dataclasses import dataclass
from pathlib import Path
from typing import Optional


def _app_dir() -> Path:
    """Return the directory where the local ``users.json`` lives."""
    if getattr(sys, "frozen", False):
        return Path(sys.executable).resolve().parent
    return Path(__file__).resolve().parent


USERS_FILE = _app_dir() / "users.json"


@dataclass(frozen=True)
class User:
    """An authenticated application user.

    ``can_manual_entry`` remains the second field to keep old callers that
    construct ``User(login_id, True)`` compatible. ``role`` is either
    ``"operator"`` or ``"admin"``.
    """

    login_id: str
    can_manual_entry: bool = True
    role: str = "operator"

    @property
    def is_admin(self) -> bool:
        return self.role.lower() == "admin"

    @property
    def is_operator(self) -> bool:
        return not self.is_admin


def _hash_password(salt: bytes, password: str) -> str:
    return hashlib.sha256(salt + password.encode("utf-8")).hexdigest()


def _load_users() -> list[dict]:
    if not USERS_FILE.exists():
        return []
    try:
        data = json.loads(USERS_FILE.read_text(encoding="utf-8"))
        users = data.get("users", [])
        return users if isinstance(users, list) else []
    except (json.JSONDecodeError, OSError, AttributeError):
        return []


def _save_users(users: list[dict]) -> None:
    try:
        USERS_FILE.parent.mkdir(parents=True, exist_ok=True)
        temp_path = USERS_FILE.with_suffix(".json.tmp")
        temp_path.write_text(
            json.dumps({"users": users}, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )
        temp_path.replace(USERS_FILE)
    except OSError:
        # Authentication callers should receive a normal failed-login result,
        # not a GUI crash, if the installation directory is read-only.
        pass


def _normalise_role(role: str | None) -> str:
    return "admin" if str(role or "").lower() == "admin" else "operator"


def _public_user(raw: dict) -> Optional[User]:
    login_id = str(raw.get("login_id", "")).strip()
    if not login_id:
        return None
    return User(
        login_id=login_id,
        can_manual_entry=bool(raw.get("can_manual_entry", True)),
        role=_normalise_role(raw.get("role")),
    )


def list_users() -> list[User]:
    """Return the users without exposing password hashes."""
    result: list[User] = []
    for raw in _load_users():
        if isinstance(raw, dict):
            user = _public_user(raw)
            if user is not None:
                result.append(user)
    return result


def ensure_default_users_file() -> None:
    """Ensure usable operator and admin demo accounts exist.

    The original source shipped with only ``A12345``. That account remains
    unchanged. If a legacy file has no administrator, a demo ``admin`` account
    is added so the role-aware UI is usable immediately; customers should
    replace its password in the user-management screen before deployment.
    """
    users = _load_users()
    if not users:
        add_user("A12345", "password", can_manual_entry=True, role="operator")
        add_user("admin", "admin", can_manual_entry=True, role="admin")
        return

    if not any(_normalise_role(u.get("role")) == "admin" for u in users if isinstance(u, dict)):
        add_user("admin", "admin", can_manual_entry=True, role="admin")


def add_user(
    login_id: str,
    password: str,
    can_manual_entry: bool = True,
    role: str = "operator",
) -> bool:
    """Add or replace a user and return whether the record was written."""
    login_id = str(login_id or "").strip()
    if not login_id or not password:
        return False
    role = _normalise_role(role)
    users = [u for u in _load_users() if u.get("login_id") != login_id]
    salt = secrets.token_bytes(16)
    users.append(
        {
            "login_id": login_id,
            "salt_hex": salt.hex(),
            "password_hash_hex": _hash_password(salt, password),
            "can_manual_entry": bool(can_manual_entry),
            "role": role,
        }
    )
    _save_users(users)
    return any(u.get("login_id") == login_id for u in _load_users())


def remove_user(login_id: str) -> bool:
    """Remove a user, returning ``True`` when a record was removed."""
    login_id = str(login_id or "").strip()
    users = _load_users()
    filtered = [u for u in users if u.get("login_id") != login_id]
    if len(filtered) == len(users):
        return False
    _save_users(filtered)
    return True


def authenticate(login_id: str, password: str) -> Optional[User]:
    """Authenticate any valid operator or administrator account."""
    login_id = str(login_id or "").strip()
    if not login_id or not password:
        return None

    for raw in _load_users():
        if not isinstance(raw, dict) or str(raw.get("login_id", "")).strip() != login_id:
            continue
        try:
            salt = bytes.fromhex(str(raw.get("salt_hex", "")))
            stored_hash = str(raw.get("password_hash_hex", ""))
        except (ValueError, TypeError):
            return None
        if stored_hash and secrets.compare_digest(_hash_password(salt, password), stored_hash):
            return _public_user(raw)
        return None
    return None
