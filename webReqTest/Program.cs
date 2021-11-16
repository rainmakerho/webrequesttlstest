using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace webReqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://gisptest.nat.gov.tw";
            SecurityProtocolType tls = SecurityProtocolType.Tls;
            
            if (args.Length > 0)
            {
                url = args[0];
            }
            if(args.Length > 1)
            {
                switch (Convert.ToInt32(args[1]))
                {
                    case 1:
                        tls = SecurityProtocolType.Tls11;
                        break;
                    case 2:
                        tls = SecurityProtocolType.Tls12;
                        break;
                    case 3:
                        tls = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                        break;
                    default:
                        // code block
                        break;
                }
            }
            ServicePointManager.SecurityProtocol = tls;
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            //request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
            }

            // Close the response.
            response.Close();
        }
    }
}
