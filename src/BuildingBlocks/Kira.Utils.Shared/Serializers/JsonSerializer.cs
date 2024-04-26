using System.Text;
using Newtonsoft.Json;

namespace Kira.Utils.Shared.Serializers;

public class JsonSerializer : ISerializer
{
    public byte[] Serialize<T>(T value)
    {
        var json = JsonConvert.SerializeObject(value);

        return Encoding.UTF8.GetBytes(json);
    }

    public T? Deserialize<T>(byte[] value)
    {
        var json = Encoding.UTF8.GetString(value);

        return JsonConvert.DeserializeObject<T>(json);
    }
}
