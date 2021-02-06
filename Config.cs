using Synapse.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RQReplace
{
    public class Config : AbstractConfigSection
    {
        [Description("Is this plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Is this plugin enabled?")]
        public string ReplaceBroadcast { get; set; } = "<b>[RQReplace] You have replaced a player!</b>";

        [Description("Should ammo be transferred?")]
        public bool AllowAmmoTransfer { get; set; } = true;

        [Description("Should the size be transferred?")]
        public bool useScale { get; set; } = true;

        [Description("Should max health be transferred?")]
        public bool useMaxHealth { get; set; } = true;

        [Description("Should HP be transferred?")]
        public bool useHealth { get; set; } = true;

        [Description("Should AHP be transferred?")]
        public bool useAHP { get; set; } = true;

        [Description("Should Stamina be transferred?")]
        public bool useStamina { get; set; } = true;

        [Description("Should the inventory be transferred?")]
        public bool useInventory { get; set; } = true;

    }
}
