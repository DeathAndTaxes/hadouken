﻿using System;
using Hadouken.Common.Messaging;

namespace Hadouken.Common.BitTorrent
{
    public sealed class TorrentPausedMessage : IMessage
    {
        private readonly ITorrent _torrent;

        public TorrentPausedMessage(ITorrent torrent)
        {
            if (torrent == null) throw new ArgumentNullException("torrent");
            _torrent = torrent;
        }

        public ITorrent Torrent
        {
            get { return _torrent; }
        }
    }
}
