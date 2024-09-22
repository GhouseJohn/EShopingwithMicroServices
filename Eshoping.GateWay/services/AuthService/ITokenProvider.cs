namespace Eshoping.GateWay.services.AuthService
{
    public interface ITokenProvider
    {
        void SetToken(string token);
        void ClearToken();
        string? GetToken();

    }
}
