namespace TeaMonkeyFruit.Token
{
    public interface ITokenManager
    {
        string Token { get; }
        void SetAccessToken(string token);
    }

    public class TokenManager : ITokenManager
    {
        public string Token { get; private set; }

        public void SetAccessToken(string token)
        {
            Token = token;
        }
    }
}