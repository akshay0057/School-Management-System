using BlazorServerUIApp.Models.ResponseModels;
using System.Text.Json;
using System.Text;
using BlazorServerUIApp.Services.IServices;
using BlazorServerUIApp.Models.Enum;

namespace BlazorServerUIApp.Services
{
    public class CommonCallAPI
    {
        private IHttpClientFactory _httpClientFactory { get; }
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorageService;
        public CommonCallAPI(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _localStorageService = localStorageService;

        }

        public async Task<TResponse> CallApiAsync<TRequest, TResponse>(string endpoint, HttpMethod httpMethod, TRequest? requestModel = default) where TResponse : CommonRes, new()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiUrl = _configuration["APIBaseUrl"];

            string token = "";
            string userId = "";
            if (endpoint == "auth/login" || endpoint == "auth/sendotp" || endpoint == "auth/verifyotp" || endpoint == "auth/resetpassword" || endpoint == "auth/forgotpassword" || endpoint == "auth/refreshtoken")
            {
                token = "";
                userId = "";
            }
            else
            {
                token = await _localStorageService.GetItem<string>(LocalStorageItem.Token.ToString());
                userId = await _localStorageService.GetItem<string>(LocalStorageItem.UserId.ToString());
            }

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token); // pass token
            httpClient.DefaultRequestHeaders.Add("LoginUserId", userId); // pass login user id 

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(httpMethod, $"{apiUrl}/{endpoint}");

                if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put)
                {
                    if (requestModel != null)
                    {
                        // Serialize request model to JSON if method is POST or PUT
                        request.Content = new StringContent(
                            JsonSerializer.Serialize(requestModel),
                            Encoding.UTF8,
                            "application/json"
                        );
                    }
                }
                else if (httpMethod == HttpMethod.Delete)
                {
                    // Optionally add request content or query parameters for DELETE requests if needed
                    // For DELETE requests, you usually don't need to send content.
                    if (requestModel != null)
                    {
                        var queryParams = JsonSerializer.Serialize(requestModel);
                        request.Content = new StringContent(
                            queryParams,
                            Encoding.UTF8,
                            "application/json"
                        );
                    }
                }

                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    // Attempt to deserialize the response to TResponse
                    var result = await response.Content.ReadFromJsonAsync<TResponse>();
                    if (result != null)
                    {
                        return result;
                    }
                }

                // Return default instance with error details if response is not successful
                return new TResponse
                {
                    Status = false,
                    Message = "Failed to load data.",
                    Error = new ErrorModel
                    {
                        StatusCode = response.StatusCode.ToString(),
                        ErrorDescryption = response.ReasonPhrase ?? "Unknown error"
                    }
                };
            }
            catch (Exception ex)
            {
                // Return default instance with exception details
                return new TResponse
                {
                    Status = false,
                    Message = "An error occurred while fetching the data.",
                    Error = new ErrorModel
                    {
                        StatusCode = "500",
                        ErrorDescryption = ex.Message
                    }
                };
            }
        }

    }
}
