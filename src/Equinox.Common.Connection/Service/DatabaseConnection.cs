using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Equinox.Common.Connection.Interface;
using Oracle.ManagedDataAccess.Client;

namespace Equinox.Common.Connection.Service
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public OdbcConnection GetOdbcConnection()
        {
            return new OdbcConnection("connectionstringhere");
        }

        public OdbcConnection GetOdbcConnection(string odbcConnectionString)
        {
            return new OdbcConnection(odbcConnectionString);
        }

        public OracleConnection GetOracleConnection()
        {
            return new OracleConnection("connectionstringhere");
        }

        public OracleConnection GetOracleConnection(string oracleConnectionString)
        {
            return new OracleConnection(oracleConnectionString);
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection("connectionstringhere");
        }

        public SqlConnection GetSqlConnection(string sqlConnectionString)
        {
            return new SqlConnection(sqlConnectionString);
        }
    }
}
