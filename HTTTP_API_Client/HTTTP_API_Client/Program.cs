﻿using HTTP_APi;
using HTTP_APi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
                int numberFromUser = Ask();
                if (numberFromUser == 0)
                {
                    await GetListOfTopics();
                }
                else if (numberFromUser == 1)
                {
                    Console.WriteLine("Введите id темы: ");
                    int topicId = Ask();
                    await GetListOfPostsInTopic(topicId);
                }
                else if (numberFromUser == 2)
                {
                    Console.WriteLine("Введите название темы: ");
                    string nameOfTopic = Console.ReadLine();
                    await PostNewTopic(nameOfTopic, Name);
                }
                else if (numberFromUser == 3)
                {
                    Console.WriteLine("Введите id темы: ");
                    int topicId = Ask();
                    Console.WriteLine("Введите cодержание поста: ");
                    string textOfPost = Console.ReadLine();
                    await PostNewMessage(topicId, textOfPost, Name);
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
        private static int Ask()
        {
            Console.WriteLine($"Введите номер: ");
            int fromClient = Convert.ToInt32(Console.ReadLine());
            while(fromClient < 0)
            {
                Console.WriteLine("Вы ввели неверный номер!");
                Console.WriteLine($"Введите номер: ");
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
        private async static Task GetListOfTopics()
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44300/forum/");
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            Stream stream = await response.Content.ReadAsStreamAsync();
            List<TopicGetDTO> topics = await JsonSerializer.DeserializeAsync<List<TopicGetDTO>>(stream); //TODO FIX!!!
            if(topics.Count > 0)
            {
                PrintListOfTopic(topics);
            }
            else
            {
                Console.WriteLine("ASD");
            }
        }
        private async static Task GetListOfPostsInTopic(int id)
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44300/forum/{id}");
            response.EnsureSuccessStatusCode();
            Stream stream = await response.Content.ReadAsStreamAsync();
            Topic posts = await JsonSerializer.DeserializeAsync<Topic>(stream);
            PrintListOfPosts(posts);
        }
        private async static Task PostNewTopic(string NameOfTopic, string Name)
        {
            using var client = new HttpClient();
            NewTopicDTO topic = new NewTopicDTO(NameOfTopic, Name);
            HttpContent content = JsonContent.Create(topic);
            HttpResponseMessage response = await client.PostAsync("https://localhost:44300/forum/", content);
            response.EnsureSuccessStatusCode();
        }
        private async static Task PostNewMessage(int Id, string Message, string Name)
        {
            using var client = new HttpClient();
            NewPostDTO post = new NewPostDTO(Message, Id, Name);
            HttpContent content = JsonContent.Create(post);
            HttpResponseMessage response = await client.PostAsync($"https://localhost:44300/forum/{Id}", content);
            response.EnsureSuccessStatusCode();
        }
        private static void PrintListOfTopic(List<TopicGetDTO> topics)
        {
            for (int i = 0; i < topics.Count; i++)
            {
                Console.WriteLine($"{topics[i].Id}. Создал - {topics[i].Name}. Когда? {topics[i].Date}  \n{topics[i].Title}");
            }
        }
        private static void PrintListOfPosts(Topic topic)
        {
            for (int i = 0; i < topic.Posts.Count; i++)
            {
                Console.WriteLine($"{topic.Posts[i].id}. Написал - {topic.Posts[i].Name}. Когда? {topic.Posts[i].Date}  \n{topic.Posts[i].Message}");
            }
        }
    }
}
