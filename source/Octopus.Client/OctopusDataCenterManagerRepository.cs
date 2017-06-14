using System;
using Octopus.Client.DataCenterManager.Repositories;

namespace Octopus.Client
{

    public interface IOctopusDataCenterManagerRepository 
    {
        IOctopusDataCenterManagerClient Client { get; }
        ISpaceRepository Spaces { get; set; }
    }

    public class OctopusDataCenterManagerRepository : IOctopusDataCenterManagerRepository
    {

        public OctopusDataCenterManagerRepository(IOctopusDataCenterManagerClient client)
        {
            Client = client;
            Spaces = new SpaceRepository(client);
        }

        public IOctopusDataCenterManagerClient Client { get; }
        public ISpaceRepository Spaces { get; set; }
    }
}