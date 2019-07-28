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


	}
}
