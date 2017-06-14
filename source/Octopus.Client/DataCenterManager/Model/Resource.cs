using System;

namespace Octopus.Client.DataCenterManager.Model
{
    public class Resource
    {
        public LinkCollection Links { get; set; }

        /// <summary>
        /// Determines whether the specified link exists.
        /// </summary>
        /// <param name="name">The name/key of the link.</param>
        /// <returns>
        /// <c>true</c> if the specified link is defined; otherwise, <c>false</c>.
        /// </returns>
        public bool HasLink(string name) => Links.ContainsKey(name);

        /// <summary>
        /// Gets the link with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">If the link is not defined.</exception>
        public string Link(string name)
        {
            if (Links != null && Links.TryGetValue(name, out string value))
                return value;

            throw new Exception($"The document does not define a link for '{name}'");
        }
    }
}