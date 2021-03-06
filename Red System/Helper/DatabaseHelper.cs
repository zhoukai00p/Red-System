﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Dapper;
using Red_System.Models;
using Red_System.Models.Entities;
using System.Diagnostics;

namespace Red_System.Helper
{
    public class DatabaseHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        public static Professore LoginProfessore(string Username, string Password)
        {
            var Professore = new Professore();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Professore where Username = @Username and Password=@Password";
                Professore = connection.Query<Professore>(sql, new { Username, Password }).FirstOrDefault();
            }

            return Professore;
        }

        public static Password LoginStudente(string Password)
        {
            var Studente = new Password();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Password where descrizione=@Password";
                Studente = connection.Query<Password>(sql, new { Password }).FirstOrDefault();
            }

            return Studente;
        }

        public static Classe InsertClasse(Classe classe)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "INSERT INTO Classe (ID,Numero,Sezione,Indirizzo)" +
                        " VALUES (null,@Numero,@Sezione,@Indirizzo); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    classe.ID = connection.Query<int>(sql, classe).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }

            return classe;
        }

        public static Studente InsertStudente(Studente studente, int classeid)
        {
            try
            {
                studente.IDClasse = classeid;
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "INSERT INTO STUDENTE (ID,Nome,Cognome,IDClasse)" +
                        " VALUES (null,@Nome,@Cognome,@IDClasse); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    studente.ID = connection.Query<int>(sql, studente).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }

            return studente;
        }

        public static DomandaChiusa InsertDomandeChiuse(DomandaChiusa domande,int IDVerifica)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    domande.IDVerifica = IDVerifica;
                    var sql = "INSERT INTO DomandaChiusa (ID,Domanda,OpzioneA,OpzioneB,OpzioneC,OpzioneD,OpzioneE,RispGiustaA,RispGiustaB,RispGiustaC,RispGiustaD,RispGiustaE,Punteggio,IDVerifica)" +
                        " VALUES (null,@Domanda,@OpzioneA,@OpzioneB,@OpzioneC,@OpzioneD,@OpzioneE,@RispGiustaA,@RispGiustaB,@RispGiustaC,@RispGiustaD,@RispGiustaE,@Punteggio,@IDVerifica); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    domande.ID = connection.Query<int>(sql, domande).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
                Debug.WriteLine(ex.Message);
                return null;
            }

            return verifica;
        }

        public static Password InsertPassword(Password password)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "INSERT INTO password (ID,Descrizione,IDStudente,IDVerifica)" +
                        " VALUES (null,@Descrizione,@IDStudente,@IDVerifica); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    password.ID = connection.Query<int>(sql, password).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }

            return password;
        }

        public static RispostaChiusa InsertRispostaChiusa(RispostaChiusa rispostaChiusa)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "INSERT INTO RispostaChiusa (ID,RispStudenteA,RispStudenteB,RispStudenteC,RispStudenteD,RispStudenteE,IDstudente,IDdomanda)" +
                        " VALUES (null,@RispStudenteA,@RispStudenteB,@RispStudenteC,@RispStudenteD,@RispStudenteE,@IDstudente,@IDdomanda); " +
                        " SELECT CAST(LAST_INSERT_ID() as int ) ";
                    rispostaChiusa.ID = connection.Query<int>(sql, rispostaChiusa).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return rispostaChiusa;
        }

        public static List<Classe> GetAllClasse()
        {
            var ListaClasse = new List<Classe>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Classe";
                ListaClasse = connection.Query<Classe>(sql).ToList();
            }

            return ListaClasse;
        }

        public static List<Verifica> GetAllVerifica()
        {
            var ListaVerifiche = new List<Verifica>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Verifica";
                ListaVerifiche = connection.Query<Verifica>(sql).ToList();
            }

            return ListaVerifiche;
        }

        public static List<DomandaChiusa> GetAllDomandaChiusaByVerifica(int idverifica)
        {
            var listaDomandaChiusa = new List<DomandaChiusa>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "select * from domandachiusa where idverifica = @idverifica";
                    listaDomandaChiusa = connection.Query<DomandaChiusa>(sql, new { idverifica }).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            return listaDomandaChiusa;
        }

        public static Verifica GetVerificaById(int id)
        {
            var verifica = new Verifica();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Verifica where id = @id";
                verifica = connection.Query<Verifica>(sql, new { id }).FirstOrDefault();
            }

            return verifica;
        }

        public static Classe GetClasseById(int id)
        {
            var classe = new Classe();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Classe where id=@id";
                classe = connection.Query<Classe>(sql, new { id }).FirstOrDefault();
            }

            return classe;
        }

        public static List<Studente> GetAllStudenteByIDClasse(int IDClasse)
        {
            var studenti = new List<Studente>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = " select * from studente where idclasse=@IDClasse";
                    studenti = connection.Query<Studente>(sql, new { IDClasse }).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            return studenti;
        }

        public static List<Classe> GetAllClasseByIDVerifica(int IDVerifica)
        {
            var classi = new List<Classe>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var sql = "select c.Numero ,c.Sezione ,c.Indirizzo from classe c, studente s, domandachiusa d, rispostachiusa r where d.IDVerifica = @IDVerifica AND d.ID = r.IDDomanda AND s.ID = r.IDstudente AND s.IDClasse = c.ID group by (c.ID);";
                    classi = connection.Query<Classe>(sql, new { IDVerifica }).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            return classi;
        }

        public static List<Password> GetAllPassword()
        {
            var listaPassword = new List<Password>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "select * from Password";
                listaPassword = connection.Query<Password>(sql).ToList();
            }

            return listaPassword;
        }

        public static Password RemovePassword(Password password)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var sql = "Delete from Password where Id = @Id";
                password = connection.Query<Password>(sql, new { password }).FirstOrDefault();
            }
            return password;
        }

    }
}