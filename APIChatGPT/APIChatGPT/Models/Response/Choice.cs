using ClimaAPI.Models.Request;

namespace ClimaAPI.Models.Response
{
    public class Choice
    {
        public int index { get; set; }
        public Message message { get; set; }
        public string finish_reason { get; set; }
    }
}
