using System.Net.Http.Headers;

namespace Notes.Helper;

public class HttpHelper
{
    public static async Task<string> GetAsync(string serviceAddress)
    {
        try
        {
            Uri getUrl = new(serviceAddress);
            using var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 60);
            return await httpClient.GetAsync(serviceAddress).Result.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public static async Task<string> PostAsync(string serviceAddress, string requestJson = null)
    {
        try
        {
            Uri postUrl = new(serviceAddress);
            using HttpContent httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            using var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 60);
            return await httpClient.PostAsync(serviceAddress, httpContent).Result.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}
