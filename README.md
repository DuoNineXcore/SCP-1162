# SCP-1162

Turn Both SCP-173's Containment Chambers into SCP-1162. If you drop an item inside the chamber/room of SCP-173 you will get another one.

# Config
```
# Is the plugin enabled?
  is_enabled: true
  # Should debug messages be displayed?
  debug: false
  # Use Hints instead of Broadcast?
  use_hints: true
  # If enabled, it will use SCP-173's New containment chamber located in HCZ, instead of LCZ's 173 Containment Chamber.
  use_new173_spawn: false
  # Determines if SCP-1162 has a chance to punish players for extended use.
  s_c_p1162_hurts: true
  # The maximum number of times a player can be hurt by SCP-1162 before dying.
  hurt_limit: 5
  # Determines if the chances of getting hurt increase exponentially with each use of SCP-1162.
  exponential_hurt_chances: false
  # The base chance (in percentage) for a player to get hurt while using SCP-1162.
  hurt_chance: 50
  # The message displayed to the player when they're hurt by SCP-1162
  hurt_message: '<b><size=20><color=red>[SCP-1162]</color> You feel a sharp excruciating pain trying to use SCP-1162.</size></b>'
  # Change the message that displays when you drop an item through SCP-1162.
  item_drop_message: '<b><size=20><color=green>[SCP-1162]</color> You try to drop the item to get another.</size></b>'
  # The Duration of the messages displayed by SCP-1162.
  message_duration: 5
  # The list of item chances.
  chances:
  - KeycardO5
  - SCP500
  - MicroHID
  - KeycardNTFCommander
  - KeycardContainmentEngineer
  - SCP268
  - GunCOM15
  - SCP207
  - Adrenaline
  - GunCOM18
  - KeycardFacilityManager
  - Medkit
  - KeycardNTFLieutenant
  - KeycardGuard
  - GrenadeHE
  - KeycardZoneManager
  - KeycardGuard
  - Radio
  - Ammo9x19
  - Ammo12gauge
  - Ammo44cal
  - Ammo556x45
  - Ammo762x39
  - GrenadeFlash
  - KeycardScientist
  - KeycardJanitor
  - Coin
  - Flashlight
```

# Installation

**[EXILED 6.0.0](https://github.com/galaxy119/EXILED) must be installed for this to work.**

Place the "SCP1162.dll" file in your Plugins folder.
Windows: ``%appdata%/EXILED/Plugins``.
Linux: ``.config/EXILED/Plugins``.

![alt text](https://i5.walmartimages.com/seo/Fresh-Cantaloupe-Each_fb4c18a5-9367-4770-b99f-7518c72db482.5609c32e87a3110b734aad048bf9fe35.jpeg)
