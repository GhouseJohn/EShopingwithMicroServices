namespace Eshoping.GateWay.model.dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public string? ErrorMessages { get; set; }
        public string? Meassage { get; set; }
        public string? url { get; set; }

    }
}
