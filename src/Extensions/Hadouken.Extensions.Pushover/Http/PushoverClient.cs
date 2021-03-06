﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Hadouken.Common.Extensibility;
using Hadouken.Common.Logging;
using Hadouken.Common.Net;

namespace Hadouken.Extensions.Pushover.Http
{
    [Component(ComponentLifestyle.Singleton)]
    public class PushoverClient : IPushoverClient
    {
        private readonly ILogger<PushoverClient> _logger;
        private readonly IHttpClient _httpClient;
        private static readonly Uri ApiUri = new Uri("https://api.pushover.net/");

        public PushoverClient(ILogger<PushoverClient> logger, IHttpClient httpClient)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            if (httpClient == null) throw new ArgumentNullException("httpClient");

            _logger = logger;
            _httpClient = httpClient;
        }

        public void Send(PushoverMessage message)
        {
            if (message == null) throw new ArgumentNullException("message");

            var data = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("token", message.Token),
                    new KeyValuePair<string, string>("user", message.User),
                    new KeyValuePair<string, string>("message", message.Message)
                };

            if (!string.IsNullOrEmpty(message.Title))
            {
                data.Add(new KeyValuePair<string, string>("title", message.Title));
            }

            var uri = new Uri(ApiUri, "1/messages.json");
            var response = _httpClient.PostAsync(uri, new FormUrlEncodedContent(data)).Result;

            if (!response.IsSuccessStatusCode)
            {
                _logger.Error(string.Format("Error pushing message. Response status code: {0}.", response.StatusCode));
            }
        }
    }
}