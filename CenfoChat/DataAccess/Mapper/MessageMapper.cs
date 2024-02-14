using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
	/*
	 * Mapper del DTO Message: Mapeo entre SQL Y POO.
	 */
	public class MessageMapper : ISqlStatements, IObjectMapper
	{
		public BaseDTO BuildObject(Dictionary<string, object> row)
		{
			var sms = new Message()
			{
				Id  = (int)row["Id"],
				From = (string)row["From"],
				To = (string)row["To"],
				Text = (string)row["Text"],
				CreatedDate = (DateTime)row["CreatedDate"],
				WordNumbers = (int)row["WordNumbers"]
			};

			return sms;
		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();

			foreach (var row in lstRows)
			{
				var message = BuildObject(row);
				lstResults.Add(message);
			}

			return lstResults;
		}

		public SqlOperation DeleteStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation { ProcedureName = "DEL_MESSAGE_PR" };

			var sms = (Message)Dto;
			operation.AddIntParam("ID", sms.Id);

			return operation;
		}

		public SqlOperation GetCreateStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation()
			{
				ProcedureName = "CRE_MESSAGE_PR"
			};

			var sms = (Message)Dto;
			operation.AddVarcharParam("FROM", sms.From);
			operation.AddVarcharParam("TO", sms.To);
			operation.AddVarcharParam("TEXT", sms.Text);
			operation.AddIntParam("WORD_NUMBERS", sms.WordNumbers);

			return operation;
		}

		public SqlOperation GetRetrieveByIdStatements(int Id)
		{
			var operation = new SqlOperation { ProcedureName = "RET_BY_ID_MESSAGE_PR" };

			operation.AddIntParam("ID", Id);
			return operation;
        } 

		public SqlOperation GetRetriveAllStatement()
		{
			var operation = new SqlOperation { ProcedureName = "RET_ALL_MESSAGE_PR" };
			return operation;

		}

		public SqlOperation GetUpdateStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation()
			{
				ProcedureName = "UPD_MESSAGE_PR"
			};

			var sms = (Message)Dto;
			operation.AddIntParam("ID", sms.Id);
			operation.AddVarcharParam("FROM", sms.From);
			operation.AddVarcharParam("TO", sms.To);
			operation.AddVarcharParam("TEXT", sms.Text);
			operation.AddIntParam("WORD_NUMBERS", sms.WordNumbers);

			return operation;
		}
	}
}
