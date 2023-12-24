using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Server
{
    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 8888);
        listener.Start();
        Console.WriteLine("Сервер запущен...");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Клиент подключен.");

            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
            clientThread.Start(client);
        }
    }

    static void HandleClient(object obj)
    {
        TcpClient tcpClient = (TcpClient)obj;
        NetworkStream stream = tcpClient.GetStream();

        StreamReader reader = new StreamReader(stream);
        StreamWriter writer = new StreamWriter(stream);

        try
        {
            string data = reader.ReadLine();
            Console.WriteLine($"Получены данные от клиента: {data}");

            // Фильтрация четных чисел
            string[] numbers = data.Split(',');
            string result = string.Join(",", Array.FindAll(numbers, s => int.Parse(s) % 2 == 0));

            Console.WriteLine($"Отфильтрованные четные числа: {result}");

            // Отправка результата клиенту
            writer.WriteLine(result);
            writer.Flush();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        finally
        {
            tcpClient.Close();
        }
    }
}
