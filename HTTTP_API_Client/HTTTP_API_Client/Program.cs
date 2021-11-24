using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTTP_API_Client
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello!");
            PrintMenu();
            int numberFromUser = Ask(3);
            if(numberFromUser == 0)
            {
                await GetListOfTopics();
            }
            else if(numberFromUser == 1)
            {
                Console.WriteLine("Введите id темы: ");
                int topicId = AskTopicId(1);
                GetListOfPostsInTopic(topicId);
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - получить список тем");
            Console.WriteLine("2 - получить список постов в теме");
        }
        private static int Ask(int max)
        {
            Console.WriteLine($"Введите номер от 1 до {max+1}: ");
            int fromClient = Convert.ToInt32(Console.ReadLine());
            while(fromClient < 1 || fromClient > max + 1)
            {
                Console.WriteLine("Вы ввели неверный номер!");
                Console.WriteLine($"Введите номер от 1 до {max + 1}: ");
                fromClient = Convert.ToInt32(Console.ReadLine());
            }
            return fromClient - 1;
        }
        private static int AskTopicId(int min = 0)
        {
            Console.WriteLine($"Введите номер: ");
            int fromClient = Convert.ToInt32(Console.ReadLine());
            while (fromClient < min)
            {
                Console.WriteLine("Вы ввели неверный номер!");
                Console.WriteLine($"Введите номер темы: ");
                fromClient = Convert.ToInt32(Console.ReadLine());
            }
            return fromClient - 1;
        }
        private async static Task GetListOfTopics()
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44300/forum/");
            Console.WriteLine(response);
            //TODO GetListOfTopics
        }
        private static void GetListOfPostsInTopic(int id)
        {
            //TODO GetListOfPostsInTopic
        }
    }
}
