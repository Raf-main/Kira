namespace Kira.Utils.Shared.Serializers
{
    public interface ISerializer
    {
        byte[] Serialize<T>(T value);
        T? Deserialize<T>(byte[] value);
    }
}
