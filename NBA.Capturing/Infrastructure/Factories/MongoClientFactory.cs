﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NBA.Management.Infrastructure.Options;
using System.Collections.Concurrent;

namespace NBA.Capturing.Infrastructure.Factories;
public interface IMongoClientFactory
{
    IMongoClient GetOrCreate();
}

public sealed class MongoClientFactory(IOptions<MongoConnectionOptions> options) : IMongoClientFactory
{
    private readonly ConcurrentDictionary<string, IMongoClient> _cache = new();
    private readonly MongoConnectionOptions _options = options.Value;

    public IMongoClient GetOrCreate()
    {
        var name = _options.Name.Trim().ToLowerInvariant();
        if (_cache.ContainsKey(name)) return _cache[name];
        _cache[name] = new MongoClient(new MongoUrl(_options.Url));
        return _cache[name];
    }
}
