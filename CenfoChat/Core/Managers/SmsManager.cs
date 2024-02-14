using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Core.Managers
{
	public class SmsManager
	{
		public void SendSMS(User usr)
		{
			//Misma logica que el envio del correo.
			var msj = "Hello! " + usr.Name + " Welcome to ChatServer - APG";
			PushSMS(msj);

		}

		private void PushSMS(string text)
		{
			// Find your Account SID and Auth Token at twilio.com/console
			// and set the environment variables. See http://twil.io/secure
			string accountSid = "AC49e7a6186bba7a5ddc56c7889fb21372";
			string authToken = "41ae01d81e3458743618dba0e21ef3ce";

			TwilioClient.Init(accountSid, authToken);

			var message = MessageResource.Create(
				body: text,
				from: new Twilio.Types.PhoneNumber("+14175413363"),
				to: new Twilio.Types.PhoneNumber("+50664788712")
			);

		}
	}
}
