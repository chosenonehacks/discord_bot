﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoziomekBot
{
    public enum AccessLevel
    {
        Blocked,
        User,
        ChannelAdmin,
        ServerAdmin,
        ServerOwner,
        BotOwner
    }
}
