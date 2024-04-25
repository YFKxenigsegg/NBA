using Microsoft.Extensions.Options;
using NBA.Capturing.Infrastructure.Factories;
using NBA.Management.Infrastructure;
using NBA.Management.Infrastructure.Options;

namespace NBA.Capturing.Infrastructure;
public class PacketsCollectionOptions : MongoCollectionOptions { }

public interface IPacketsCollectionFactory : IMongoCollectionFactory { }

public sealed class PacketsCollectionFactory(IOptions<PacketsCollectionOptions> options, IManagementDbFactory dbFactory)
    : MongoCollectionFactory<PacketsCollectionOptions, IManagementDbFactory>(options, dbFactory), IPacketsCollectionFactory // check 2nd T
{ }
