namespace BeeckerLearningGround.Client.Models
{
    public class DynamicHttp : IDynamicHttp
    {
        private readonly HttpClient _httpClient;

        public DynamicHttp()
        {
            _httpClient = new HttpClient();
        }

        public void SetBaseAdress(string baseAdress)
        {
            _httpClient.BaseAddress = new Uri(baseAdress);
        }

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }
}
