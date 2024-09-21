using Eshoping.GateWay.model;
using Eshoping.GateWay.services.IServices;
using Eshoping.GateWay.utility;
using Newtonsoft.Json;
using System.Net;
using System.Text;


namespace Eshoping.GateWay.services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }
        public async Task<ResponseDto>? SendAsync(RequestDto apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MangoAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);


                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Meassage = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Meassage = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Meassage = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Meassage = "InternalServerError" };
                    default:
                        var apicontent = await apiResponse.Content.ReadAsStringAsync();
                        var apiresponseDto = JsonConvert.DeserializeObject<ResponseDto>(apicontent);
                        return apiresponseDto;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
