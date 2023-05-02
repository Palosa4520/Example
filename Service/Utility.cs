using Newtonsoft.Json;
using System.Web;

namespace Service;
public static class Utility
{
    public static string? ToQueryString(this object? obj)
    {
        object obj2 = obj;
        if (obj2 == null)
        {
            return null;
        }

        IEnumerable<string> values = from x in obj2.GetType().GetProperties()
                                     select HttpUtility.UrlEncode(x.Name) + "=" + HttpUtility.UrlEncode(x.GetValue(obj2)?.ToString());
        return string.Join('&', values);
    }
    public static T? JsonToType<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}
