using MEC;
using Synapse;
using Synapse.Api;
using Synapse.Api.Enum;
using Synapse.Api.Events.SynapseEventArguments;
using Synapse.Api.Items;
using Synapse.Api.Roles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RQReplace.Handlers
{
    class EventHandlers
    {
        private Player _player;
        private int? _id;
        
        private Vector3 _postion;
        private float _roation;

        private Vector3? _scale;
        private float? _maxHealth;
        private float? _health;
        private float? _artificialHealth;
        private int? _maxArtificialHealth;
        private float? _stamina;
        private Dictionary<AmmoType, ushort> _ammo;
        private List<SynapseItem> _items;

        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerLeaveEvent += OnLeave;
            Server.Get.Events.Player.PlayerSetClassEvent += OnSetClass;
        }

        private void OnSetClass(PlayerSetClassEventArgs ev)
        {
            if (ev.Player == _player && (
                (RoleManager.HighestRole < _id  && ev.Player.RoleID == _id) || 
                (RoleManager.HighestRole >= _id && (int)ev.Role == _id)))
            {
                _id     = null; 
                _player = null;
                
                ev.Position = _postion;
                ev.Rotation = _roation;
                
                if (_items != null) ev.Items = _items; _items = null;
                if (_ammo != null)  ev.Ammo = _ammo;    _ammo = null;
                
                Timing.CallDelayed(0.2f, () =>
                {
                    if (ev.Player == null) return;
                    //set the value   check if is def                   set the value if is def                      set save value to not def
                    if (_maxArtificialHealth != null)   ev.Player.MaxArtificialHealth = _maxArtificialHealth.Value; _maxArtificialHealth = null;
                    if (_artificialHealth != null)      ev.Player.ArtificialHealth = _artificialHealth.Value;       _artificialHealth = null;
                    if (_maxHealth != null)             ev.Player.MaxHealth = _maxHealth.Value;                     _maxHealth = null;
                    if (_health != null)                ev.Player.Health = _health.Value;                           _health = null;
                    if (_stamina != null)               ev.Player.Stamina = _stamina.Value;                         _stamina = null;
                    if (_scale != null)                 ev.Player.Scale = _scale.Value;                             _scale = null;
                });
            }
        }

        public void OnLeave(Synapse.Api.Events.SynapseEventArguments.PlayerLeaveEventArgs ev)
        {
            if (!Plugin.Config.IsEnabled || !Map.Get.Round.RoundIsActive)
                return;

            //checks if the player is not a spectator
            if (ev.Player.RoleType != RoleType.Spectator && ev.Player.RoleType != RoleType.None && 
                (!Plugin.Config.ReplaceOnlyList || Plugin.Config.ReplaceRoles.Contains(ev.Player.RoleID)))
            {
                //this is a random player in the spectator
                var players = RoleType.Spectator.GetPlayers().Where(x => !x.OverWatch);
                if (!players.Any()) return;
                var player = players.ElementAt(Random.Range(0, players.Count()));

                player.SendBroadcast(5, $"{Plugin.PluginTranslation.ActiveTranslation.ReplaceBroadcast}");

                //get value

                _id = player.RoleID = ev.Player.RoleID;
                _postion = ev.Player.Position;
                _roation = ev.Player.Rotation.x;

                if (Plugin.Config.UseScale)
                    _scale = ev.Player.Scale;

                if (Plugin.Config.UseMaxHealth)
                    _maxHealth = ev.Player.MaxHealth;

                if (Plugin.Config.UseHealth)
                    _health = ev.Player.Health;

                if (Plugin.Config.UseAHP)
                    _artificialHealth = ev.Player.ArtificialHealth;

                if (Plugin.Config.UseStamina)
                    _stamina = ev.Player.Stamina;

                if (Plugin.Config.AllowAmmoTransfer)
                {
                    _ammo = new Dictionary<AmmoType, ushort>();
                    foreach (AmmoType ammoType in (AmmoType[])System.Enum.GetValues(typeof(AmmoType)))
                        _ammo[ammoType] = ev.Player.AmmoBox[ammoType];
                }

                if (Plugin.Config.UseInventory)
                {
                    _items = new List<SynapseItem>();
                    foreach (var item in ev.Player.Inventory.Items)
                    {
                        item.Despawn();
                        _items.Add(item);
                    }
                }

                ev.Player.RoleID = (int)RoleType.Spectator;
            }
            
		}
	} 
}
