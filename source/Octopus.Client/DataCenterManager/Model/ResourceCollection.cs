using System.Collections.Generic;

namespace Octopus.Client.DataCenterManager.Model
{
    public class ResourceCollection<T> : Resource
    {
        public int TotalResults { get; set; }
        public int ItemsPerPage { get; set; }
        public IReadOnlyList<T> Items { get; set; }
    }
}