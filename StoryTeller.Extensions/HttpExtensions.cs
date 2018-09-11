using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public static class HttpContentExtensions
{
    public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content) where T : class
    {
        try
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}

