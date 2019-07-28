using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleAppCore
{
	class SqlConnect
	{
		MySqlConnection con;
		MySqlCommand cmd;
		public SqlConnect()
		{
			con = new MySqlConnection("server=127.0.0.1;user id=root;database=schema1;password=welcome");
			con.Open();
		}

		public bool TestConnection()
		{
			try
			{
				cmd = new MySqlCommand("show databases;",con);
				return true;
			}
			catch(Exception e)
			{
				return false;
			}
			
		}

		public void ShowAll()
		{
			cmd = new MySqlCommand("select * from abc;", con);
			MySqlDataAdapter adptr = new MySqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adptr.Fill(ds, "abc");
			DataTable dt = ds.Tables["abc"];
			foreach (DataRow row in dt.Rows)
			{
				foreach (DataColumn col in dt.Columns)
				{
					Console.Write(row[col] + "\t");
				}

				Console.WriteLine();
			}
			
			Console.ReadKey();
		}
		~SqlConnect()
		{
			cmd.Dispose();
			con.Close();
		}
	}
}
