using Exiled.API.Features;
using MEC;
using SurfaceTension.API.Entities;
using SurfaceTension.API.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SurfaceTension.API
{
    public class SurfaceTensionAPI
    {
        public bool IsDetonated = false;

        public void AnnounceRadiation(Team team)
        {
            TeamAnnouncement announcement = Plugin.Instance.Config.AnnouncementConfig.FirstOrDefault(x => x.Team == team);

            if (announcement == null ||
                team == Team.RIP)
                return;

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Cassie) &&
                !string.IsNullOrEmpty(announcement.AnnouncementCassie) &&
                !string.IsNullOrEmpty(announcement.AnnouncementSubtitle))
                Timing.CallDelayed(announcement.Delay, () =>
                {
                    Cassie.MessageTranslated(announcement.AnnouncementCassie, announcement.AnnouncementSubtitle);
                });
            else if (announcement.AnnouncementType.HasFlag(AnnouncementType.Cassie) &&
                !string.IsNullOrEmpty(announcement.AnnouncementCassie))
                Timing.CallDelayed(announcement.Delay, () =>
                {
                    Cassie.Message(announcement.AnnouncementCassie);
                });

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Broadcast) &&
                !string.IsNullOrEmpty(announcement.AnnouncementSubtitle))
                foreach (Player player in Player.List)
                    player.Broadcast(announcement.DisplayFor, announcement.AnnouncementSubtitle);

            if (announcement.AnnouncementType.HasFlag(AnnouncementType.Hint) &&
                !string.IsNullOrEmpty(announcement.AnnouncementSubtitle))
                foreach (Player player in Player.List)
                    player.ShowHint(announcement.AnnouncementSubtitle, announcement.DisplayFor);
        }

        public float DamageCalculation(Player player)
        {
            TeamDamage damage = Plugin.Instance.Config.DamageConfig.FirstOrDefault(x => x.Team == player.Role.Team);

            if (damage.IsPercent)
                return (player.MaxHealth / 100) * damage.Damage;
            return damage.Damage;
        }

        public IEnumerator<float> DealTeamDamage(Team team)
        {
            TeamDamage damage = Plugin.Instance.Config.DamageConfig.FirstOrDefault(x => x.Team == team);

            while (true)
            {
                foreach (Player player in Player.List.Where(x => x.Role.Team == team))
                {
                    if (!player.IsAlive || player.IsGodModeEnabled)
                        continue;

                    if (player.Health > DamageCalculation(player))
                        player.Health -= DamageCalculation(player);
                    else
                        player.Kill("Died to radiation.");
                }

                yield return Timing.WaitForSeconds(damage.Interval);
            }
        }
    }
}
