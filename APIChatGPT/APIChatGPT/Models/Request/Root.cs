namespace ClimaAPI.Models.Request
{
    public class Root
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }

        public Root(string question)
        {
            model = "gpt-3.5-turbo";
            messages = new List<Message>() { new Message { role = "user", content = question } };
        }
    }
}
