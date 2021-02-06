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
        public bool IsEnabled = true;

        [Description("Is this plugin enabled?")]
        public string ReplaceBroadcast = "<b>[RQReplace] You have replaced a player!</b>";

        [Description("Should ammo be transferred?")]
        public bool AllowAmmoTransfer = true;

        [Description("Should the size be transferred?")]
        public bool useScale = true;

        [Description("Should max health be transferred?")]
        public bool useMaxHealth = true;

        [Description("Should HP be transferred?")]
        public bool useHealth = true;

        [Description("Should AHP be transferred?")]
        public bool useAHP = true;

        [Description("Should Stamina be transferred?")]
        public bool useStamina = true;

        [Description("Should the inventory be transferred?")]
        public bool useInventory = true;

    }
}
