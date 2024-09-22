using Eshoping.GateWay.utility;
using static Eshoping.GateWay.utility.SD;
using System.Net.Mime;

namespace Eshoping.GateWay.model.dto
{
    public class RequestDto
    {
        public ApiType? ApiType { get; set; }
        public string? Url { get; set; }
        public object? Data { get; set; }
        public string? AccessToken { get; set; }

        public ContentType ContentType { get; set; }
    }
}
