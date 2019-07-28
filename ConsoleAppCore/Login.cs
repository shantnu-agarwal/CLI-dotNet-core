using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace ConsoleAppCore
{
	class Login
	{
		private string password;
		private const string defpass = "shantnu";
		
		public Login()
		{
			/*Console.WriteLine("New Login Object Created.");*/
			FileStream fs = new FileStream("credentials.dat", FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			password = br.ReadString();
			br.Close();
			fs.Close();
		}

		public bool check(string password)
		{
			if (string.Compare(password,this.password)==0)
				return true;
			else
				return false;

		}

		public bool reset()
		{
			try
			{
				FileStream fs = new FileStream("credentials.dat", FileMode.OpenOrCreate, FileAccess.Write);
				BinaryWriter bw = new BinaryWriter(fs);
				bw.Write(defpass);
				bw.Close();
				fs.Close();
				return true;
			}

			catch (Exception e)
			{
				Console.WriteLine("There was an error reseting the password. Error Info: " + e);
				return false;
			} 
		}

		public static void testsql()
		{
			MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;database=schema1;password=welcome");
			con.Open();
			MySqlCommand cmd = new MySqlCommand("select * from abc",con);
			MySqlDataAdapter adptr = new MySqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adptr.Fill(ds,"abc");
			DataTable dt = ds.Tables["abc"];
			foreach (DataRow row in dt.Rows)
			{
				foreach (DataColumn col in dt.Columns)
				{
					Console.Write(row[col] + "\t");
				}

				Console.WriteLine();
			}
			cmd.Dispose();
			con.Close();
			Console.ReadKey();
		}

	}
}
