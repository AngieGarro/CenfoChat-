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
	 * Clase: Implementacion del CRUD FACTORY del DTO de ROOM. 
	 */
	public class RoomCrudFactory : CrudFactory
	{
		RoomMapper mapper;

		public RoomCrudFactory() : base()
		{
			mapper = new RoomMapper();
			dao = SqlDAO.GetInstance();
		}

		public override void Create(BaseDTO dto)
		{
			var rm = (Room)dto;

			var sqlOperation = mapper.GetCreateStatements(rm);

			dao.ExecuteProcedure(sqlOperation);
		}

		public override void Delete(BaseDTO dto)
		{
			Room rm = (Room)dto;
			dao.ExecuteProcedure(mapper.DeleteStatements(rm));
		}

		//No Implementado.
		public override T Retrieve<T>()
		{
			throw new NotImplementedException();
		}

		public override List<T> RetrieveAll<T>()
		{
			var listRooms = new List<T>();
			var sqlOperation = mapper.GetRetriveAllStatement();
			var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
			var dic = new Dictionary<string, object>();
			if (lstResult.Count > 0)
			{
				var objsPojo = mapper.BuildObjects(lstResult);
				foreach (var c in objsPojo)
				{
					listRooms.Add((T)Convert.ChangeType(c, typeof(T)));
				}
			}

			return listRooms;
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
			var rm = (Room)dto;

			var sqlOperation = mapper.GetUpdateStatements(rm);

			dao.ExecuteProcedure(sqlOperation);
		}
	}
}
