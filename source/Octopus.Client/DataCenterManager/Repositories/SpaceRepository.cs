using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octopus.Client.DataCenterManager.Model;

namespace Octopus.Client.DataCenterManager.Repositories
{
    public interface ISpaceRepository
    {
        Task<SpaceResource> Create(SpaceResource resource);
        Task<SpaceResource> Modify(SpaceResource resource);
        Task<IReadOnlyList<SpaceResource>> GetAll();
        Task<SpaceResource> Get(string id);

        /// <summary>
        /// Gets the space associated with the API used to authenticate. Only valid 
        /// with API keys beginning with "SPACE"
        /// </summary>
        /// <returns></returns>
        Task<SpaceResource> FindByApiKey();
    }

    public class SpaceRepository : ISpaceRepository
    {
        public const string CollectionLinkName = "Spaces";

        private readonly IOctopusDataCenterManagerClient client;

        public SpaceRepository(IOctopusDataCenterManagerClient client)
        {
            this.client = client;
        }

        public Task<SpaceResource> Create(SpaceResource resource) 
            => client.Create(client.RootDocument.Link(CollectionLinkName), resource);

        public Task<SpaceResource> Modify(SpaceResource resource) 
            => client.Update(resource.Links["Self"], resource);

        public Task<IReadOnlyList<SpaceResource>> GetAll() 
            => client.ListAll<SpaceResource>(client.RootDocument.Link(CollectionLinkName));

        public Task<SpaceResource> Get(string id)
            => client.Get<SpaceResource>(client.RootDocument.Link(CollectionLinkName), new { id });

        public Task<SpaceResource> FindByApiKey() 
            => client.Get<SpaceResource>(client.RootDocument.Link("MySpace"));
    }
}