using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateDataService
{
    class ProjectStringPool
    {
        //Oracle Side
        private string oracleConnectionString;
        private string selectEi_omeDataSQL;
        private string deleteEi_omeDataSQL;
        //SQLServer Side
        private string sqlServerEi_omeDataCount;
        private string insSQLServerEi_omeSQL;
        //private string updSQLServerCccxSQL;

        public string getOracleConnectionString(string host, string port, string sid, string user, string pass)
        {
            this.oracleConnectionString = String.Format(
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
                "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                host, port, sid, user, pass);
            return this.oracleConnectionString;
        }
   
        public string getSelectOmeDataSQL()
        {
            this.selectEi_omeDataSQL =
                "SELECT * FROM ome_file " +
                " WHERE ome02 = :val01 " +
                "   AND ome04 = :val02 ";

            return this.selectEi_omeDataSQL;
        }

        public string getDeleteOmeDataSQL()
        {
            this.deleteEi_omeDataSQL = "DELETE FROM ei_ome_file " +
                                     " WHERE ei_ome02 = @val01 " +
                                     "   AND ei_ome04 = @val02 ";
            return this.deleteEi_omeDataSQL;
        }

        public string getsqlServerOmeDataCount()
        {

            this.sqlServerEi_omeDataCount =
                "SELECT COUNT(ei_ome01) FROM ei_ome_file " +
                " WHERE ei_ome01 = ?  " +
                "   AND ei_ome02 = ? " +
                "   AND ei_ome04 = ? ";

            return this.sqlServerEi_omeDataCount;
        }

        public string getInsSQLServerOmeSQL()
        {
            this.insSQLServerEi_omeSQL =
                 "INSERT INTO ei_ome_file (" +
                 "ei_ome01 ,ei_ome02 ,ei_ome04 ,ei_ome05 ,ei_ome06 ,ei_ome07 ,ei_ome08 ,ei_ome09 ,ei_ome10 ,ei_ome11 ,ei_ome12 ,ei_ome13 ,ei_ome14 ,ei_ome15," +
                 "ei_omevoid  ,ei_omevoidu ,ei_omevoidd ,ei_omevoidm ,tc_omevoids ,ei_omecncl ,ei_omecnclu ,ei_omecncld ,ei_omecnclm ,tc_omecncls" +
                 ")VALUES (" +
                 "@val01 ,@val02 ,@val03 ,@val04 ,@val05 ,@val06 ,@val07 ,@val08 ,@val09 ,@val010 ,@val011 ,@val012 ,@val013 ,@val014  ," +
                 "@val015 ,@val016 ,@val017 ,@val018 ,@val019  ,@val020 ,@val021 ,@val022 ,@val023 ,@val024 ,@val025      " +
                 ")";

            return this.insSQLServerEi_omeSQL;
        }

    }
}
