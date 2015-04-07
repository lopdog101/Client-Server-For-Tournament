
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ApplicationServer.v1
{
    class GamePeer : IGamePeer
    {
        private readonly TcpClient _client;
        private readonly StreamReader _reader;
        private readonly NetworkStream _stream;

        public GamePeer(TcpClient client)
        {
            _client = client;
            _reader = new StreamReader(client.GetStream());
            _stream = client.GetStream();
        }

        public void Send(string message)
        {
            byte[] dataWrite = Encoding.UTF8.GetBytes(message);
            _stream.Write(dataWrite, 0, dataWrite.Length);
        }

        public string Recv()
        {
            return _reader.ReadLine();
        }

        public void Dispose()
        {
            _client.Close();
        }
    }
}