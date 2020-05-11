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

        public static Professore Login(string Username, string Password)
        {
            var Professore = new Professore();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Professore where Username = @Username and Password=@Password";
                Professore = connection.Query<Professore>(sql, new { Username, Password }).FirstOrDefault();
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
                            var sql = "INSERT INTO Classe (ID,Numero,Sezione,Indirizzo)" +
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

        public static Studente InsertStudente(Studente studente, int classeid)
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
                studente.IDClasse = classeid;
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "INSERT INTO STUDENTE (ID,Nome,Cognome,IDClasse)" +
                        " VALUES (null,@Nome,@Cognome,@IDClasse); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    studente.ID = connection.Query<int>(sql, studente).FirstOrDefault();
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
            return studente;
        }

        public static DomandaChiusa InsertDomandeChiuse(DomandaChiusa domande)
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
                    var sql = "INSERT INTO DomandaChiusa (ID,Domanda,OpzioneA,OpzioneB,OpzioneC,OpzioneD,OpzioneE,IDStudente,IDProfessore)" +
                        " VALUES (null,@Domanda,@OpzioneA,@OpzioneB,@OpzioneC,@OpzioneD,@OpzioneE,null,null); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    domande.ID = connection.Query<int>(sql, domande).FirstOrDefault();
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
            return domande;
        }

        public static Verifica InsertVerifica(Verifica verifica)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "INSERT INTO Verifica (ID,Nome,Descrizione,IDProfessore)" +
                        " VALUES (null,@Nome,@Descrizione,@IDProfessore); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    verifica.ID = connection.Query<int>(sql, verifica).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //errore
                return null;
            }
            return verifica;
        }

        public static List<Classi> GetAllClassi()
        {
            var ListaClasse = new List<Classi>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Classe";
                ListaClasse = connection.Query<Classi>(sql).ToList();
            }
            return ListaClasse;
        }

        public static List<DomandaChiusa> GetAllDomandeChiuse()
        {
            var ListaDomandeChiuse = new List<DomandaChiusa>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from DomandaChiusa";
                ListaDomandeChiuse = connection.Query<DomandaChiusa>(sql).ToList();
            }
            return ListaDomandeChiuse;
        }

    }
}