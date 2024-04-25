using Microsoft.Extensions.Options;
using NBA.Capturing.Infrastructure.Factories;
using NBA.Management.Infrastructure.Options;

namespace NBA.Management.Infrastructure;
public class ManagementDbOptions : MongoDbOptions { }

public interface IManagementDbFactory : IMongoDbFactory { }

public sealed class ManagementDbFactory(IOptions<ManagementDbOptions> options, IMongoClientFactory factory)
    : MongoDbFactory<ManagementDbOptions>(options, factory), IManagementDbFactory
{ }
