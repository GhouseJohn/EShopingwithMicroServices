namespace Eshoping.GateWay.utility
{
    public class SD
    {
        public static string? BookStoredAPIBase { get; set; }
        public static string? KSWCAPIBase { get; set; }
        public static string? AuthApi { get; set; }
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
