using ScreenSound.Modelos;

namespace ScreenSound.Repositorios
{
    internal class LinqRepositorio
    {
        public static void AgruparPorGenero(List<Musica> musicas)
        {
            var generos = musicas.Select(musica => musica.Genero).Distinct().ToList();

            // Alternativa
            // var generos = musicas.GroupBy(musica => musica.Genero);

            foreach (var genero in generos)
            {
                Console.WriteLine(genero);
            }
        }

        public static void ExibirArtistasOrdenados(List<Musica> musicas)
        {
            var artistas = musicas.Select(musica => musica.Artista).Distinct().OrderBy(artista => artista).ToList();

            foreach (var artista in artistas)
            {
                Console.WriteLine(artista);
            }
        }

        public static void FiltrarPorGenero(List<Musica> musicas, string genero)
        {
            var artistas = musicas.Where((musica) => (musica.Genero != null && musica.Genero.ToLower().Contains(genero))).Select(musica => musica.Artista).ToList();

            foreach (var artista in artistas)
            {
                Console.WriteLine(artista);
            }
        }

        public static void FiltrarPorArtista(List<Musica> musicas, string artista)
        {
            var musicasFiltradas = musicas.Where((musica) => (musica.Artista != null && musica.Artista.Equals(artista))).ToList();

            foreach (var musica in musicasFiltradas)
            {
                Console.WriteLine(musica.Nome);
            }
        }
    }
}
