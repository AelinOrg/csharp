using System.Text.Json;

namespace ScreenSound.Modelos
{
    internal class Playlist
    {
        public string Nome { get; set; }
        public List<Musica> Musicas { get; }

        public Playlist(string nome)
        {
            Nome = nome;
            Musicas = new List<Musica>();
        }

        public void Adicionar(Musica musica)
        {
            Musicas.Add(musica);
        }

        public void Detalhes()
        {
            foreach (Musica musica in Musicas)
            {
                musica.Detalhes();
            }
        }

        public void GerarJson()
        {
            string json = JsonSerializer.Serialize(new
            {
                nome = Nome,
                musicas = Musicas
            });

            File.WriteAllText($"{Nome}.json", json);

            Console.WriteLine("Playlist gerada com sucesso!");
            Console.WriteLine(Path.GetFullPath($"{Nome}.json"));
        }

        public void GerarTxt()
        {
            using (StreamWriter arquivo = new(Nome))
            {
                arquivo.WriteLine($"Músicas favoritas do {Nome}\n");
                foreach (var musica in Musicas)
                {
                    arquivo.WriteLine($"- {musica.Nome}");
                }
            }
            Console.WriteLine("txt gerado com sucesso!");
        }
    }
}
