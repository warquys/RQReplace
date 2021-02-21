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
            if (Plugin.Config.IsEnabled && Map.Get.Round.RoundIsActive && Server.Get.Players.Count > 0)
            {
                //checks if the player is not a spectator
                if (ev.Player.RoleType != RoleType.Spectator || ev.Player.RoleType != RoleType.None)
                {
                    //this is a random player in the spectator
                    var players = RoleType.Spectator.GetPlayers().Where(x => x.OverWatch == false);
                    var player = players.ElementAt(UnityEngine.Random.Range(0, players.Count()));
                    //here data from the player who left is saved
                    RoleType role = ev.Player.RoleType;
                    uint ammo5 = ev.Player.Ammo5;
                    uint ammo7 = ev.Player.Ammo7;
                    uint ammo9 = ev.Player.Ammo9;
                    float hp = ev.Player.Health;
                    int maxHP = ev.Player.MaxHealth;
                    float ahp = ev.Player.ArtificialHealth;
                    var inventoryItems = ev.Player.Inventory.Items;
                    Vector3 position = ev.Player.Position;
                    float stamina = ev.Player.Stamina;
                    Vector3 scale = ev.Player.Scale;
                    var id = ev.Player.RoleID;

                    Timing.CallDelayed(1f, () =>
                    {
                        player.SendBroadcast(5, Plugin.Config.ReplaceBroadcast);
                        player.RoleID = id;
                        player.Position = position;

                        if (Plugin.Config.useScale)
                            player.Scale = scale;

                        if (Plugin.Config.useMaxHealth)
                            player.MaxHealth = maxHP;

                        if (Plugin.Config.useHealth)
                            player.Health = hp;

                        if (Plugin.Config.useAHP)
                            player.ArtificialHealth = ahp;

                        if (Plugin.Config.useStamina)
                            player.Stamina = stamina;

                        if (Plugin.Config.AllowAmmoTransfer)
                        {
                            player.Ammo5 = ammo5;
                            player.Ammo7 = ammo7;
                            player.Ammo9 = ammo9;
                        }

                        if (Plugin.Config.useInventory)
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
