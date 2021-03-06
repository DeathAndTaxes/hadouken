﻿using System;
using Hadouken.Common.BitTorrent;
using Hadouken.Common.Messaging;

namespace Hadouken.Core.BitTorrent.Handlers
{
    internal sealed class QueuePositionBottomHandler : IMessageHandler<QueuePositionBottomMessage>
    {
        private readonly ITorrentManager _torrentManager;

        public QueuePositionBottomHandler(ITorrentManager torrentManager)
        {
            if (torrentManager == null) throw new ArgumentNullException("torrentManager");
            _torrentManager = torrentManager;
        }

        public void Handle(QueuePositionBottomMessage message)
        {
            Torrent torrent;
            if (!_torrentManager.Torrents.TryGetValue(message.InfoHash, out torrent)) return;

            torrent.Handle.QueuePositionBottom();
        }
    }
}
