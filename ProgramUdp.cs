using System.Net;
using System.Text;
using System.Net.Sockets;
using P2P.Udp;

namespace Udp
{
    internal class ProgramUdp
    {
        static Peer peer;
        static void Main()
        {
            peer = new Peer(IPAddress.Parse("Peer's Ip"),8888 ,AddressFamily.InterNetwork);
            Thread listen = new Thread(new ThreadStart(Listen));
            listen.Start();
            peer.Send(ASCIIEncoding.ASCII.GetBytes("punching"));
            while (true)
            {
                peer.Send(ASCIIEncoding.ASCII.GetBytes(Console.ReadLine()));
                Thread.Sleep(10);
            }
        }
        public static void Listen()
        {
            while (true)
            {
                var ret = peer.Recieve();
                string x = ASCIIEncoding.ASCII.GetString(ret.Result);
                Console.WriteLine(x);
            }

        }
        
    }
}