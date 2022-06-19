using System;

namespace Surface_Tension.API.Enums
{
    [Flags]
    public enum AnnouncementType
    {
        Cassie = 1,
        Broadcast = 2,
        Hint = 4
    }
}
