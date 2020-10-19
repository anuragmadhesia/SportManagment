using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Sportmanagement.Models
{
    public class ConnectionManager
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public ConnectionManager()
        {
            con = new SqlConnection(@"Data Source=BABA\SQLEXPRESS;Initial Catalog=ASP03;Integrated Security=True");
        }
        public bool MyInsertUpdateDelete(string command)
        {
            cmd = new SqlCommand(command,con);
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            int n=cmd.ExecuteNonQuery();//1
            if (n > 0)
                return true;
            else
                return false;
        }
        public DataTable DisplayAllData(string command)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(command,con);
            sa.Fill(dt);
            return dt;
        }
    }
}