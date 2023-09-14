try
{
    using (HttpClient client = new HttpClient())
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.jso");
        Console.WriteLine(resposta);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}