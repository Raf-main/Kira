using Kira.Application.Shared.Queries;
using Kira.Utils.Shared.Serializers;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Kira.Flight.Application.Behaviors;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IDistributedCache _cache;
    private readonly ISerializer _serializer;

    public CachingBehavior(IDistributedCache cache, ISerializer serializer)
    {
        _cache = cache;
        _serializer = serializer;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (request is not ICacheableQuery<TResponse> cacheableQuery)
        {
            return await next();
        }

        var cacheKey = cacheableQuery.GetCacheKey();

        var cachedResult = await _cache.GetAsync(cacheKey, cancellationToken);

        if (cachedResult != null)
        {
            return _serializer.Deserialize<TResponse>(cachedResult)!;
        }

        var response = await next();

        var options = new DistributedCacheEntryOptions();

        await _cache.SetAsync(cacheKey, _serializer.Serialize(response), options, cancellationToken);

        return response;
    }
}
