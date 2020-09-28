using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectStringPool projectStringPool = new ProjectStringPool();
            OracleDBConductor oracleDBConductor = new OracleDBConductor();
            DataTable dataTable;
            OraOMEObject oraOmeObject;

            List<OraOMEObject> insertSQLServerOmeObjects;
            List<OraOMEObject> goodSQLServerOmeObjects;
            List<OraOMEObject> insertedOmeObjects;

            //string ogaSQLServerResult;
            string oraResult;
            int dataCount;
            int deletedRows;

            try
            {
                string oraSQLString = projectStringPool.getSelectOmeDataSQL();
                //int month = new CommonUntil().getMonth();
                //int year = new CommonUntil().getYear();

                int month = 3;
                int year = 2020;
                int last_month = month - 1;
                if (last_month == 0)
                {
                    year = year - 1;
                    last_month = 12;
                }
                int last_two_month = last_month - 1;

                //for (int i = last_two_month; i <= last_month; i++)
                //{
                dataTable = oracleDBConductor.GetDataTable(oraSQLString, year, month);
                oraResult = "";

                insertSQLServerOmeObjects = new List<OraOMEObject>();


                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        oraOmeObject = new OraOMEObject();
                        oraResult = "Y";

                        try
                        {
                            oraOmeObject.Ei_ome01 = row[dataTable.Columns["ome01"]].ToString();
                            oraOmeObject.Ei_ome02 = row[dataTable.Columns["ome02"]].ToString();
                            oraOmeObject.Ei_ome04 = row[dataTable.Columns["ome04"]].ToString();
                            oraOmeObject.Ei_ome05 = row[dataTable.Columns["ome42"]].ToString();
                            oraOmeObject.Ei_ome06 = row[dataTable.Columns["ome43"]].ToString();
                            oraOmeObject.Ei_ome07 = row[dataTable.Columns["ome44"]].ToString();
                            oraOmeObject.Ei_ome08 = row[dataTable.Columns["ome16"]].ToString();
                            oraOmeObject.Ei_ome09 = row[dataTable.Columns["ome21"]].ToString();
                            oraOmeObject.Ei_ome10 = row[dataTable.Columns["ome211"]].ToString();
                            oraOmeObject.Ei_ome11 = row[dataTable.Columns["ome59"]].ToString();
                            oraOmeObject.Ei_ome12 = row[dataTable.Columns["ome59x"]].ToString();
                            oraOmeObject.Ei_ome13 = row[dataTable.Columns["ome59t"]].ToString();

                            
                            //oraOmeObject.TC_OME06 = row[dataTable.Columns["OME43"]].ToString();
                            //oraOmeObject.TC_OMEVOID = row[dataTable.Columns["ome44"]].ToString();
                            //oraOmeObject.TC_OMEVOIDU = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMEVOIDD = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMEVOIDT = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMEVOIDM = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMEVOIDS = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMECNCL = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMECNCLU = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMECNCLD = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMECNCLT = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMECNCLM = row[dataTable.Columns["ome09"]].ToString();
                            //oraOmeObject.TC_OMECNCLS = row[dataTable.Columns["ome09"]].ToString();

                        }
                        catch (Exception ex)
                        {
                            oraResult = "N";
                            Console.WriteLine("Foreach Exception:" + ex.Message);
                            PostalService postalService = new PostalService();
                            postalService.SendMail("rick.lu@aupa.com.tw", "Intermediate Data Copier Alert", ex.Message);
                            break;
                        }
                        finally
                        {
                            if (oraResult == "Y")
                            {
                                //SQLServerDataSecuricor dataSecuricor = new SQLServerDataSecuricor();
                                //dataCount = 0;
                                //dataCount = dataSecuricor.SelectCCCxRowCounts(
                                //    oraCCCxObject.Tc_cccx01, oraCCCxObject.Tc_cccx02, oraCCCxObject.Tc_cccx03);
                                //if (dataCount == 0)
                                //{
                                insertSQLServerOmeObjects.Add(oraOmeObject);
                                //}
                            }
                        }//End of try-catch-finally
                        //}//End of foreach
                    }//End of if else
                     //ogaSQLServerResult = "FAILED";
                    goodSQLServerOmeObjects = new List<OraOMEObject>();
                    insertedOmeObjects = new List<OraOMEObject>();

                    if (insertSQLServerOmeObjects.Count > 0)
                    {

                        SQLServerConductor sqlServerConductor = new SQLServerConductor();

                        deletedRows = sqlServerConductor.DeleteOmeRows(year, month);
                        insertedOmeObjects = sqlServerConductor.InsertOMESQLServer(insertSQLServerOmeObjects);
                    }

                    dataCount = 0;
                    dataCount = insertedOmeObjects.Count;

                }

            }
            catch (Exception ex)
            {
                Console.Write("Exception : " + ex.Message);
                return;
            }

        }
    }
}
