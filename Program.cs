using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace GitHub
{
	class Program
	{
		static void Main(string[] args)
		{

			string url = "https://api.github.com/users/maarjaryytel?client_id=9405d814c0add9a9bc18&client_secret=/9405d814c0add9a9bc18";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			request.UserAgent = "Foo";
			//request.Accept = "*/**"; //see on ühenduse järjekorra jaoks, st panna andmed järjekorda

			var webResponce = request.GetResponse();
			var webStream = webResponce.GetResponseStream();

			using (var responceReader = new StreamReader(webStream))
			{

				var responce = responceReader.ReadToEnd();
				Data.RootObject profileData = JsonConvert.DeserializeObject<Data.RootObject>(responce); 
                
				Console.WriteLine($"Login: {profileData.login}");
				Console.WriteLine($"Avatar url: {profileData.avatar_url}");
				Console.WriteLine($"Followers: {profileData.followers}");
				Console.WriteLine($"Following: {profileData.following}");

			}
			Console.ReadLine();
		}
	}
}
