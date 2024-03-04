namespace Kira.Application.Shared.Queries
{
    public interface ICacheableQuery<T>
    {
        string GetCacheKey();
    }
}
