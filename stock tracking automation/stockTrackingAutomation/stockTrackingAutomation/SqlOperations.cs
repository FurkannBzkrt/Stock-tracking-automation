﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace stockTrackingAutomation
{
   public class SqlOperations
    {
      public static SqlConnection connection = new SqlConnection("Data Source=LAPTOP-26MR7RO5;Initial Catalog=Stok_Takip;Integrated Security=True");
       public static void CheckConnection(SqlConnection tempConnection)
        {
            if(tempConnection.State == ConnectionState.Closed)
            {
                tempConnection.Open();
            }
            else
            {

            }
        }
    
    }
}
