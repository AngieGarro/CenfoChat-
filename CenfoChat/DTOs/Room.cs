using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Room : BaseDTO
	{
		public int Id { get; set; }
		public string RoomName { get; set; }

		public string? Description { get; set; }

		public string RoomCreator { get; set; }

		public DateTime CreatedDate { get; set; }

		//Implementacion por nombre o ID.
		//public List<User> UserList { get; set; }

		public string? UserName { get; set; }

		//Public or Private
		public string Status { get; set; }

		//Cantidad de usuarios en la sala.
		public int CountUser { get; set; }

		public string RoomTheme { get; set; }

		public string? ImageUrl { get; set; }

		public DateTime UltimateDate { get; set; }
	}
}
