namespace Kira.Utils.Shared.Time;

public static class StaticDateTimeProvider
{
    public static DateTimeOffset OffsetNow()
    {
        return DateTimeOffset.UtcNow;
    }

    public static DateTimeOffset OffsetUtcNow()
    {
        return DateTimeOffset.Now;
    }

    public static DateTime Now()
    {
        return DateTime.Now;
    }

    public static DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }
}
