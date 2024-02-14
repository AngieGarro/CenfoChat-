using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class UserManager
    {
        public UserManager() { }
        public void Create(User user)
        {
            if (user.Age < 18)
            {
                throw new Exception("The User is older 18 year");
            }

            //Data servidor
            //var rm = new RESTManager();
            //rm.PostToApi(user); /**Wait()*/

            //Data BD
			var crud = new UserCrudFactory();
			crud.Create(user);

			//Para envio de sms de bienvenida.
			var sms = new SmsManager();
            sms.SendSMS(user);
            //Para envio de Email.
            //var em = new EmailManager();
            //em.SendEmail(user);
        }

        public void DeleteUser(User usr)
        {
            var crud = new UserCrudFactory();
            crud.Delete(usr);
        }

        public void UpdateUser(User usr)
        {
            var crud = new UserCrudFactory();
            crud.Update(usr);
        }
        public List<User> RetrieveAll()
        {
            var crudFactory = new UserCrudFactory();
            var LstUsers = crudFactory.RetrieveAll<User>();

            return LstUsers;
        }
        public T RetrieveById<T>(int Id)
        {
            var crud = new UserCrudFactory();
            var usr = crud.RetrieveById<T>(Id);

            return usr;
        }
    }
}
