using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShearchApp
{
    class NetworkMethods
    {
        const string API = @"https://api.stackexchange.com/docs/search#order=desc&sort=activity&intitle=c%23&filter=default&site=stackoverflow";

        NetworkMethods()
        {

        }

        public void ApiGet(string answer)
        {

        }

        public void Connection ()
        {
            WebRequest request = WebRequest.Create(API);
            WebResponse response = request.GetResponse();
            using (System.IO.Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен");
            Console.Read();
        }
    }
}
