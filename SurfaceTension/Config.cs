﻿using Exiled.API.Interfaces;
using SurfaceTension.API.Entities;
using SurfaceTension.API.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace SurfaceTension
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("This is the configuration for the damage.")]
        public IEnumerable<TeamDamage> DamageConfig { get; private set; } = new List<TeamDamage>()
        {
            new TeamDamage()
            {
                Team = Team.SCP,
                Delay = 1f,
                Damage = 10,
                IsPercent = false,
                Interval = 2
            },
            new TeamDamage()
            {
                Team = Team.MTF,
                Delay = 2f,
                Damage = 5,
                IsPercent = true,
                Interval = 1
            }
        };

        public IEnumerable<TeamAnnouncement> AnnouncementConfig { get; private set; } = new List<TeamAnnouncement>()
        {
            new TeamAnnouncement()
            {
                Team = Team.SCP,
                AnnouncementCassie = "Radiation has been detected . . please evacuate immediately . ",
                AnnouncementSubtitle = "Radiation has been detected, please evacuate immediately.",
                Delay = 5f,
                DisplayFor = 5,
                AnnouncementType = AnnouncementType.Cassie | AnnouncementType.Broadcast | AnnouncementType.Hint
            },
            new TeamAnnouncement()
            {
                Team = Team.MTF,
                AnnouncementCassie = "Radiation has been detected . . please evacuate immediately . ",
                AnnouncementSubtitle = "Radiation has been detected, please evacuate immediately.",
                Delay = 5f,
                DisplayFor = 5,
                AnnouncementType = AnnouncementType.Cassie | AnnouncementType.Broadcast | AnnouncementType.Hint
            }
        };
    }
}
