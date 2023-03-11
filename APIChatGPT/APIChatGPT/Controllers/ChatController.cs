using APIChatGPT.Models.Request;
using APIChatGPT.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace APIChatGPT.Controllers
{
    [ApiController]
    [Route("api/chatGPT")]
    public class ChatController : Controller
    {
        private readonly HttpClient httpClient;
        public ChatController(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string question, [FromServices] IConfiguration configuration)
        {
            var token = configuration.GetValue<string>("ChatGptApiKey");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            Root rootRequest = new Root(question);
            var requestBody = JsonSerializer.Serialize(rootRequest);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            var rootResponse = await response.Content.ReadFromJsonAsync<RootResponse>();

            return Ok(rootResponse.choices);
        }
    }
}
