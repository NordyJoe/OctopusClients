
using System.Collections.Generic;

namespace Octopus.Client.DataCenterManager.Model
{
	public partial class ConfigurationResource : Resource 
	{
        public string ConfigurationFilePath {get;set;}
        public bool SetupMode {get;set;}
        public bool FeatureInterface {get;set;}
        public string ConnectionString {get;set;}
        public string LogDirectory {get;set;}
        public string WorkingDirectory {get;set;}
        public string DataDirectory {get;set;}
        public bool CreateDatabase {get;set;}
	}
	public partial class KeysResource : Resource 
	{
        public IReadOnlyList<KeyResource> Keys {get;set;}
	}
	public partial class KeyResource : Resource 
	{
        public string Kty {get;set;}
        public string Use {get;set;}
        public string Kid {get;set;}
        public string X5t {get;set;}
        public IReadOnlyList<string> X5c {get;set;}
        public string E {get;set;}
        public string N {get;set;}
	}
	public partial class SignInResource : Resource 
	{
        public string Username {get;set;}
        public string Password {get;set;}
	}
	public partial class MigrationResource : Resource 
	{
        public string Id {get;set;}
        public string ServerTaskId {get;set;}
        public string Status {get;set;}
        public string SourceSpaceId {get;set;}
        public string SourceApiKey {get;set;}
        public string SourceTaskId {get;set;}
        public string DestinationSpaceId {get;set;}
        public string DestinationApiKey {get;set;}
        public string DestinationTaskId {get;set;}
        public string PackageId {get;set;}
        public string PackageVersion {get;set;}
        public string Password {get;set;}
        public IReadOnlyList<string> Projects {get;set;}
        public bool IgnoreCertificates {get;set;}
        public bool IgnoreMachines {get;set;}
        public bool IgnoreDeployments {get;set;}
        public bool IgnoreTenants {get;set;}
        public bool IncludeTaskLogs {get;set;}
        public bool IsDryRun {get;set;}
	}
	public partial class RootResource : Resource 
	{
        public string Application {get;set;}
        public string Version {get;set;}
        public string ApiVersion {get;set;}
	    public string InstallationId { get; set; }
	}
	public partial class SecurityGroupResource : Resource 
	{
        public string Id {get;set;}
        public string Name {get;set;}
        public IReadOnlyList<string> MemberUserIds {get;set;}
        public IReadOnlyList<NamedReferenceItem> ExternalSecurityGroups {get;set;}
        public IReadOnlyList<string> SecurityGroupIds {get;set;}
	}
	public partial class NamedReferenceItem : Resource 
	{
        public string Id {get;set;}
        public string DisplayName {get;set;}
        public bool DisplayIdAndName {get;set;}
	}
	public partial class SpaceResource : Resource 
	{
        public string Id {get;set;}
        public string Name {get;set;}
        public string PublicUri {get;set;}
	}
	public partial class ServerTaskResource : Resource 
	{
        public string Id {get;set;}
        public string Name {get;set;}
        public string State {get;set;}
        public string QueueTime {get;set;}
        public string StartTime {get;set;}
        public string CompletedTime {get;set;}
	}
	public partial class UserResource : Resource 
	{
        public string Id {get;set;}
        public string Username {get;set;}
        public string DisplayName {get;set;}
        public bool IsActive {get;set;}
        public bool IsService {get;set;}
        public bool IsRequestor {get;set;}
	}
	public partial class WellKnownConfigResource : Resource 
	{
        public string Issuer {get;set;}
        public string Authorization_endpoint {get;set;}
        public string Jwks_uri {get;set;}
	}
}
/*
namespace Octopus.DataCenterManager.Repositories
{
	using Octopus.DataCenterManager.Resources;

	public class AuthorizeRepository
	{
		        public void get(string response_type = null, string client_id = null, string redirect_uri = null, string scope = null, string state = null, string nonce = null)
		{
		}
    
	}
	public class ConfigurationRepository
	{
		        public void get()
		{
		}
        public void post(ConfigurationResource resource)
		{
		}
    
	}
	public class KeysRepository
	{
		        public void get()
		{
		}
    
	}
	public class LoginFormRepository
	{
		        public void post(SignInResource details)
		{
		}
        public void get()
		{
		}
    
	}
	public class MigrationRepository
	{
		        public void post(MigrationResource resource)
		{
		}
    
	}
	public class RootDocumentRepository
	{
		        public void get()
		{
		}
    
	}
	public class SecurityGroupRepository
	{
		        public void get()
		{
		}
        public void put(SecurityGroupResource resource)
		{
		}
        public void post(SecurityGroupResource resource)
		{
		}
        public void delete(SecurityGroupResource resource)
		{
		}
        public void get(string id)
		{
		}
    
	}
	public class SpacesRepository
	{
		        public void get(int skip = null, int take = null)
		{
		}
        public void put(SpaceResource resource)
		{
		}
        public void post(SpaceResource resource)
		{
		}
        public void get(string token = null)
		{
		}
    
	}
	public class TasksRepository
	{
		        public void get(string name = null)
		{
		}
        public void put(string Id = null, string Name = null, string State = null, string QueueTime = null, string StartTime = null, string CompletedTime = null)
		{
		}
    
	}
	public class UserRepository
	{
		        public void get()
		{
		}
        public void put(UserResource resource)
		{
		}
        public void post(UserResource resource)
		{
		}
        public void delete(UserResource resource)
		{
		}
        public void get(string id)
		{
		}
        public void get()
		{
		}
    
	}
	public class WellKnownConfigurationRepository
	{
		        public void get()
		{
		}
    
	}
}
*/

