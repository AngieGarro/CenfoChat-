using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class MessageManager
	{
		public MessageManager() { }

		public void SendMessage(Message Msj)
		{
            //Registro API
			var rm = new RESTManager();
			rm.PostToApiMessage(Msj).Wait();

            //Guardo en la BD
            var crud = new MessageCrudFactory();
            crud.Create(Msj);
		}

		public void DeleteMessage(Message sms)
		{
			var crud = new MessageCrudFactory();
			crud.Delete(sms);
		}

		public void UpdateMessage(Message sms)
		{
			var crud = new MessageCrudFactory();
			crud.Update(sms);
		}

		public List<Message> RetrieveAll()
		{
			var crudFactory = new MessageCrudFactory();
			var LstMessage = crudFactory.RetrieveAll<Message>();

			return LstMessage;
		}

		public T RetrieveById<T>(int Id)
		{
				var crud = new MessageCrudFactory();
				var Msj = crud.RetrieveById<T>(Id);

				return Msj;
		}

	}
}
