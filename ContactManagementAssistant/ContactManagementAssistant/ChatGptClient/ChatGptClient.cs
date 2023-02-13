using Newtonsoft.Json;
using System.Text;

namespace ContactManagementAssistant.ChatGptClient
{
    class ChatGptClient: IChatGptClient
    {
        private const string endpoint = "https://api.openai.com/v1/completions";
        private const string apiKey = "";

        private HttpClient httpClient;

        public ChatGptClient(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }

        public string Create(string prompt)
        {
            try
            {

                // Create an instance of the OpenAiClient class

                var request = new
                {
                    prompt = prompt,
                    max_tokens = 1000,
                    temperature = 0.5,
                    model = "text-davinci-003"
                };

                string requestJson = JsonConvert.SerializeObject(request);

                // Set the API key in the Authorization header
                this.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                // Make the API request
                var response = this.httpClient.PostAsync(endpoint, new StringContent(requestJson, Encoding.UTF8, "application/json")).Result;

                // Read the response as a string
                string responseJson = response.Content.ReadAsStringAsync().Result;

                // Deserialize the response into a dynamic object
                dynamic responseData = JsonConvert.DeserializeObject(responseJson);

                // Get the text of the first choice in the response
                return responseData.choices[0].text;
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
