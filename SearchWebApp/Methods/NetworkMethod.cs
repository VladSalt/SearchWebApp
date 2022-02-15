using SearchWebApp.Interfaces;
using System;
using System.IO;
using System.Net;

namespace SearchWebApp.Methods
{
    public class NetworkMethod : INetworkMethod
    {
        private readonly string Uri = string.Empty;

        public NetworkMethod(string uri)
        {
            this.Uri = uri;
        }

        /// <summary>
        /// Получение реузльтата с API
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
