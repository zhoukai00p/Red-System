using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Dapper;
using Red_System.Models;
using Red_System.Models.Entities;

namespace Red_System.Helper
{
    public class DatabaseHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        public static Admin Login(string Username, string Password)
        {
            var Professore = new Admin();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Admin where Username = @Username and Password=@Password";
                Professore = connection.Query<Admin>(sql, new { Username, Password }).FirstOrDefault();
            }
            return Professore;
        }

        public static Classi InsertClasse(Classi classe)
        {
            try
            {
               /* var cerca = "SELECT C.Numero,C.Sezione FROM Classi C WHERE Numero=@Numero AND Sezione=@Sezione";
                var controlla = new Classi();

                using (var connection = new MySqlConnection(connectionString))
                {
                    controlla = connection.Query<Classi>(cerca, classe).FirstOrDefault();
                }

                if(controlla != null )
                {*/
                        using (var connection = new MySqlConnection(connectionString))
                        {
                            var sql = "INSERT INTO Classi (ID,Numero,Sezione,Indirizzo)" +
                                " VALUES (null,@Numero,@Sezione,@Indirizzo); " +
                                " SELECT CAST(LAST_INSERT_ID() as int ) ";
                            classe.ID = connection.Query<int>(sql, classe).FirstOrDefault();
                        }
                    }
                //}
            /*
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "INSERT INTO ProfessoreClasse (ID, IDClasse)"+
                    "VALUES (null,@ID);"+
                    "SELECT CAST(LAST_INSERT_ID() as int )"
                }
                */
                catch (Exception ex)
                {
                    //errore
                    return null;
                }
                return classe;
        }


    }
}