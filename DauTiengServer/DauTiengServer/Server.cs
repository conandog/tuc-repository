using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Server
{

    // Incoming data from the client.  
    public static string data = null;

    public static void StartListening(int port)
    {
        //IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        //Console.WriteLine("Starting TCP listener...");
        //TcpListener serverSocket = new TcpListener(ipAddress, port);
        //TcpClient clientSocket = default(TcpClient);
        //serverSocket.Start();
        //Console.WriteLine(" >> Server Started");
        ////clientSocket = serverSocket.AcceptTcpClient();
        ////Console.WriteLine(" >> Accept connection from client");

        //while ((true))
        //{
        //    try
        //    {
        //        Socket client = serverSocket.AcceptSocket();
        //        client.ReceiveBufferSize = 8192;
        //        //client.ReceiveTimeout = 1000;
        //        client.SendBufferSize = 8192;
        //        //client.SendTimeout = 1000;
        //        Console.WriteLine("Connection accepted.");

        //        var childSocketThread = new Thread(() =>
        //        {
        //            byte[] data = new byte[8192];
        //            int size = client.Receive(data);
        //            Console.WriteLine("Recieved data: ");
        //            for (int i = 0; i < size; i++)
        //                Console.Write(Convert.ToChar(data[i]));

        //            Console.WriteLine();

        //            client.Close();
        //        });
        //        childSocketThread.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}

        //clientSocket.Close();
        //serverSocket.Stop();
        //Console.WriteLine(" >> exit");
        //Console.ReadLine();

        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        Console.WriteLine("Starting TCP listener...");
        TcpListener serverSocket = new TcpListener(ipAddress, 1234);
        TcpClient clientSocket = default(TcpClient);
        int counter = 0;

        serverSocket.Start();
        Console.WriteLine(" >> " + "Server Started");

        counter = 0;
        while (true)
        {
            counter += 1;
            clientSocket = serverSocket.AcceptTcpClient();
            clientSocket.ReceiveBufferSize = 8192;
            clientSocket.SendBufferSize = 8192;
            Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
            startClient(clientSocket, Convert.ToString(counter));
        }

        clientSocket.Close();
        serverSocket.Stop();
        Console.WriteLine(" >> " + "exit");
        Console.ReadLine();
    }

    private static TcpClient clientSocket;
    private static string clNo;

    public static void startClient(TcpClient inClientSocket, string clineNo)
    {
        clientSocket = inClientSocket;
        clNo = clineNo;
        Thread ctThread = new Thread(doChat);
        ctThread.Start();
    }
    private static void doChat()
    {
        int requestCount = 0;
        byte[] bytesFrom = new byte[8192];
        string dataFromClient = null;
        Byte[] sendBytes = null;
        string serverResponse = null;
        string rCount = null;
        requestCount = 0;

        while ((true))
        {
            try
            {
                requestCount = requestCount + 1;
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                Console.WriteLine(" >> " + "From client-" + clNo + dataFromClient);

                rCount = Convert.ToString(requestCount);
                serverResponse = "Server to clinet(" + clNo + ") " + rCount;
                sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();
                Console.WriteLine(" >> " + serverResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" >> " + ex.ToString());
            }
        }
    }
}