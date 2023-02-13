using Microsoft.AspNetCore.Mvc;
using ContactManagementAssistant.ChatGptClient;

namespace ContactManagementAssistant.Controllers
{
    [ApiController]
    [Route("mycontroller")]
    public class ContactsManagementController : ControllerBase
    {

        private readonly ILogger<ContactsManagementController> _logger;
        private IChatGptClient chatGptClient;
            
        public ContactsManagementController(ILogger<ContactsManagementController> logger, IChatGptClient chatGptClient)
        {
            _logger = logger;
            this.chatGptClient = chatGptClient;
        }

        [HttpGet(Name = "getGptResponseTest")]
        public string Get()
        {
            return chatGptClient.Create("add abc to my contacts he lives in 123 street, New York, Usa using microsoft graph api");
        }

        [HttpPost(Name = "contactQuery")]
        public string Post([FromBody] string prompt)
        {
            return chatGptClient.Create(prompt);
        }
    }
}