using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;


namespace pruebaGoogleCalendar.Persistencia
{
    public class Conn
    {
        string connStr;

        private SqlConnection connection;
        private SqlTransaction currentTransaction;

        public Conn(string connStrInput)
        {
            connStr = connStrInput;
        }

        public SqlConnection GetConnection()
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                if (connection != null)
                    connection.Dispose();
                connection = new SqlConnection(connStr);
                connection.Open();
            }
            return connection;
        }

        private bool ConnectionActive { get { return connection != null; } }

        private SqlCommand CreateCommand(string sql)
        {
            SqlConnection conn = GetConnection();

            return currentTransaction != null
                ? new SqlCommand(sql, conn, currentTransaction)
                : new SqlCommand(sql, conn);
        }
        /// <summary>
        /// Devuelve una tabla con los resultados de la query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetTable(string query)
        {
            DataTable tbl = new DataTable();


            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    tbl.Load(cmd.ExecuteReader());
                    return tbl;
                }
            }


        }

        /// <summary>
        /// devuelve el primer valor de la primera columna
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public object GetScalar(string query)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
        public DataTable GetTable(string query, int offset, int size)
        {
            DataTable tbl = new DataTable();

            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(offset, size, tbl);
                    return tbl;
                }
            }
        }


        public int GetLastInsertId(string table)
        {
            SqlCommand cmd = CreateCommand(String.Format("SELECT IDENT_CURRENT('{0}')", table));
            SqlDataReader reader = cmd.ExecuteReader();


            int id = 0;
            if (reader.Read())
            {
                id = Convert.ToInt32(reader.GetValue(0));
            }
            reader.Close();

            return id;

        }
        /// <summary>
        /// Ejecuta una query y devuelve la cantidad de registros afectados.
        /// </summary>
        public int SqlExecute(string sql)
        {


            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    return cmd.ExecuteNonQuery();
                }
            }


        }

        /// <summary>
        /// Ejecuta una serie de qry's dentro de una transaccion.
        /// </summary>
        /// <param name="sql"></param>
        public bool SqlExecuteTran(List<string> sql)
        {
            var returnValue = false;
            SqlCommand cmd;
            try
            {
                foreach (var item in sql)
                {
                    cmd = CreateCommand(item);
                    cmd.ExecuteNonQuery();
                }
                returnValue = true;
            }
            catch (Exception ex)
            {
                //TODO: LOG
                throw new Exception(ex.Message);
            }
            return returnValue;
        }

        private void DoClose()
        {
            if (ConnectionActive)
            {
                CommitTx();
                connection.Close();
            }
        }

        public void Close()
        {
            if (connection != null)
                connection.Close();
            CommitTx();
        }

        public SqlTransaction BeginTx()
        {
            if (currentTransaction == null)
            {
                currentTransaction = GetConnection().BeginTransaction();
            }

            return currentTransaction;
        }

        public void CommitTx()
        {
            if (currentTransaction != null)
            {
                try
                {
                    currentTransaction.Commit();
                }
                finally
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

        public void RollbackTx()
        {
            if (currentTransaction != null)
            {
                try
                {
                    currentTransaction.Rollback();
                }
                finally
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }
        }

    }
}