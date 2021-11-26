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
            string Name = AskName();
            while (true)
            {
                PrintMenu();
                int numberFromUser = Ask(4);
                if (numberFromUser == 0)
                {
                    await GetListOfTopics();
                }
                else if (numberFromUser == 1)
                {
                    Console.WriteLine("Введите id темы: ");
                    int topicId = AskTopicId(1);
                    await GetListOfPostsInTopic(topicId);
                }
                else if (numberFromUser == 3)
                {
                    Console.WriteLine("Введите название темы: ");
                    string nameOfTopic = Console.ReadLine();
                    await PostTopic(nameOfTopic);
                }
                else if (numberFromUser == 4)
                {
                    Console.WriteLine("Введите id темы: ");
                    int topicId = AskTopicId(1);
                    Console.WriteLine("Введите cодержание поста: ");
                    string textOfPost = Console.ReadLine();
                    await PostPost(topicId, textOfPost);
                }
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - получить список тем");
            Console.WriteLine("2 - получить список постов в теме");
            Console.WriteLine("3 - создать тему");
            Console.WriteLine("4 - создать пост в тему");
        }
        private static int Ask(int max)
        {
            Console.WriteLine($"Введите номер от 1 до {max}: ");
            int fromClient = Convert.ToInt32(Console.ReadLine());
            while(fromClient < 1 || fromClient > max)
            {
                Console.WriteLine("Вы ввели неверный номер!");
                Console.WriteLine($"Введите номер от 1 до {max}: ");
                fromClient = Convert.ToInt32(Console.ReadLine());
            }
            return fromClient - 1;
        }
        private static string AskName()
        {
            Console.WriteLine("Как мне представить вас перед достопочтенной публикой?");
            string Name = Console.ReadLine();
            return Name;
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
        private async static Task GetListOfPostsInTopic(int id)
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44300/forum/");
            //TODO GetListOfPostsInTopic
        }
        private async static Task PostTopic(string nameOfTopic)
        {
            using var client = new HttpClient();
            HttpContent content = new StringContent(nameOfTopic);
            HttpResponseMessage response = await client.PostAsync("https://localhost:44300/forum/", content);
        }
        private async static Task PostPost(int id, string message)
        {
            using var client = new HttpClient();
            HttpContent content = new StringContent(message);
            HttpResponseMessage response = await client.PostAsync($"https://localhost:44300/forum/{id}", content);
        }
    }
}
