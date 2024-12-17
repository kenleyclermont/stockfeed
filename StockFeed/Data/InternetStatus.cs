using System.Net.NetworkInformation;
namespace StockFeed.Data
{
    public class InternetStatus
    {
        public InternetStatus() { }
        public static bool IsInternetConnectionOpen() 
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("www.google.com", 1000);
                return reply != null && reply.Status == IPStatus.Success;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("Error checking internet connection: " + ex.Message);
                return false;
            }     
        }
    }
}
