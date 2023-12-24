using System;
using System.IO;
using System.Net.Sockets;

class Client
{
    static void Main()
    {
        Console.Write("Введите числа через запятую: ");
        string numbers = Console.ReadLine();

        using (TcpClient client = new TcpClient("127.0.0.1", 8888))
        {
            using (NetworkStream stream = client.GetStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // Отправка чисел серверу
                        writer.WriteLine(numbers);
                        writer.Flush();

                        // Получение отфильтрованных четных чисел от сервера
                        string result = reader.ReadLine();
                        Console.WriteLine($"От сервера получены четные числа: {result}");
                    }
                }
            }
        }
    }
}
