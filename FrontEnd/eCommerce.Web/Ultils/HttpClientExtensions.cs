using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace eCommerce.Web.Ultils
{
    public static class HttpClientExtensions
    {

        private static System.Net.Http.Headers.MediaTypeHeaderValue contentType =
            new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


        public static async Task<T> 
            ReadContentAs<T>(this HttpResponseMessage response)
        {

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException
                    ($"Something went wrong calling API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.
                ReadAsStringAsync().ConfigureAwait(false);

#pragma warning disable CS8603 // Possível retorno de referência nula.
            return JsonSerializer.Deserialize<T>(dataAsString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
#pragma warning restore CS8603 // Possível retorno de referência nula.

        }



        public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return await httpClient.PostAsync(url, content);
        }


        public static async Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return await httpClient.PutAsync(url, content);
        }
    }
}
