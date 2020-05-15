using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PhoneBookService.Models;

namespace PhoneBookService.Controllers
{
    public class PhoneBookSQLConnector
    {
        private SqlConnection sqlConnection;
        private string actionResult;

        public PhoneBookSQLConnector()
        {
            Initializer();
        }

        private void Initializer()
        {
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "192.168.168.207\\SQLEXPRESS02";
            Builder.InitialCatalog = "aupaweb_base";
            Builder.UserID = "sa";
            Builder.Password = "#Aupa=234";
            String sqlConnectionString = Builder.ConnectionString;
            sqlConnection = new SqlConnection(sqlConnectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 53:
                        break;
                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;

                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Console.Write("MySqlException" + ex.Message);
                return false;
            }
        }

        public String InsertPostData(PostDataPhoneBook postDataPhoneBook)
        {
            String sqlString = " Insert into zza_file (  " +
                                       " zza01, zza02 , zza03, zza04, zza05 ,  zza06 , zza07 , zza08 , zza09 " +
                                       "  ) VALUES ( " +
                                       " @val01 , @val02 , @val03 , @val04 , @val05 , @val06 , @val07, @val08 ,@val09" +
                                       ")";
            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                sqlCommand.Parameters.AddWithValue("@val01", postDataPhoneBook.Zza01);
                sqlCommand.Parameters.AddWithValue("@val02", postDataPhoneBook.Zza02);
                sqlCommand.Parameters.AddWithValue("@val03", postDataPhoneBook.Zza03);
                sqlCommand.Parameters.AddWithValue("@val04", postDataPhoneBook.Zza04);
                sqlCommand.Parameters.AddWithValue("@val05", postDataPhoneBook.Zza05);
                sqlCommand.Parameters.AddWithValue("@val06", postDataPhoneBook.Zza06);
                sqlCommand.Parameters.AddWithValue("@val07", postDataPhoneBook.Zza07);
                sqlCommand.Parameters.AddWithValue("@val08", postDataPhoneBook.Zza08);
                sqlCommand.Parameters.AddWithValue("@val09", postDataPhoneBook.Zza09);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                actionResult = "FAIL" + ex.Message;
            }
            finally
            {
                CloseConnection();
            }
            return actionResult;
        }

        public List<PostDataPhoneBook> getPostPhoneBookList()
        {
            String sqlString = "Select *from zza_file" +
                                        " order by zza_file desc" +
                                        "";
            List<PostDataPhoneBook> phoneBookList = new List<PostDataPhoneBook>();

            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand  = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        PostDataPhoneBook postDataPhoneBook = new PostDataPhoneBook();

                        postDataPhoneBook.Zza01 = dataReader.GetString(dataReader.GetOrdinal("Zza01"));
                        postDataPhoneBook.Zza02 = dataReader.GetString(dataReader.GetOrdinal("Zza02"));
                        postDataPhoneBook.Zza03 = dataReader.GetString(dataReader.GetOrdinal("Zza03"));
                        postDataPhoneBook.Zza04 = dataReader.GetString(dataReader.GetOrdinal("Zza04"));
                        postDataPhoneBook.Zza05 = dataReader.GetString(dataReader.GetOrdinal("Zza05"));
                        postDataPhoneBook.Zza06 = dataReader.GetString(dataReader.GetOrdinal("Zza06"));
                        postDataPhoneBook.Zza07 = dataReader.GetString(dataReader.GetOrdinal("Zza07"));
                        postDataPhoneBook.Zza08 = dataReader.GetString(dataReader.GetOrdinal("Zza08"));
                        postDataPhoneBook.Zza09 = dataReader.GetString(dataReader.GetOrdinal("Zza09"));

                        phoneBookList.Add(postDataPhoneBook);
                    }
                }
            }
            catch (Exception ex)
            {
                actionResult = "FAIL" + ex.Message;
            }
            finally
            {
                CloseConnection();
            }
            return phoneBookList;
        }
        public List<PostDataPhoneBook> getPostsListOnDemand(String sqlCriteria)
        {
            String sqlString = "SELECT * FROM aaz_file WHERE " + sqlCriteria;
            List<PostDataPhoneBook> phoneBookList = new List<PostDataPhoneBook>();

            OpenConnection();
            actionResult = "SUCCESS";
            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        PostDataPhoneBook postDataPhoneBook = new PostDataPhoneBook();

                        postDataPhoneBook.Zza01 = dataReader.GetString(dataReader.GetOrdinal("Zza01"));
                        postDataPhoneBook.Zza02 = dataReader.GetString(dataReader.GetOrdinal("Zza02"));
                        postDataPhoneBook.Zza03 = dataReader.GetString(dataReader.GetOrdinal("Zza03"));
                        postDataPhoneBook.Zza04 = dataReader.GetString(dataReader.GetOrdinal("Zza04"));


                        phoneBookList.Add(postDataPhoneBook);
                    }
                }
            }
            catch (Exception ex)
            {
                actionResult = "FAIL" + ex.Message;
            }
            finally
            {
                CloseConnection();
            }

            return phoneBookList;
        }

        public String ConfirmedDelete(String postID)
        {
            String sqlString = "DELETE FROM zza_file WHERE zza01 = '" + postID + "'";
            int deletedRows;
            actionResult = "SUCCESS";
            try
            {
                OpenConnection();

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                deletedRows = sqlCommand.ExecuteNonQuery();
                if (deletedRows == 0)
                {
                    actionResult = "FAIL";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection();
            }

            return actionResult;
        }
    }
}