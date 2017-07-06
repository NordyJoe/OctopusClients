using System;
using System.Net;
using Octopus.Client.Model;

namespace Octopus.Client
{
    /// <summary>
    /// Specifies the location and credentials to use when communicating with an Octopus Deploy server.
    /// </summary>
    public class OctopusServerEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OctopusServerEndpoint" /> class. Since no API key is provided, only
        /// very limited functionality will be available.
        /// </summary>
        /// <param name="octopusServerAddress">
        /// The URI of the Octopus Server. Ideally this should end with <c>/api</c>. If it ends with any other segment, the
        /// client
        /// will assume Octopus runs under a virtual directory.
        /// </param>
        public OctopusServerEndpoint(string octopusServerAddress)
            : this(octopusServerAddress, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OctopusServerEndpoint" /> class.
        /// </summary>
        /// <param name="octopusServerAddress">
        /// The URI of the Octopus Server. Ideally this should end with <c>/api</c>. If it ends with any other segment, the
        /// client
        /// will assume Octopus runs under a virtual directory.
        /// </param>
        /// <param name="apiKey">
        /// The API key to use when connecting to the Octopus server. For more information on API keys, please
        /// see the API documentation on authentication
        /// (https://github.com/OctopusDeploy/OctopusDeploy-Api/blob/master/sections/authentication.md).
        /// </param>
        public OctopusServerEndpoint(string octopusServerAddress, string apiKey)
            : this(octopusServerAddress, apiKey, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OctopusServerEndpoint" /> class.
        /// </summary>
        /// <param name="octopusServerAddress">
        /// The URI of the Octopus Server. Ideally this should end with <c>/api</c>. If it ends with any other segment, the
        /// client
        /// will assume Octopus runs under a virtual directory.
        /// </param>
        /// <param name="apiKey">
        /// The API key to use when connecting to the Octopus server. For more information on API keys, please
        /// see the API documentation on authentication
        /// (https://github.com/OctopusDeploy/OctopusDeploy-Api/blob/master/sections/authentication.md).
        /// </param>
        /// <param name="credentials">
        /// Additional credentials to use when communicating to servers that require integrated/basic
        /// authentication.
        /// </param>
        public OctopusServerEndpoint(string octopusServerAddress, string apiKey, ICredentials credentials)
        {
            if (string.IsNullOrWhiteSpace(octopusServerAddress))
                throw new ArgumentException("An Octopus server URI was not specified.");

            Uri uri;
            if (!Uri.TryCreate(octopusServerAddress, UriKind.Absolute, out uri) || !uri.Scheme.StartsWith("http"))
                throw new ArgumentException("The Octopus server URI given was invalid. The URI should start with http:// or https:// and be a valid URI.");

            OctopusServer = new DefaultLinkResolver(new Uri(octopusServerAddress));
            this.ApiKey = apiKey;
            this.Credentials = credentials ?? CredentialCache.DefaultNetworkCredentials;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OctopusServerEndpoint" /> class.
        /// </summary>
        /// <param name="octopusServer">The resolver that should be used to turn relative links into full URIs.</param>
        /// <param name="apiKey">
        /// The API key to use when connecting to the Octopus server. For more information on API keys, please
        /// see the API documentation on authentication
        /// (https://github.com/OctopusDeploy/OctopusDeploy-Api/blob/master/sections/authentication.md).
        /// </param>
        /// <param name="credentials">
        /// Additional credentials to use when communicating to servers that require integrated/basic
        /// authentication.
        /// </param>
        public OctopusServerEndpoint(ILinkResolver octopusServer, string apiKey, ICredentials credentials)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("An API key was not specified. Please set an API key using the ApiKey property. This can be gotten from your user profile page under the Octopus web portal.");

            this.OctopusServer = octopusServer;
            this.ApiKey = apiKey;
            this.Credentials = credentials ?? CredentialCache.DefaultNetworkCredentials;
        }

        /// <summary>
        /// The URI of the Octopus Server. Ideally this should end with <c>/api</c>. If it ends with any other segment, the
        /// client  will assume Octopus runs under a virtual directory.
        /// </summary>
        public ILinkResolver OctopusServer { get; }

        /// <summary>
        /// Gets the API key to use when connecting to the Octopus server. For more information on API keys, please see the API
        /// documentation on authentication
        /// (https://github.com/OctopusDeploy/OctopusDeploy-Api/blob/master/sections/authentication.md).
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Gets the additional credentials to use when communicating to servers that require integrated/basic authentication.
        /// </summary>
        public ICredentials Credentials { get; }

        /// <summary>
        /// Recreates the endpoint using the API key of a new user.
        /// </summary>
        /// <param name="newUserApiKey">The new user API key.</param>
        /// <returns>An endpoint with a new user.</returns>
        public OctopusServerEndpoint AsUser(string newUserApiKey)
        {
            return new OctopusServerEndpoint(OctopusServer, newUserApiKey, Credentials);
        }

        /// <summary>
        /// A proxy that should be used to connect to the endpoint.
        /// </summary>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        /// The timeout for requests
        /// </summary>
        public TimeSpan RequestTimeout { get; set; } = ApiConstants.DefaultClientRequestTimeoutTimespan;
    }
}