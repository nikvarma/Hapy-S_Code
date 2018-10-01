using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public static class HttpClientRequest
    {
        public static async Task<T> Get<T>(IHttpClientOptions httpClientOptions)
        {
            Object content = "";
            using (HttpClient _httpClient = new HttpClient())
            {
                if (httpClientOptions.OutPutFormat == OutPutFormat.String)
                {
                    content = await _httpClient.GetStringAsync(httpClientOptions.URL);
                }
                else if (httpClientOptions.OutPutFormat == OutPutFormat.HttpResponse)
                {
                    content = await _httpClient.GetAsync(httpClientOptions.URL, HttpCompletionOption.ResponseContentRead);
                }
                else if (httpClientOptions.OutPutFormat == OutPutFormat.XML)
                {

                }
                else if (httpClientOptions.OutPutFormat == OutPutFormat.Stream)
                {
                }
            }
            return (T)Convert.ChangeType(content, typeof(T));
        }
    }

    public interface IHttpClientOptions
    {
        Uri URL { get; set; }
        OutPutFormat OutPutFormat { get; set; }
    }

    public class HttpClientOptions : IHttpClientOptions
    {
        public Uri URL { get; set; }
        public OutPutFormat OutPutFormat { get; set; }
    }

    public enum OutPutFormat
    {
        Json,
        XML,
        HttpResponse,
        String,
        Stream
    }
}
