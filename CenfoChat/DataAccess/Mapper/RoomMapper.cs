using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
	/*
	 * Mapper del DTO Room: Mapeo entre SQL Y POO.
	 */
	public class RoomMapper : ISqlStatements, IObjectMapper
	{
		public BaseDTO BuildObject(Dictionary<string, object> row)
		{
			var rm = new Room()
			{
				Id = (int)row["Id"],
				RoomName = (string)row["RoomName"],
				Description = (string)row["Description"],
				RoomCreator = (string)row["RoomCreator"],
				CreatedDate = (DateTime)row["CreatedDate"],
				UserName = (string)row["UserName"],
				Status = (string)row["Status"],
				CountUser = (int)row["CountUser"],
				RoomTheme = (string)row["RoomTheme"],
				ImageUrl = (string)row["ImageUrl"],
				UltimateDate = (DateTime)row["UltimateDate"]
			};

			return rm;
		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();

			foreach (var row in lstRows)
			{
				var room = BuildObject(row);
				lstResults.Add(room);
			}

			return lstResults;
		}

		public SqlOperation DeleteStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation { ProcedureName = "DEL_ROOM_PR" };

			var rm = (Room)Dto;
			operation.AddIntParam("ID", rm.Id);

			return operation;
		}

		public SqlOperation GetCreateStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation()
			{
				ProcedureName = "CRE_ROOM_PR"
			};

			var rm = (Room)Dto;
			operation.AddVarcharParam("ROOM_NAME", rm.RoomName);
			operation.AddVarcharParam("DESCRIPTION", rm.Description);
			operation.AddVarcharParam("ROOM_CREATOR", rm.RoomCreator);
			operation.AddVarcharParam("STATUS", rm.Status);
			operation.AddIntParam("COUNT_USER", rm.CountUser);
			operation.AddVarcharParam("ROOM_THEME", rm.RoomTheme);
			operation.AddVarcharParam("IMAGE_URL", rm.ImageUrl);

			return operation;
		}

		public SqlOperation GetRetrieveByIdStatements(int Id)
		{
			var operation = new SqlOperation 
			{ 
				ProcedureName = "RET_BY_ID_ROOM_PR" 
			};

			operation.AddIntParam("ID", Id);
			return operation;
		}

		public SqlOperation GetRetriveAllStatement()
		{
			var operation = new SqlOperation 
			{ 
				ProcedureName = "RET_ALL_ROOM_PR" 
			};

			return operation;
		}

		public SqlOperation GetUpdateStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation()
			{
				ProcedureName = "UPD_ROOM_PR"
			};

			var rm = (Room)Dto;
			operation.AddVarcharParam("ROOM_NAME", rm.RoomName);
			operation.AddVarcharParam("DESCRIPTION", rm.Description);
			operation.AddVarcharParam("STATUS", rm.Status);
			operation.AddIntParam("COUNT_USER", rm.CountUser);
			operation.AddVarcharParam("ROOM_THEME", rm.RoomTheme);
			operation.AddVarcharParam("IMAGE_URL", rm.ImageUrl);

			return operation;

		}
	}
}
