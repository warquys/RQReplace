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

        [Description("Should ammo be transferred?")]
        public bool AllowAmmoTransfer { get; set; } = true;

        [Description("Should the size be transferred?")]
        public bool UseScale { get; set; } = true;

        [Description("Should max health be transferred?")]
        public bool UseMaxHealth { get; set; } = true;

        [Description("Should HP be transferred?")]
        public bool UseHealth { get; set; } = true;

        [Description("Should AHP be transferred?")]
        public bool UseAHP { get; set; } = true;

        [Description("Should Stamina be transferred?")]
        public bool UseStamina { get; set; } = true;

        [Description("Should the inventory be transferred?")]
        public bool UseInventory { get; set; } = true;

        [Description("Which Roles should be replaced?")]
        public List<int> ReplaceRoles { get; set; } = new List<int>()
        {
            (int) RoleType.Scp049,
            (int) RoleType.Scp079,
            (int) RoleType.Scp096,
            (int) RoleType.Scp106,
            (int) RoleType.Scp173,
            (int) RoleType.Scp93953,
            (int) RoleType.Scp93989,
        };

    }
}
