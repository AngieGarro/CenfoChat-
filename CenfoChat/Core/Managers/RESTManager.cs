using DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class RESTManager
    {

        // Post para User
        public async Task PostToApi(User user)
        {
            var url = "https://cenfochatserver.azurewebsites.net/api/ChatServer/Create";

            var httpClient = new HttpClient();

            // Serializar el objeto usuario a JSON
            string jsonUser = JsonConvert.SerializeObject(user);

            // Crear el contenido de la solicitud HTTP
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

        }

		// Post para SendMessage
		public async Task PostToApiMessage(Message MSJ)
		{
			var url = "https://cenfochatserver.azurewebsites.net/api/ChatServer/SendMessage";

			var httpClient = new HttpClient();

			// Serializar el objeto usuario a JSON
			string jsonUser = JsonConvert.SerializeObject(MSJ);

			// Crear el contenido de la solicitud HTTP
			var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync(url, content);

			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadAsStringAsync();
				throw new Exception(error);
			}

		}
	
		public async Task<List<User>> GetToApi()
        {
            var url = "https://cenfochatserver.azurewebsites.net/api/ChatServer/RetrieveAll";

            var httpClient = new HttpClient();

            var listUser = new List<User>();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                listUser = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return listUser;
        }

    }
}
