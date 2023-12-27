using System.Text.Json;
using ScreenSound.Modelos;
using ScreenSound.Repositorios;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        List<Musica> musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!.Take(10).ToList();

        LinqRepositorio.AgruparPorGenero(musicas);
        LinqRepositorio.ExibirArtistasOrdenados(musicas);
        LinqRepositorio.FiltrarPorGenero(musicas, "pop");
        LinqRepositorio.FiltrarPorArtista(musicas, "Taylor Swift");

        Playlist playlist = new("Minha Playlist");
        playlist.Adicionar(musicas[0]);

        playlist.GerarJson();

        
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}