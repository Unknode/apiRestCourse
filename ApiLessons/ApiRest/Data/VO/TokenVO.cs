namespace ApiRest.Data.VO
{
    public class TokenVO
    {

        public bool Authenticated { get; set; }

        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string Refreshtoken { get; set; }

        public TokenVO(bool authenticated, string created, string expiration, string accessToken, string refreshtoken)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            Refreshtoken = refreshtoken;
        }
    }
}
