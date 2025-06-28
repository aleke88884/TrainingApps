using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbertSessionFive

{

    public class SeatStateChangedEventArgs : EventArgs
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int State { get; set; }
        public SeatStateChangedEventArgs(int row,int column,int state)
        {
            Row = row;
            Column = column;
            State = state;
        }
    }


    public class ApiService
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenThread;
        private bool isListening;

        public event EventHandler<SeatStateChangedEventArgs> SeatStateChanged;

        public bool Connect(string host = "localhost", int port = 3000)
        {
            try
            {
                client = new TcpClient(host, port);
                stream = client.GetStream();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            isListening = false;

            if (listenThread != null && listenThread.IsAlive)
                listenThread.Join();

            if (stream != null) stream.Close();
            if (client != null) client.Close();
        }

        public void SendEventId(short eventId)
        {
            byte[] data = ToBigEndian(eventId);
            stream.Write(data, 0, data.Length);
        }

        public void StartListening()
        {
            isListening = true;
            listenThread = new Thread(ListenLoop);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ListenLoop()
        {
            byte[] buffer = new byte[6];

            try
            {
                while (isListening)
                {
                    int read = stream.Read(buffer, 0, 6);
                    if (read != 6) continue;

                    int row = FromBigEndian(buffer, 0);
                    int col = FromBigEndian(buffer, 2);
                    int state = FromBigEndian(buffer, 4);

                    if (state < 0 || state > 2) continue;

                    OnSeatStateChanged(row, col, state);
                }
            }
            catch
            {
                // Connection lost or terminated
            }
        }

        public void SendSeatOccupied(short row, short column)
        {
            byte[] data = new byte[4];
            Array.Copy(ToBigEndian(row), 0, data, 0, 2);
            Array.Copy(ToBigEndian(column), 0, data, 2, 2);
            stream.Write(data, 0, 4);
        }

        private void OnSeatStateChanged(int row, int col, int state)
        {
            if (SeatStateChanged != null)
                SeatStateChanged(this, new SeatStateChangedEventArgs(row, col, state));
        }

        private byte[] ToBigEndian(short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return bytes;
        }

        private int FromBigEndian(byte[] buffer, int offset)
        {
            byte[] bytes = new byte[2];
            bytes[0] = buffer[offset];
            bytes[1] = buffer[offset + 1];
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
        }
    }

}
