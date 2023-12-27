## Realizando uma requisi��o
Para essa tarefa, utilizaremos a biblioteca nativa `HttpCLient`.

```csharp
using (HttpClient client = new HttpClient())
{
    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    Console.WriteLine(resposta);
}
```

Note que, o `client` instanciado, � um objeto que ser� destru�do ap�s o bloco `using` ser executado. Desta forma, podemos realizar nossos testes dentro desse contexto.

Fora usado o m�todo `GetStringAsync` para realizar a requisi��o. Esse m�todo retorna uma `Task<string>`, que � uma promessa de que, em algum momento, teremos uma string. Para isso, usamos o `await` para aguardar o retorno da requisi��o.

## Try Catch
Partindo do c�digo anterior, caso a requisi��o falhe, o programa ir� quebrar. Para evitar isso, podemos usar um `try catch` para tratar o erro.

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
Quando lidamos com requisi��es, � indispens�vel o uso de `try catch`. Apesar disso, tamb�m podemos us�-los para tratar erros de l�gica, como por exemplo, um erro de divis�o por zero.

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

## Modelo de m�sica e anota��es
Ao consumirmos uma API, � importante que tenhamos um modelo para representar os dados que estamos recebendo. Podemos definir apenas as propriedades que iremos utilizar, pois, dependendo da regra de neg�cio e do projeto, n�o necessitaremos de todas.

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
		Console.WriteLine($"Nome: {Nome}, Artista: {Artista}, Dura��o: {Duracao}, G�nero: {Genero}");
	}
}
```
Similar a outras linguagens, podemos usar anota��es. Ao inv�s de usar o famoso `@`, passamos um conjunto de atributos numa lista. Para mapear o nome da propriedade da API para o equivalente em nossa modelo, usamos a anota��o `JsonPropertyName`. Caso usemos o mesmo nome, n�o � necess�rio usar essa anota��o.

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

Em vers�o anteriores do C#, era necess�rio usar bibliotecas de terceiros para realizar a deserializa��o, como a `Newtonsoft.Json`. Por�m, a partir da vers�o 3.0, o C# passou a ter suporte nativo para a deserializa��o de JSON.

A resposta da API ser� deserializada para uma lista de m�sicas. Note que, o retorno do m�todo `Deserialize` � um `List<Musica>?`. Isso ocorre pois, caso a deserializa��o falhe, o retorno ser� `null`. Para evitar isso, usamos o operador `!` para dizer que, mesmo que o retorno seja `null`, queremos que o programa continue.

## Filtrando e ordenando
Agora que temos nossa lista de m�sicas, podemos filtrar e ordenar os dados. Para isso, usaremos os m�todos da lista extendidos da biblioteca `System.Linq`.

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
Como vemos, o LINQ (Language Integrated Query) se assemelha muito ao SQL. No geral, se uso no C# oferece uma sintaxe elegante e eficaz para consultas e manipula��o de dados, tornando o c�digo mais leg�vel, conciso e f�cil de manter.

### Select
Simiar ao `SELECT` do SQL, o m�todo `Select` � usado para selecionar uma propriedade espec�fica de um objeto. No exemplo acima, usamos o `Select` para selecionar o g�nero de cada m�sica. Note que, o retorno do `Select` � um `IEnumerable<string>`, ou seja, uma lista de strings. Ao converter para uma lista (`ToList()`), podemos usar m�todos como `Add`, `Remove`, etc.

### Distinct
O m�todo `Distinct` � usado para remover elementos duplicados de uma lista. No exemplo acima, usamos o `Distinct` para remover g�neros duplicados.

### OrderBy
O m�todo `OrderBy` � usado para ordenar uma lista. No exemplo acima, usamos o `OrderBy` para ordenar os artistas em ordem alfab�tica, isto �, do A ao Z ou de forma ascendente, como � mais conhecido. No caso de ordena��o decrescente, usamos o m�todo `OrderByDescending`.

### Where
O m�todo `Where` � usado para filtrar uma lista, isto �, obter um subconjunto. No exemplo acima, usamos o `Where` para filtrar as m�sicas por g�nero e por artista.


## Salvando os dados
Agora que temos nossos dados, podemos separ�-los em uma playlist.

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
Do mesmo modo que deserializamos os dados, podemos serializ�-los. Para isso, usaremos, novamente, a biblioteca `System.Text.Json`.

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

Analizando o novo m�todo `GerarJson`, vemos que, para serializar os dados, usamos o m�todo `Serialize` da classe `JsonSerializer`. O m�todo `Serialize` recebe um objeto e retorna uma string. No exemplo acima, passamos um **objeto an�nimo**, isto �, um objeto sem nome, com as propriedades `nome` e `musicas`. O m�todo `Serialize` ir� retornar uma string com o seguinte formato:

```json
{
	"nome": "nome da playlist",
	"musicas": [
		{
			"nome": "nome da m�sica",
			"artista": "nome do artista",
			"duracao": 123456,
			"genero": "nome do g�nero"
		}
	]
}
```

## Gerando um arquivo TXT
Al�m de gerar um arquivo JSON, podemos gerar um arquivo TXT. Para isso, usaremos o m�todo `WriteAllLines` da classe `File`.

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
				arquivo.WriteLine($"M�sicas favoritas do {Nome}\n");

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