using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateDataService
{
    class SQLServerConductor
    {
        private SqlConnection sqlConnection;
        private string actionResult;
        private int deletedRows;

        string sql;

        public SQLServerConductor()
        {
            Initializer();
        }

        private void Initializer()
        {
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "AUPA-EAI\\SQLEXPRESSINV";
            Builder.InitialCatalog = "EI_intermediate";
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
                        Console.WriteLine("40 - 無法開啟至 SQL Server 的連接");
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
        public int DeleteOmeRows(int year, int month)
        {
            sql = "";
            ProjectStringPool stringPool = new ProjectStringPool();
            sql = stringPool.getDeleteOmeDataSQL();

            CommonUntil commonUntil = new CommonUntil();
            //int year = commonUntil.getYear();
            //int month = commonUntil.getMonth() - 1;
            try
            {
                OpenConnection();

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@val01", year);
                sqlCommand.Parameters.AddWithValue("@val02", month);

                this.deletedRows = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                PostalService postalService = new PostalService();
                postalService.SendMail("rick.lu@aupa.com.tw", "Intermediate Data Copier Alert", ex.Message);
                this.deletedRows = 0;
            }
            finally
            {
                CloseConnection();
            }

            return this.deletedRows;
        }

        public List<OraOMEObject> InsertOMESQLServer(List<OraOMEObject> oraOMEs)
        {
            sql = "";
            ProjectStringPool stringPool = new ProjectStringPool();
            List<OraOMEObject> insertedOMEObjects = new List<OraOMEObject>();
            sql = stringPool.getInsSQLServerOmeSQL();

            actionResult = "SUCCESS";
            OpenConnection();
            if (oraOMEs.Count > 0)
            {
                foreach (OraOMEObject ome in oraOMEs)
                {
                    try
                    {
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = sql;

                        sqlCommand.Parameters.AddWithValue("@val01", ome.Ei_ome01);
                        sqlCommand.Parameters.AddWithValue("@val02", ome.Ei_ome02);
                        sqlCommand.Parameters.AddWithValue("@val03", ome.Ei_ome04);
                        sqlCommand.Parameters.AddWithValue("@val04", ome.Ei_ome05);
                        sqlCommand.Parameters.AddWithValue("@val05", ome.Ei_ome06);
                        sqlCommand.Parameters.AddWithValue("@val06", ome.Ei_ome07);
                        sqlCommand.Parameters.AddWithValue("@val07", ome.Ei_ome08);
                        sqlCommand.Parameters.AddWithValue("@val08", ome.Ei_ome09);
                        sqlCommand.Parameters.AddWithValue("@val09", ome.Ei_ome10);
                        sqlCommand.Parameters.AddWithValue("@val10", ome.Ei_ome11);
                        sqlCommand.Parameters.AddWithValue("@val11", ome.Ei_ome12);
                        sqlCommand.Parameters.AddWithValue("@val12", ome.Ei_ome13);
                       

                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("SQLServer Ins CCCx Exception : " + ex.Message);
                        actionResult = "FAIL";
                        break;
                    }
                    finally
                    {
                        if (actionResult == "SUCCESS")
                        {
                            insertedOMEObjects.Add(ome);
                        }
                    }
                }
            }
            return insertedOMEObjects;
        }
    }
}
