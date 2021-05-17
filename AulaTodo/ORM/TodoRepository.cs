using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace ORM
{
    public class TodoRepository : RepositoryConector, Interfaces.ITodoRepository
    {
        public TodoRepository(IConfiguration config)
            : base(config)
        {

        }

        public void Add(ToDo obj)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Tarefa", obj.Tarefa);

            string sql = "insert into Todo values (@Tarefa)";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql, param);
            }
        }

        public ToDo Get(int id)
        {
            string sql = $"select * from Todo where Id = {id}";
            
            using (var con = new SqlConnection(base.GetConnection()))
            {
                return con.Query<ToDo>(sql).FirstOrDefault();
            }
        }
        public IEnumerable<ToDo> GetAll()
        {
            IEnumerable<ToDo> retorno;
            string sql = "select * from Todo";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                retorno = con.Query<ToDo>(sql);
            }

            return retorno;
        }

        public void Remove(ToDo obj)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo obj)
        {
            throw new NotImplementedException();
        }
    }
}
