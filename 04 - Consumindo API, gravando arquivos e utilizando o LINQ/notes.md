## Realizando uma requisição
Para essa tarefa, utilizaremos a biblioteca nativa `HttpCLient`.

```csharp
using (HttpClient client = new HttpClient())
{
    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    Console.WriteLine(resposta);
}
```

Note que, o `client` instanciado, é um objeto que será destruído após o bloco `using` ser executado. Desta forma, podemos realizar nossos testes dentro desse contexto.

Fora usado o método `GetStringAsync` para realizar a requisição. Esse método retorna uma `Task<string>`, que é uma promessa de que, em algum momento, teremos uma string. Para isso, usamos o `await` para aguardar o retorno da requisição.

## Try Catch
Partindo do código anterior, caso a requisição falhe, o programa irá quebrar. Para evitar isso, podemos usar um `try catch` para tratar o erro.

```csharp
using (HttpClient client = new HttpClient())
{
	try
	{
		string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
		Console.WriteLine(resposta);
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
	}
}
```
Quando lidamos com requisições, é indispensável o uso de `try catch`. Apesar disso, também podemos usá-los para tratar erros de lógica, como por exemplo, um erro de divisão por zero.

```csharp
try
{
	int c = 1 / 0;
}
catch (Exception e)
{
	Console.WriteLine(e.Message);
}
```

## Modelo de música e anotações
Ao consumirmos uma API, é importante que tenhamos um modelo para representar os dados que estamos recebendo. Podemos definir apenas as propriedades que iremos utilizar, pois, dependendo da regra de negócio e do projeto, não necessitaremos de todas.

```csharp
internal class Musica {
	[JsonPropertyName("song")]
	public string? Nome { get; set; }

	[JsonPropertyName("artist")]
	public string? Artista { get; set; }

	[JsonPropertyName("duration_ms")]
	public int Duracao { get; set; }

	[JsonPropertyName("genre")]
	public string? Genero { get; set; }

	public void Detalhes() {
		Console.WriteLine($"Nome: {Nome}, Artista: {Artista}, Duração: {Duracao}, Gênero: {Genero}");
	}
}
```
Similar a outras linguagens, podemos usar anotações. Ao invés de usar o famoso `@`, passamos um conjunto de atributos numa lista. Para mapear o nome da propriedade da API para o equivalente em nossa modelo, usamos a anotação `JsonPropertyName`. Caso usemos o mesmo nome, não é necessário usar essa anotação.

## Deserializando os dados
Agora que temos nosso modelo, podemos deserializar os dados recebidos. Para isso, usaremos a biblioteca `System.Text.Json`.

```csharp
using ScreenSound.Modelos;
using (HttpClient client = new HttpClient())
{
	try
	{
		string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
		List<Musica> musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

		foreach (Musica musica in musicas)
		{
			musica.Detalhes();
		}
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
	}
}
```

Em versão anteriores do C#, era necessário usar bibliotecas de terceiros para realizar a deserialização, como a `Newtonsoft.Json`. Porém, a partir da versão 3.0, o C# passou a ter suporte nativo para a deserialização de JSON.

A resposta da API será deserializada para uma lista de músicas. Note que, o retorno do método `Deserialize` é um `List<Musica>?`. Isso ocorre pois, caso a deserialização falhe, o retorno será `null`. Para evitar isso, usamos o operador `!` para dizer que, mesmo que o retorno seja `null`, queremos que o programa continue.

## Filtrando e ordenando
Agora que temos nossa lista de músicas, podemos filtrar e ordenar os dados. Para isso, usaremos os métodos da lista extendidos da biblioteca `System.Linq`.

```csharp
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
```
Como vemos, o LINQ (Language Integrated Query) se assemelha muito ao SQL. No geral, se uso no C# oferece uma sintaxe elegante e eficaz para consultas e manipulação de dados, tornando o código mais legível, conciso e fácil de manter.

### Select
Simiar ao `SELECT` do SQL, o método `Select` é usado para selecionar uma propriedade específica de um objeto. No exemplo acima, usamos o `Select` para selecionar o gênero de cada música. Note que, o retorno do `Select` é um `IEnumerable<string>`, ou seja, uma lista de strings. Ao converter para uma lista (`ToList()`), podemos usar métodos como `Add`, `Remove`, etc.

### Distinct
O método `Distinct` é usado para remover elementos duplicados de uma lista. No exemplo acima, usamos o `Distinct` para remover gêneros duplicados.

### OrderBy
O método `OrderBy` é usado para ordenar uma lista. No exemplo acima, usamos o `OrderBy` para ordenar os artistas em ordem alfabética, isto é, do A ao Z ou de forma ascendente, como é mais conhecido. No caso de ordenação decrescente, usamos o método `OrderByDescending`.

### Where
O método `Where` é usado para filtrar uma lista, isto é, obter um subconjunto. No exemplo acima, usamos o `Where` para filtrar as músicas por gênero e por artista.


## Salvando os dados
Agora que temos nossos dados, podemos separá-los em uma playlist.

```csharp
using ScreenSound.Modelos;

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
}
```

## Serializando para um arquivo JSON
Do mesmo modo que deserializamos os dados, podemos serializá-los. Para isso, usaremos, novamente, a biblioteca `System.Text.Json`.

```csharp
using System.Text.Json;
using ScreenSound.Modelos;

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

        //...

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
    }
}
```

Analizando o novo método `GerarJson`, vemos que, para serializar os dados, usamos o método `Serialize` da classe `JsonSerializer`. O método `Serialize` recebe um objeto e retorna uma string. No exemplo acima, passamos um **objeto anônimo**, isto é, um objeto sem nome, com as propriedades `nome` e `musicas`. O método `Serialize` irá retornar uma string com o seguinte formato:

```json
{
	"nome": "nome da playlist",
	"musicas": [
		{
			"nome": "nome da música",
			"artista": "nome do artista",
			"duracao": 123456,
			"genero": "nome do gênero"
		}
	]
}
```

## Gerando um arquivo TXT
Além de gerar um arquivo JSON, podemos gerar um arquivo TXT. Para isso, usaremos o método `WriteAllLines` da classe `File`.

```csharp
using System.IO;
using ScreenSound.Modelos;

namespace ScreenSound.Modelos
{
	internal class Playlist
	{
		//...

		public void GerarTxt()
		{
			string[] linhas = new string[Musicas.Count];

			for (int i = 0; i < Musicas.Count; i++)
			{
				linhas[i] = $"{Musicas[i].Nome} - {Musicas[i].Artista}";
			}

			File.WriteAllLines($"{Nome}.txt", linhas);

			Console.WriteLine("Playlist gerada com sucesso!");
			Console.WriteLine(Path.GetFullPath($"{Nome}.txt"));
		}
	}
}
```

Ou:

```csharp
using System.IO;
using ScreenSound.Modelos;

namespace ScreenSound.Modelos
{
	internal class Playlist
	{
		//...

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
```