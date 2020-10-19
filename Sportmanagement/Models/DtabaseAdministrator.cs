using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Sportmanagement.Models
{
    public class DtabaseAdministrator
    { 
        public static SqlConnection con=null;
        public static SqlCommand cmd = null;
        public DtabaseAdministrator()
        {
             con = new SqlConnection(@"Data Source=BABA\SQLEXPRESS;Initial Catalog=VTDemo;Integrated Security=True");
        }
        //function for Insert update delete query
        public  bool InsertUpdateAndDelete(string commond)
        {
                cmd = new SqlCommand(commond, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                    return true;
                else
                    return false;
            
        }
        //function for select operation
        public  DataTable DisplayAllRecords(string commond)
        {
            SqlDataAdapter sa = new SqlDataAdapter(commond, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return dt;
        }
    }
}