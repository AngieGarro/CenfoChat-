using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    /*
	 * Clase: Implementacion del CRUD FACTORY del DTO de USER. 
	 */
    public class UserCrudFactory : CrudFactory
    {
        UserMapper mapper;
        public UserCrudFactory() : base()
        {
            mapper = new UserMapper();
            dao = SqlDAO.GetInstance();
        }
        public override void Create(BaseDTO dto)
        {
            var usr = (User)dto;

            var sqlOperation = mapper.GetCreateStatements(usr);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO dto)
        {
            User usr = (User)dto;
            dao.ExecuteProcedure(mapper.DeleteStatements(usr));
        }

        //Falta Implementacion
        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var listUser = new List<T>();
            var sqlOperation = mapper.GetRetriveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objsPojo = mapper.BuildObjects(lstResult);
                foreach (var c in objsPojo)
                {
                    listUser.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listUser;
        }

        public override T RetrieveById<T>(int Id)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveByIdStatements(Id));

            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objsPojo = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objsPojo, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseDTO dto)
        {
            var usr = (User)dto;

            var sqlOperation = mapper.GetUpdateStatements(usr);

            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
