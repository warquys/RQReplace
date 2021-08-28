# RQReplace
 Replace those Raqequitters!

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

## Features 
* Replace players with an active role who leave the game 
* Configure what aspects the replacer will have
* SCPs will not cause a C.A.S.S.I.E Announcement when they leave and are replaced
* Decide which roles will be replaced

## Showcase

![Some Information](/assets/info.png)

## Supported Languages 
* English
* German
* French (By `nath256#8390`)
* Polish (By `Doktor#7356`)

## How to add new Languages
You have to either dm me on Discord, then I can explain it to you or you just create a pull request. (My Discord Account: `TheVoidNebula#5090`)

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the RQReplace.dll file that you can download [here](https://github.com/TheVoidNebula/RQReplace/releases) in your plugin directory
3. Restart/Start your server.

## Role IDs

<details>
<summary>SCPs</summary>

| Name | ID |
| --- | --- |
| SCP-049 | 5 |
| SCP-049-2 | 10 |
| SCP-079 | 7 |
| SCP-096 | 9 |
| SCP-106 | 3 |
| SCP-173 | 0 |
| SCP-939-53 | 16 |
| SCP-939-89 | 17 |
 
</details>

<details>
<summary>MTF</summary>

| Name | ID |
| --- | --- |
| Guard | 15 |
| Private | 13 |
| Sergeant | 11 |
| Captain | 12 |
| Specialist | 4 |
 
</details>

<details>
<summary>Chaos Insurgency</summary>

| Name | ID |
| --- | --- |
| Conscript | 8 |
| Rifleman | 18 |
| Repressor | 19 |
| Marauder | 20 |
 
</details>

<details>
<summary>Other</summary>

| Name | ID |
| --- | --- |
| Spectator | 2 |
| Tutorial | 14 |
| Class-D | 1 |
| Scientist | 6 |
 
</details>

## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`IsEnabled` | Boolean | true | Is this plugin enabled?
`AllowAmmoTransfer` | Boolean | true | Should ammo be transferred?
`UseScale` | Boolean | true | Should the size be transferred?
`UseMaxHealth` | Boolean | true | Should the max Health be transferred?
`UseHealth` | Boolean | true | Should Health be transferred?
`UseAHP` | Boolean | true | Should AHP be transferred?
`UseStamina` | Boolean | true | Should stamina be transferred?
`UseInventory` | Boolean | true | Should the Inventory be transferred?
`ReplaceRoles` | List | 5, 7, 9, 3, 0, 16, 17 | Which Roles should be replaced? (Use the RoleIDs, for more information see the Synapse RoleIDs)
