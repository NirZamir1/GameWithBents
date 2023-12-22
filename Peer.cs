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
        public Peer(IPAddress peerIp, int port,AddressFamily addressType)
        {
            _endPoint = new IPEndPoint(peerIp, port);
            _client = new UdpClient(_port,addressType);
            _client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }
        public void send(byte[] bytes)
        {
           
                _client.Send(bytes, bytes.Length, _endPoint);            
        }
        public byte[] recieve()
        {
            return _client.Receive(ref _endPoint);
        }

    }
}
