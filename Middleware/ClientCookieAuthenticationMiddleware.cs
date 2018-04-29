using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteTorrentServer.Middleware
{
    public class ClientCookieAuthenticationMiddleware
    {
        private readonly RequestDelegate next;

        public ClientCookieAuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            // fuuuuu
            return next(context);
        }
    }
}
