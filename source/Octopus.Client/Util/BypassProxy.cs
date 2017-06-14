using System;
using System.Net;

namespace Octopus.Client.Util
{
    public class BypassProxy : IWebProxy
    {
        public Uri GetProxy(Uri destination) => throw new InvalidOperationException();

        public bool IsBypassed(Uri host) => true;

        public ICredentials Credentials { get; set; }
    }
}