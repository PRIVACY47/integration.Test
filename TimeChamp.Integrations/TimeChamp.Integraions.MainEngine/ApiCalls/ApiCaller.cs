using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace TimeChamp.Integraions.MainEngine.ApiCalls
{
    public class ApiCaller
    {
        private readonly HttpClient _httpClient;

        public ApiCaller()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> MakeApiCallAsync(string baseUrl, string endPoint, string jsonPayload = null)
        {
            try
            {
                // Build the full URL
                var url = $"{baseUrl.TrimEnd('/')}/{endPoint.TrimStart('/')}";
                string reSerialized = JsonConvert.SerializeObject(jsonPayload) ;

                var content = new StringContent(reSerialized, Encoding.UTF8, "application/json");

                // Send the request
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read the response content
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Handle errors (log them, rethrow, or return an error message)
                Console.WriteLine($"Error: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }
    }

}
