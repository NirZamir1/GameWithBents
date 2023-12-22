using System.Net;
using System.Text;
using System.Net.Sockets;
namespace Udp
{
    internal class Program
    {
        static Peer peer;
        static void Main()
        {
            peer = new Peer(IPAddress.Parse("Peer's Ip"),8888 ,AddressFamily.InterNetwork);
            Thread listen = new Thread(new ThreadStart(Listen));
            listen.Start();
            peer.send(ASCIIEncoding.ASCII.GetBytes("punching"));
            while (true)
            {
                peer.send(ASCIIEncoding.ASCII.GetBytes(Console.ReadLine()));
                Thread.Sleep(10);
            }
        }
        public static void Listen()
        {
            while (true)
            {
                var ret = peer.recieve();
                string x = ASCIIEncoding.ASCII.GetString(ret);
                Console.WriteLine(x);
            }

        }
        
    }
}