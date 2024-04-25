using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NBA.Capturing.Domain.Enums;

namespace NBA.Capturing.Domain.Entities;
public class Packet
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;
    public string Source { get; set; } = default!;
    public string Destination { get; set; } = default!;
    public ushort Length { get; set; }
    public PacketType Type { get; set; }
    public DateTime TimeStamp { get; set; }
}
