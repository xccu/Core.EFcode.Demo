using DataAccess;
using Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockData
{
    public class MockMySqlContext
    {

        public static MySqlContext GetContext()
        {
            var dbConnection = new SqliteConnection("Data Source=:memory:");
            dbConnection.Open();


            var options = new DbContextOptionsBuilder<MySqlContext>()
                .UseSqlite(dbConnection)
                .Options;

            var context  = new MySqlContext(options);
            
            Fillup(context);
            return context;
        }

        public static void Fillup(MySqlContext context)
        {
            context.Database.EnsureCreated();
            context.User.AddRange(generateUsers());
            context.SaveChanges();
        }

        private static List<User> generateUsers()
        {
            return new List<User>() 
            {
                new User
                {
                    id=1,
                    name = "喜羊羊",
                    age = 12,
                    sex = "male",
                    password= "123"
                },
                new User
                {
                    id = 2,
                    name = "灰太狼",
                    age = 34,
                    sex = "male",
                    password = "456"
                }
            };
        }
    }
}
