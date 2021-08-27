using GameCore;
using MEC;
using Synapse;
using Synapse.Api;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RQReplace.Handlers
{
    class EventHandlers
    {

        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerLeaveEvent += onLeave;
        }


        public void onLeave(Synapse.Api.Events.SynapseEventArguments.PlayerLeaveEventArgs ev)
        {
            if (Plugin.Config.IsEnabled && Map.Get.Round.RoundIsActive)
            {
                //checks if the player is not a spectator
                if (ev.Player.RoleType != RoleType.Spectator && ev.Player.RoleType != RoleType.None && Plugin.Config.ReplaceRoles.Contains(ev.Player.RoleID))
                {
                    //this is a random player in the spectator
                    var players = RoleType.Spectator.GetPlayers().Where(x => x.OverWatch == false);
                    if (players.Count() < 1) return;
                    var player = players.ElementAt(Random.Range(0, players.Count()));
                    //here data from the player who left is saved
                    ushort ammoGauge = ev.Player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo12gauge];
                    ushort cal44 = ev.Player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo44cal];
                    ushort ammo556 = ev.Player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo556x45];
                    ushort ammo762 = ev.Player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo762x39];
                    ushort ammo919 = ev.Player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo9x19];
                    float hp = ev.Player.Health;
                    int maxHP = ev.Player.MaxHealth;
                    ushort ahp = ev.Player.ArtificialHP;
                    var inventoryItems = ev.Player.Inventory.Items;
                    Vector3 position = ev.Player.Position;
                    float stamina = ev.Player.Stamina;
                    Vector3 scale = ev.Player.Scale;
                    var id = ev.Player.RoleID;
                    foreach (var items in ev.Player.Inventory.Items)
                        items.Despawn();
                    ev.Player.RoleID = (int)RoleType.Spectator;

                    Timing.CallDelayed(1f, () =>
                    {
                        player.SendBroadcast(5, $"<b><i>{Plugin.PluginTranslation.ActiveTranslation.ReplaceBroadcast}</i></b>");
                        player.RoleID = id;
                        player.Position = position;

                        if (Plugin.Config.UseScale)
                            player.Scale = scale;

                        if (Plugin.Config.UseMaxHealth)
                            player.MaxHealth = maxHP;

                        if (Plugin.Config.UseHealth)
                            player.Health = hp;

                        if (Plugin.Config.UseAHP)
                            player.ArtificialHP = ahp;

                        if (Plugin.Config.UseStamina)
                            player.Stamina = stamina;

                        if (Plugin.Config.AllowAmmoTransfer)
                        {
                            player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo12gauge] = ammoGauge;
                            player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo556x45] = ammo556;
                            player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo44cal] = cal44;
                            player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo762x39] = ammo762;
                            player.AmmoBox[Synapse.Api.Enum.AmmoType.Ammo9x19] = ammo919;
                            ;
                        }

                        if (Plugin.Config.UseInventory)
                        {
                            player.Inventory.Clear();
                            foreach (var item in inventoryItems)
                            player.Inventory.AddItem(item);
                        }
                    });
                }
            }
		}
	} 
}
