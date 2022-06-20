using SurfaceTension.API.Enums;

namespace SurfaceTension.API.Entities
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
