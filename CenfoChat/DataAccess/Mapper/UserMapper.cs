using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Mapper
{
    public class UserMapper
    {
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var usr = new User()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                LastName = (string)row["LastName"],
                Email = (string)row["Email"],
                CreateDate = (DateTime)row["CreateDate"],
                UserCode = (string)row["UserCode"],
                OwnedBy = (string)row["OwnedBy"],
                PhoneNumber = (string)row["PhoneNumber"]
            };

            return usr;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;
        }

        public SqlOperation DeleteStatements(BaseDTO Dto)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var usr = (User)Dto;
            operation.AddIntParam("ID", usr.Id);

            return operation;
        }

        public SqlOperation GetCreateStatements(BaseDTO Dto)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "CRE_USER_PR"
            };

            var usr = (User)Dto;
            operation.AddVarcharParam("NAME", usr.Name);
            operation.AddVarcharParam("LAST_NAME", usr.LastName);
            operation.AddVarcharParam("EMAIL", usr.Email);
            operation.AddVarcharParam("USER_CODE", usr.UserCode);
            operation.AddVarcharParam("OWNED_BY", usr.OwnedBy);
            operation.AddVarcharParam("PHONE_NUMBER", usr.PhoneNumber);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatements(int Id)
        {
            var operation = new SqlOperation { ProcedureName = "RET_BY_ID_USER_PR" };

            operation.AddIntParam("ID", Id);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USER_PR" };
            return operation;

        }

        public SqlOperation GetUpdateStatements(BaseDTO Dto)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "UPD_USER_PR"
            };

            var usr = (User)Dto;
            operation.AddVarcharParam("NAME", usr.Name);
            operation.AddVarcharParam("LAST_NAME", usr.LastName);
            operation.AddVarcharParam("EMAIL", usr.Email);
            operation.AddVarcharParam("USER_CODE", usr.UserCode);
            operation.AddVarcharParam("OWNED_BY", usr.OwnedBy);
            operation.AddVarcharParam("PHONE_NUMBER", usr.PhoneNumber);

            return operation;
        }
    }
}
