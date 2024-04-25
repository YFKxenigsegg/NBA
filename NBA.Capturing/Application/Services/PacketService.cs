using NBA.Capturing.Domain.Entities;
using NBA.Capturing.Infrastructure;

namespace NBA.Capturing.Application.Services;
public interface IPacketService
{
    Task StoreAsync(IEnumerable<Packet> packets, CancellationToken ct);
}

public class PacketService(IPacketsCollectionFactory factory) : IPacketService
{
    private readonly IPacketsCollectionFactory _factory = factory;

    public async Task StoreAsync(IEnumerable<Packet> packets, CancellationToken ct)
    {
        var collection = await _factory.GetAsync<Packet>(ct);
        await collection.InsertManyAsync(packets, cancellationToken: ct);
    }
}
