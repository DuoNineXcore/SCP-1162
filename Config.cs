using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP1162
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should debug messages be displayed?")]
        public bool Debug { get; set; } = false;

        [Description("Use Hints instead of Broadcast?")]
        public bool UseHints { get; set; } = true;

        [Description("If enabled, it will use SCP-173's New containment chamber located in HCZ, instead of LCZ's 173 Containment Chamber.")]
        public bool UseNew173Spawn { get; set; }

        [Description("Determines if SCP-1162 has a chance to punish players for extended use.")]
        public bool SCP1162Hurts { get; set; }

        [Description("The maximum number of times a player can be hurt by SCP-1162 before dying.")]
        public int HurtLimit { get; set; } = 5;

        [Description("Determines if the chances of getting hurt increase exponentially with each use of SCP-1162.")]
        public bool ExponentialHurtChances { get; set; } = false;

        [Description("The base chance (in percentage) for a player to get hurt while using SCP-1162.")]
        public int HurtChance { get; set; } = 50;

        [Description("The message displayed to the player when they're hurt by SCP-1162")]
        public string HurtMessage { get; set; } = "<b><size=20><color=red>[SCP-1162]</color> You feel a sharp excruciating pain trying to use SCP-1162.</size></b>";

        [Description("Change the message that displays when you drop an item through SCP-1162.")]
        public string ItemDropMessage { get; set; } = "<b><size=20><color=green>[SCP-1162]</color> You try to drop the item to get another.</size></b>";

        [Description("The Duration of the messages displayed by SCP-1162.")]
        public ushort MessageDuration { get; set; } = 5;

        [Description("The list of item chances.")]
        public List<ItemType> Chances { get; set; } = new List<ItemType>
        {
            ItemType.KeycardO5,
            ItemType.SCP500,
            ItemType.MicroHID,
            ItemType.KeycardNTFCommander,
            ItemType.KeycardContainmentEngineer,
            ItemType.SCP268,
            ItemType.GunCOM15,
            ItemType.SCP207,
            ItemType.Adrenaline,
            ItemType.GunCOM18,
            ItemType.KeycardFacilityManager,
            ItemType.Medkit,
            ItemType.KeycardNTFLieutenant,
            ItemType.KeycardGuard,
            ItemType.GrenadeHE,
            ItemType.KeycardZoneManager,
            ItemType.KeycardGuard,
            ItemType.Radio,
            ItemType.Ammo9x19,
            ItemType.Ammo12gauge,
            ItemType.Ammo44cal,
            ItemType.Ammo556x45,
            ItemType.Ammo762x39,
            ItemType.GrenadeFlash,
            ItemType.KeycardScientist,
            ItemType.KeycardJanitor,
            ItemType.Coin,
            ItemType.Flashlight
        };
    }
}