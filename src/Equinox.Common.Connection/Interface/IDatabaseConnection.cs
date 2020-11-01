using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using Oracle.ManagedDataAccess.Client;

namespace Equinox.Common.Connection.Interface
{
    public interface IDatabaseConnection
    {
        SqlConnection GetSqlConnection();
        SqlConnection GetSqlConnection(string sqlConnectionString);
        OdbcConnection GetOdbcConnection();
        OdbcConnection GetOdbcConnection(string odbcConnectionString);
        OracleConnection GetOracleConnection();
        OracleConnection GetOracleConnection(string oracleConnectionString);
    }
}
