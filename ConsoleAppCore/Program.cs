using System;

namespace ConsoleAppCore
{
	class Program
	{
		const double pi = Math.PI;
		static int logincnt=0;

		private static void startLogin()
		{
			Console.Write("What's your password? : ");
			String password = "";
			logincnt++;
			
			char inx = Convert.ToChar(Console.Read());
			while (inx >= 'a' && inx <='z')
			{
				password += inx;
				inx = Convert.ToChar(Console.Read());
			}
			Login login = new Login();
			if (!login.check(password))
			{
				Console.Clear();
				if (logincnt == 6) {
					if(login.reset())
						Console.WriteLine("Too many bad attempts. The password has been reset. Bye.");
					Console.ReadKey();
				}
			
				else
				{
					Console.WriteLine("Nah, this is not the correct password.");
					startLogin();
				}
				
			}
			else
			{
				Console.WriteLine("You have successfully unlocked the secrets of C#!\nPress any key to continue.\n");
				Console.ReadKey();
				proceed();
			}
		}
	
		private static void proceed()
		{

			int max = int.MaxValue;
			int min = int.MinValue;

			Console.WriteLine($"Max allowed int is : {max}");
			Console.WriteLine($"Min allowed int is : {min}");
			Console.WriteLine($"Pi value: {pi}");

			decimal min2 = decimal.MinValue;
			decimal max2 = decimal.MaxValue;
			Console.WriteLine($"The range of the decimal type is {min2} to {max2}");
			Console.ReadKey();
		}
		static void Main(string[] args)
		{
			startLogin();
			SqlConnect sqlconnect = new SqlConnect();
			sqlconnect.ShowAll();
		}
	}

	

}
