namespace BeeckerLearningGround.Client.Models;

public interface IDynamicHttp
{
    HttpClient GetHttpClient();
    void SetBaseAdress(string baseAdress);
}