using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RemoteTorrentServer.Models;
using RemoteTorrentServer.Models.Configuration;
using RemoteTorrentServer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RemoteTorrentServer.Services
{
    /// <summary>
    /// An extension of HttpClient, providing methods for connecting with the
    /// qBittorrent Web API.
    /// </summary>
    public class ClientService : HttpClient, IClientService
    {
        private readonly qBittorrentConfig qConfig;
        private readonly HttpContext userHttpContext;

        public ClientService(
            IOptions<qBittorrentConfig> options,
            IHttpContextAccessor httpContextAccessor)
        {
            qConfig = options.Value;
            userHttpContext = httpContextAccessor.HttpContext;

            SetBaseAddress();
        }

        /// <summary>
        /// Fetch a list of all of the torrents in qBittorrent.
        /// </summary>
        /// <returns>List<Torrent></returns>
        public async Task<List<Torrent>> GetAllTorrentsAsync()
        {
            await AssignAuthCookie();

            var response = await GetAsync("query/torrents");

            if (IsSuccess(response))
            {
                var data = await response.Content.ReadAsStringAsync();
                var torrents = Deserialise<List<Torrent>>(data);
                return torrents;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// If the user HTTP request currently does not have a authorization cookie,
        /// we need to sign in and get the cookie.
        /// </summary>
        private async Task AssignAuthCookie()
        {
            const string COOKIE_KEY = "SID";

            if (userHttpContext.Request.Cookies.ContainsKey(COOKIE_KEY)) return;

            userHttpContext.Response.Cookies.Append(COOKIE_KEY, await GetAuthorizationCookie());
        }

        /// <summary>
        /// Queries the qBittorrent Web API for a login cookie.
        /// </summary>
        /// <returns>The authorization token.</returns>
        private async Task<string> GetAuthorizationCookie()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", qConfig.Username),
                new KeyValuePair<string, string>("password", qConfig.Password),
            });

            var response = await PostAsync("login", content);

            if (IsSuccess(response))
            {
                if (response.Headers.TryGetValues("Set-Cookie", out var header))
                {
                    return header.First()?.ToString()?.Substring(4, 32);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the target address for the HttpClient.
        /// </summary>
        private void SetBaseAddress()
        {
            BaseAddress = new Uri(qConfig.ServiceUri, UriKind.Absolute);
        }

        /// <summary>
        /// Check if the response from a request was succesful.
        /// </summary>
        /// <param name="response">The HTTP response object from an HttpClient request.</param>
        /// <returns>Wether the request was successful.</returns>
        private static bool IsSuccess(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Deserializes Json into the specified type, T.
        /// </summary>
        /// <typeparam name="T">Type to deserialise to.</typeparam>
        /// <param name="data">The Json string to deserialise.</param>
        /// <returns>Instance of T.</returns>
        private static T Deserialise<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Serialises an object into Json.
        /// </summary>
        /// <param name="obj">The object to serialise.</param>
        /// <returns>Serialised json.</returns>
        private static ByteArrayContent Serialise(dynamic obj)
        {
            var content = JsonConvert.SerializeObject(obj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}