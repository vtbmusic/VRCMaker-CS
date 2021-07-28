using RestSharp;
using System.Threading.Tasks;

namespace VRCMaker.Service
{
    public class APITools
    {
        public async static Task<string> CheckConnection()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://api.aqua.chat/v2/app/version", Method.GET);
            var response = await client.ExecuteAsync(request);
            return (response.StatusCode == System.Net.HttpStatusCode.OK) ? "Successful" : "Failed";
        }
    }
}
