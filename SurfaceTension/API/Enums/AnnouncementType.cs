﻿using System;

namespace SurfaceTension.API.Enums
{
    [Flags]
    public enum AnnouncementType
    {
        Cassie = 1,
        Broadcast = 2,
        Hint = 4
    }
}
