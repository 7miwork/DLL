#!/usr/bin/env python3
"""Compare i18n keys across all three languages."""

import sys

from pathlib import Path

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

import i18n

# Get the three language dictionaries
en_keys = set(i18n.TRANSLATIONS["en"].keys())
de_keys = set(i18n.TRANSLATIONS["de"].keys())
zh_keys = set(i18n.TRANSLATIONS["zh_Hant"].keys())

all_keys = en_keys | de_keys | zh_keys

print(f"English keys:     {len(en_keys)}")
print(f"German keys:      {len(de_keys)}")
print(f"Chinese keys:     {len(zh_keys)}")
print(f"Union (all keys): {len(all_keys)}")
print()

# Missing in each language
missing_in_en = all_keys - en_keys
missing_in_de = all_keys - de_keys
missing_in_zh = all_keys - zh_keys

print("=== Keys MISSING in English ===")
for k in sorted(missing_in_en):
    print(f"  {k}")

print("\n=== Keys MISSING in German ===")
for k in sorted(missing_in_de):
    print(f"  {k}")

print("\n=== Keys MISSING in Chinese ===")
for k in sorted(missing_in_zh):
    print(f"  {k}")

print("\n=== Summary ===")
if not missing_in_en and not missing_in_de and not missing_in_zh:
    print("✓ All three languages have identical key sets!")
else:
    print("✗ Inconsistencies found:")
    print(f"  English missing:    {len(missing_in_en)} keys")
    print(f"  German missing:     {len(missing_in_de)} keys")
    print(f"  Chinese missing:    {len(missing_in_zh)} keys")