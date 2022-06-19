using Surface_Tension.API.Enums;

namespace Surface_Tension.API.Entities
{
    public class TeamAnnouncement
    {
        public Team Team { get; set; }
        public string AnnouncementCassie { get; set; }
        public string AnnouncementSubtitle { get; set; }
        public float Delay { get; set; }
        public ushort DisplayFor { get; set; }
        public AnnouncementType AnnouncementType { get; set; }
    }
}
