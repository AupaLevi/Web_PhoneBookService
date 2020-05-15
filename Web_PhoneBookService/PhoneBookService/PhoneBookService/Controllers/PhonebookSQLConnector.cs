using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PhoneBookService.Models;

namespace PhoneBookService.Controllers
{
    public class PhonebookSQLConnector
    {
        private SqlConnection sqlConnection;
        private string actionResult;


        public PhonebookSQLConnector()
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
                //MessageBox.Show(ex.Message);
                Console.Write("MySqlException :" + ex.Message);
                return false;
            }
        }

        public String InsertPostData(RecordDataObject recordDataObject)
        {
            String sqlString = "INSERT INTO zza_file ( " +
                                    " zza01, zza02, zza03, zza04, zza05, " +
                                    " zza06, zza07, zza08, zza09 " +
                                    ") VALUES ( " +
                                    " @val01, @val02, @val03, @val04, @val05, @val06, " +
                                    " @val07, @val08, @val09                                  " +
                                    ")";
            OpenConnection();
            actionResult = "SUCCESS";

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sqlString;

                sqlCommand.Parameters.AddWithValue("@val01", recordDataObject.Zza01);
                sqlCommand.Parameters.AddWithValue("@val02", recordDataObject.Zza02);
                sqlCommand.Parameters.AddWithValue("@val03", recordDataObject.Zza03);
                sqlCommand.Parameters.AddWithValue("@val04", recordDataObject.Zza04);
                sqlCommand.Parameters.AddWithValue("@val05", recordDataObject.Zza05);
                sqlCommand.Parameters.AddWithValue("@val06", recordDataObject.Zza06);
                sqlCommand.Parameters.AddWithValue("@val07", recordDataObject.Zza07);
                sqlCommand.Parameters.AddWithValue("@val08", recordDataObject.Zza08);
                sqlCommand.Parameters.AddWithValue("@val09", recordDataObject.Zza09);

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
        }//End of Insert Into

        public List<RecordDataObject> GetListAllRecord()
        {
            String sqlString = "SELECT * FROM zza_file" +
                                         " ORDER BY zza01 DESC" +
                                         "";
            List<RecordDataObject> ListAllRecord = new List<RecordDataObject>();

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
                        RecordDataObject recordDataObject = new RecordDataObject();

                        recordDataObject.Zza01 = dataReader.GetString(dataReader.GetOrdinal("Zza01"));
                        recordDataObject.Zza02 = dataReader.GetString(dataReader.GetOrdinal("Zza02"));
                        recordDataObject.Zza03 = dataReader.GetString(dataReader.GetOrdinal("Zza03"));
                        recordDataObject.Zza04 = dataReader.GetString(dataReader.GetOrdinal("Zza04"));
                        recordDataObject.Zza05 = dataReader.GetString(dataReader.GetOrdinal("Zza05"));
                        recordDataObject.Zza06 = dataReader.GetString(dataReader.GetOrdinal("Zza06"));
                        recordDataObject.Zza07 = dataReader.GetString(dataReader.GetOrdinal("Zza07"));
                        recordDataObject.Zza08 = dataReader.GetString(dataReader.GetOrdinal("Zza08"));
                        recordDataObject.Zza09 = dataReader.GetString(dataReader.GetOrdinal("Zza09"));


                        ListAllRecord.Add(recordDataObject);
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

            return ListAllRecord;
        }//End of GetListAllRecord

        public List<RecordDataObject> GetListAllRecordOnDemand(String sqlCriteria)
        {
            String sqlString = "SELECT * FROM zza_file WHERE " + sqlCriteria;
            List<RecordDataObject> ListAllRecord = new List<RecordDataObject>();

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
                        RecordDataObject recordDataObject = new RecordDataObject();

                        recordDataObject.Zza01 = dataReader.GetString(dataReader.GetOrdinal("Zza01"));
                        recordDataObject.Zza02 = dataReader.GetString(dataReader.GetOrdinal("Zza02"));
                        recordDataObject.Zza03 = dataReader.GetString(dataReader.GetOrdinal("Zza03"));
                        recordDataObject.Zza04 = dataReader.GetString(dataReader.GetOrdinal("Zza04"));
                        recordDataObject.Zza05 = dataReader.GetString(dataReader.GetOrdinal("Zza05"));
                        recordDataObject.Zza06 = dataReader.GetString(dataReader.GetOrdinal("Zza06"));
                        recordDataObject.Zza07 = dataReader.GetString(dataReader.GetOrdinal("Zza07"));
                        recordDataObject.Zza08 = dataReader.GetString(dataReader.GetOrdinal("Zza08"));
                        recordDataObject.Zza09 = dataReader.GetString(dataReader.GetOrdinal("Zza09"));


                        ListAllRecord.Add(recordDataObject);
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

            return ListAllRecord;
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
                actionResult = "FAIL" + ex.Message;
            }
            finally
            {
                CloseConnection();
            }

            return actionResult;
        }

        public String ConfirmedEdit(RecordDataObject recordDataObject)
        {
            String sqlString = " UPDATE  zza_file SET zza02 =  @val01, " +
                                         " zza03 = @val02 , " +
                                         " zza04 = @val03 , " +
                                         " zza06 = @val04 , " +
                                         " zza07 = @val05 , " +
                                         " zza05 = @val07 , " +
                                         " zza08 = @val08 , " +
                                         " zza09 = @val09   " +
                                         " WHERE zza01 = @val06 " +
                                         "";

            actionResult = "SUCCESS";

            try
            {
                OpenConnection();

                SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@val01", recordDataObject.Zza02);
                sqlCommand.Parameters.AddWithValue("@val02", recordDataObject.Zza03);
                sqlCommand.Parameters.AddWithValue("@val03", recordDataObject.Zza04);
                sqlCommand.Parameters.AddWithValue("@val04", recordDataObject.Zza06);
                sqlCommand.Parameters.AddWithValue("@val05", recordDataObject.Zza07);
                sqlCommand.Parameters.AddWithValue("@val06", recordDataObject.Zza01);
                sqlCommand.Parameters.AddWithValue("@val07", recordDataObject.Zza05);
                sqlCommand.Parameters.AddWithValue("@val08", recordDataObject.Zza08);
                sqlCommand.Parameters.AddWithValue("@val09", recordDataObject.Zza09);

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
    }
}