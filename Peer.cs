using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Udp
{
    public class Peer
    {
        private IPEndPoint _endPoint;
        private UdpClient _client;
        private const int _port = 8888;
        public Peer(IPAddress peerIp, int port)
        {
            _client = new UdpClient(_port);
            _endPoint = new IPEndPoint(peerIp, port);
        }
        public void send(byte[] bytes)
        {
            _client.Send(bytes,_endPoint);
        }
        public Task<UdpReceiveResult> recieve()
        {
            return _client.ReceiveAsync();
        }

    }
}
