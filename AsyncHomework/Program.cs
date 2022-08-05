using System.Text.Json;

Variant1();
Variant2();

static async void Variant1()
{
    HttpClient client = new HttpClient();

    try
    {
        List<Post?> posts = new List<Post?>();

        for (int i = 0; i < 10; i++)
        {
            HttpResponseMessage response = client.Send(new HttpRequestMessage(HttpMethod.Get, $@"https://jsonplaceholder.typicode.com/posts/{i + 4}"));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStreamAsync();
            posts.Add(await JsonSerializer.DeserializeAsync<Post>(responseBody));
        }


        using (StreamWriter writer = File.CreateText("result_Variant1.txt"))
        {
            foreach (var item in posts)
                await writer.WriteLineAsync($"{item.UserId}\n{item.Id}\n{item.Title}\n{item.Body}\n");
        }
        using (StreamReader sr = File.OpenText("result_Variant1.txt"))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
    }
}

static async void Variant2()
{
    HttpClient client = new HttpClient();

    try
    {
        List<Post> posts = new();
        Task<Post>[] tasksArr = new Task<Post>[10];

        for (int i = 0; i < 10; i++)
        {
            int index = i + 4;
            tasksArr[i] = new Task<Post>(() =>
            {
                HttpResponseMessage response = client.Send(new HttpRequestMessage(HttpMethod.Get, $@"https://jsonplaceholder.typicode.com/posts/{index}"));
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Post>(responseBody.Result)!;
            });
        }
        foreach (var item in tasksArr)
            item.Start();
        posts = Task.WhenAll(tasksArr).Result.ToList();
        using (StreamWriter writer = File.CreateText("result_Variant2.txt"))
        {
            foreach (var item in posts)
                await writer.WriteLineAsync($"{item.UserId}\n{item.Id}\n{item.Title}\n{item.Body}\n");
        }
        using (StreamReader sr = File.OpenText("result_Variant2.txt"))
        {
            Console.WriteLine(sr.ReadToEnd());
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        throw;
    }
}
