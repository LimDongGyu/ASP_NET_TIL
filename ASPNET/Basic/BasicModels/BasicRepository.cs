using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Linq;

namespace BasicModels
{
    public class BasicRepository
    {
        private IDbConnection db;

        public BasicRepository()
        {
            db = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                "ConnectionString"].ConnectionString);    
        }

        /// <summary>
        /// 출력
        /// </summary>
        /// <returns></returns>
        public List<Basic> GetAll()
        {
            //데이터를 출력. 가장 최신글을 위로 올린다.
            string sql = "Select * From Basics Order By Id Desc";
            return db.Query<Basic>(sql).ToList();
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Basic Add(Basic model)
        {
            var sql = @"
                Insert Into Basics (
                    [Name],
                    [Email],
                    [Title],
                    [PostDate],
                    [PostIp], 
                    [Content], 
                    [Password],
                    [ReadCount],
                    [Encoding], 
                    [Homepage]
                ) 
                Values (
                    @Name, 
                    @Email, 
                    @Title, 
                    GetDate(), 
                    @PostIp, 
                    @Content, 
                    @Password, 
                    0, 
                    @Encoding, 
                    @Homepage
                ); " +
                "Select Cast(SCOPE_IDENTITY() As Int);";

            var id = db.Query<int>(sql, model).Single();

            model.Id = id;
            return model;
        }
    }
}
