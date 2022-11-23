﻿using M3u8Downloader_H.Core.M3u8UriManagers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace M3u8Downloader_H.Core.M3u8UriProviders
{
    internal class M3u8UriManager  : IM3u8UriManager
    {
        public Task<Uri> GetM3u8UriAsync(Uri uri, CancellationToken cancellationToken)
        {
            return Task.FromResult(uri);
        }
    }
}