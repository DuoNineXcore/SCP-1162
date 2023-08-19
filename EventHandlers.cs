using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using PlayerRoles;
using SCP1162.API;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PlayerStatsSystem;

namespace SCP1162
{
    public class EventHandlers
    {
        private Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public const float RadiusSqr = 8f * 8f;
        private Dictionary<Player, int> playerUseCount = new Dictionary<Player, int>();
        private Dictionary<Player, int> playerHurtCount = new Dictionary<Player, int>();

        public bool IsPlayerIn1162Zone(Player player)
        {
            Door scp173Door = Door.List.FirstOrDefault(door => door.Name == "173_GATE");

            if (scp173Door == null)
            {
                Log.Warn("Failed to find SCP-173's door.");
                return false;
            }

            Vector3 insideChamberReference = scp173Door.Position + scp173Door.Transform.rotation * new Vector3(-1f, 0f, -8f);

            float distanceSqr = (player.Position - insideChamberReference).sqrMagnitude;
            return distanceSqr <= RadiusSqr;
        }

        public void OnPlayerDied(DiedEventArgs ev)
        {
            if (plugin.Config.SCP1162Hurts)
            {
                if (playerUseCount.ContainsKey(ev.Player))
                {
                    playerUseCount[ev.Player] = 0;
                }
            }
        }

        public void OnItemDropped(DroppingItemEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            bool isIn1162Zone = plugin.Config.UseNew173Spawn
                                ? Vector3.Distance(ev.Player.Position, RoleTypeId.Scp173.GetRandomSpawnLocation().Position) <= 8.2f
                                : IsPlayerIn1162Zone(ev.Player);

            if (!isIn1162Zone) return;

            if (plugin.Config.SCP1162Hurts)
            {
                if (!playerHurtCount.ContainsKey(ev.Player))
                {
                    playerHurtCount[ev.Player] = 0;
                }

                if (!playerUseCount.ContainsKey(ev.Player))
                {
                    playerUseCount[ev.Player] = 0;
                }

                int uses = playerUseCount[ev.Player];
                int chanceOfBeingHurt = plugin.Config.ExponentialHurtChances
                                        ? Math.Min(uses * plugin.Config.HurtChance, 100)
                                        : plugin.Config.HurtChance;

                if (new System.Random().Next(0, 100) < chanceOfBeingHurt)
                {
                    playerHurtCount[ev.Player]++;
                    playerUseCount[ev.Player]++;

                    if (playerHurtCount[ev.Player] < plugin.Config.HurtLimit)
                    {
                        ev.Player.Hurt(60);
                        ev.Player.EnableEffect(EffectType.Blinded, 5);
                        ev.Player.ShowHint(plugin.Config.HurtMessage, plugin.Config.MessageDuration);

                        if (plugin.Config.ExponentialHurtChances)
                        {
                            playerUseCount[ev.Player] = 0;
                        }

                        return;
                    }
                    else
                    {
                        ev.Player.Kill("SCP-1162.");
                        playerUseCount[ev.Player] = 0;
                        return;
                    }
                }
            }

            if (plugin.Config.UseHints)
                ev.Player.ShowHint(plugin.Config.ItemDropMessage, plugin.Config.MessageDuration);
            else
                ev.Player.Broadcast(plugin.Config.MessageDuration, plugin.Config.ItemDropMessage, Broadcast.BroadcastFlags.Normal, true);

            ev.IsAllowed = false;
            var oldItem = ev.Item.Base.ItemTypeId;
            ev.Player.RemoveItem(ev.Item);
            var newItemType = plugin.Config.Chances[UnityEngine.Random.Range(0, plugin.Config.Chances.Count)];
            var eventArgs = new UsingScp1162EventArgs(ev.Player, newItemType, oldItem);
            Scp1162Event.OnUsingScp1162(eventArgs);
            var newItem = Item.Create(eventArgs.ItemAfter);
            ev.Player.AddItem(newItem);
            ev.Player.DropItem(newItem);
        }
    }
}