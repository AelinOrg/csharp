
using System.Text.Json.Serialization;

namespace ScreenSound.Modelos;

internal class Musica
{
    [JsonPropertyName("song")]
    public string? Nome { get; set; }

    [JsonPropertyName("artist")]
    public string? Artista { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    public void Detalhes()
    {
        Console.WriteLine($"Nome: {Nome}, Artista: {Artista}, Duração: {Duracao}, Gênero: {Genero}");
    }
}
