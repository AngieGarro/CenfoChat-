using DataAccess.CRUD;
using DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class RoomManager
	{
		public RoomManager() { }

		public void CreateRoom(Room rm)
		{
			var crud = new RoomCrudFactory();
			crud.Create(rm);
		}

		public void DeleteRoom(Room rm)
		{
			var crud = new RoomCrudFactory();
			crud.Delete(rm);
		}

		public void UpdateRoom(Room rm)
		{
			var crud = new RoomCrudFactory();
			crud.Update(rm);
		}

		public List<Room> RetrieveAll()
		{
			var crudFactory = new RoomCrudFactory();
			var LstRooms = crudFactory.RetrieveAll<Room>();

			return LstRooms;
		}

		public T RetrieveById<T>(int Id)
		{
			var crud = new RoomCrudFactory();
			var rm = crud.RetrieveById<T>(Id);

			return rm;
		}

		//Data Users SERVIDOR
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
