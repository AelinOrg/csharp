## Namespaces em C#
A linguagem C# suporta o conceito de namespaces. Um namespace é um conjunto de classes e interfaces. Um namespace pode ser definido como um contêiner que fornece um contexto exclusivo para os itens de nome. Os nomes de classes, estruturas, interfaces, enumeradores e outros tipos de dados devem ser exclusivos em um namespace. 

```csharp
// arquivo Musicas.cs

namespace SoundScreen.Modelos;

public class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }
}

// arquivo Program.cs
SoundScreen.Modelos.Musica musica = new SoundScreen.Modelos.Musica();
```

Usamos a sintaxe `namespace` para declarar um namespace. Ele contém o nome do projeto e da pasta mãe, onde o arquivo está localizado.

Em adição ao namespace, podemos usar a palavra-chave `using` para importar um namespace para o nosso código. Isso permite que você use o nome de uma classe sem especificar o nome do namespace.

```csharp
using SoundScreen.Modelos;

Musica musica = new Musica();
```

Dois namespaces diferentes podem conter tipos de dados com o mesmo nome. Por exemplo, o namespace `System.Collections` contém uma classe chamada `ArrayList` e o namespace `System.Data` também contém uma classe chamada `ArrayList`. O nome completo de uma classe inclui o nome do namespace. Por exemplo, o nome completo da classe `ArrayList` no namespace `System.Collections` é `System.Collections.ArrayList`. O nome completo da classe `ArrayList` no namespace `System.Data` é `System.Data.ArrayList`.

```csharp
using CollectionsArrayList = System.Collections.ArrayList;
using DataArrayList = System.Data.ArrayList;

CollectionsArrayList list1 = new CollectionsArrayList();
DataArrayList list2 = new DataArrayList();
```

Para evitar conflitos de nome, podemos usar um alias para um namespace. Um alias é um nome alternativo que pode ser usado para um namespace. 

Namespaces são úteis para organizar o código-fonte e para evitar conflitos de nome. Eles também podem ser usados para definir escopos, permitindo que você use o mesmo nome para um elemento em diferentes partes do código.

**Fully Qualified Name (FQN)**
O nome totalmente qualificado de um tipo de dados inclui o nome do namespace. Por exemplo, o nome totalmente qualificado da classe `ArrayList` no namespace `System.Collections` é `System.Collections.ArrayList`.

## Visibilidade internal
O modificador `internal` é um modificador de acesso. Ele pode ser aplicado a classes e membros de classe. Um membro de classe com o modificador `internal` só pode ser acessado dentro do mesmo projeto (assembly). Um assembly é um arquivo executável ou uma biblioteca de classes. 

```csharp
internal class Musica
{
	// ...
}

```

## Visibilidade estática
São blocos de instrução que de alguma maneira estão relacionados ao tipo ao qual aquele método pertence, mas não utilizam nenhum dado ou outro método de objetos do tipo. Além de métodos estáticos, também podemos criar campos estáticos. Neste caso, o valor do campo está associado ao tipo e não ao objeto. Um cenário muito comum é armazenar constantes associadas àquele tipo.

```csharp
public class Musica
{
	public static void QuantidadeDeMusicas()
	{
		// ...
	}
}

Musica.QuantidadeDeMusicas();
```
## Herança
Um dos pilares da orientação a objetos é a herança. Ela permite que uma classe herde características de outra classe. A classe que herda é chamada de classe derivada ou subclasse. A classe que é herdada é chamada de classe base ou superclasse. 

```csharp
public class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }

	public void Tocar()
	{
		Console.WriteLine($"Tocando {Nome} de {Artista}");
	}
}

public class MusicaFavorita : Musica
{
	public bool Favorita { get; set; }
}

MusicaFavorita musica = new MusicaFavorita();
musica.Nome = "Astronaut In The Ocean";
musica.Artista = "Masked Wolf";

musica.Tocar();
```

A classe `MusicaFavorita` herda da classe `Musica`. Isso significa que a classe `MusicaFavorita`, por exemplo, pode usar a propriedade `Nome` ou o método `Tocar` da classe `Musica`, isto **se o membro for público**.

Note que a sintaxe para herança é `class SubClasse : SuperClasse`.

## Sobreposição de métodos
A sobreposição de métodos é um recurso da linguagem que permite que uma classe derivada forneça uma implementação específica para um método que já está implementado em uma classe base. 

```csharp
public class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }

	public virtual void Tocar()
	{
		Console.WriteLine($"Tocando {Nome} de {Artista}");
	}
}

public class MusicaFavorita : Musica
{
	public bool Favorita { get; set; }

	public override void Tocar()
	{
		Console.WriteLine($"Tocando {Nome} de {Artista} (favorita)");
	}
}

MusicaFavorita musica = new MusicaFavorita();
musica.Nome = "Astronaut In The Ocean";
musica.Artista = "Masked Wolf";

musica.Tocar();
```

Como vemos, para que seja possível a sobreposição de métodos, é necessário usar o modificador `virtual` na classe base e o modificador `override` na classe derivada.

Apesar de termos sobrescrito o método `Tocar` na classe `MusicaFavorita`, ainda é possível acessar o método `Tocar` da classe `Musica` usando a palavra-chave `base`.

```csharp
public class MusicaFavorita : Musica
{
	public bool Favorita { get; set; }

	public override void Tocar()
	{
		base.Tocar();
		Console.WriteLine($"Tocando {Nome} de {Artista} (favorita)");
	}
}
```

Na herança, classes ancestrais podem ter comportamentos substituídos ou sobrescritos por seus descendentes. Para indicar essa possibilidade, declaramos o membro no ancestral como virtual, e no descendente que for sobrescrevê-lo, marcamos o membro da classe com override. Se ainda assim quisermos executar a parte de código que estiver no ancestral, usamos a palavra reservada base.

## Interfaces
Uma interface é um tipo de referência semelhante a uma classe, mas que só pode conter declarações de membros abstratos e constantes. Não é possível criar uma instância de uma interface. Uma interface é implementada por uma classe ou struct. 

```csharp
internal interface IMusica
{
	string Nome { get; set; }
	string Artista { get; set; }
	string Album { get; set; }
	string Genero { get; set; }
	int Ano { get; set; }

	void Tocar();
}

internal class Musica : IMusica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }

	public void Tocar()
	{
		Console.WriteLine($"Tocando {Nome} de {Artista}");
	}
}

internal class MusicaFavorita : IMusica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }
	public bool Favorita { get; set; }

	public void Tocar()
	{
		Console.WriteLine($"Tocando {Nome} de {Artista} (favorita)");
	}
}
```

A sintaxe para definir uma interface é `interface NomeDaInterface`. Ela define um contrato que deve ser implementado por uma classe ou struct. 

Conforme aconselhado pela Microsoft, o nome de uma interface deve começar com a letra `I`.

## Ancestral-raiz
Usando um atalho do Visual Studio em que digitamos a palavra `override`, seguida de um espaço, resulta na apresentação de todos os métodos que podem ser sobrescritos. Neste momento, apareceram três métodos: `ToString()`, `GetHashCode()` e `Equals()`. Afinal, de onde vêm esses métodos?

Na verdade, todas as classes herdam de um “ancestral-raiz”: a classe `Object`. Podemos dizer que objetos criados a partir de qualquer classe são `Object`. E é nessa classe que estão declarados esses três métodos.

Para que serve cada um desses métodos?

- O método `ToString()` pode ser utilizado para gerar uma representação textual do tipo cujo objeto pertence. A implementação padrão existente em `Object` somente imprime o nome do tipo. Podemos sobrescrever esse método para retornar um texto mais significativo.

- O método `Equals()` retorna um valor booleano para indicar se o objeto é equivalente a outro passado como argumento do método. Podemos sobrescrever esse método para representar uma nova lógica de equivalência.

- O método `GetHashCode()` é usado em conjunto com a sobrescrita de Equals(). Em algumas coleções, usamos um código hash para identificar o objeto no conjunto. Se a condição de igualdade for alterada, é preciso também alterar o código identificador para o objeto.
- 
## IEnumerable
A interface `IEnumerable` é usada para fornecer uma maneira de iterar sobre uma coleção. Ela define um método `GetEnumerator()`, que retorna um objeto que implementa a interface `IEnumerator`. 

Ela é útil quando queremos criar uma coleção que pode ser percorrida, mas não queremos expor a implementação da coleção ou permitir que a coleção seja modificada. 

```csharp
public class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }

	public void Tocar()
	{
		Console.WriteLine($"Tocando {Nome} de {Artista}");
	}
}

public class Playlist : IEnumerable
{
	private List<Musica> _musicas = new List<Musica>();

	public void Adicionar(Musica musica)
	{
		_musicas.Add(musica);
	}

	public IEnumerator GetEnumerator()
	{
		return _musicas.GetEnumerator();
	}
}

Playlist playlist = new Playlist();
playlist.Adicionar(new Musica { Nome = "Astronaut In The Ocean", Artista = "Masked Wolf" });
playlist.Adicionar(new Musica { Nome = "Rapstar", Artista = "Polo G" });
playlist.Adicionar(new Musica { Nome = "Save Your Tears", Artista = "The Weeknd" });

foreach (Musica musica in playlist)
{
	musica.Tocar();
}

// ou 

public class Playlist 
{
	private List<Musica> _musicas = new List<Musica>();
	public IEnumerable<Musica> Musicas => _musicas;

}
```

A classe `Playlist` implementa a interface `IEnumerable`. Isso significa que ela pode ser percorrida usando um `foreach`. 

## Instalando uma biblioteca
Para instalar uma biblioteca, primeiro precisamos nos certificar de que o projeto/solução está aberto no Visual Studio. Em seguida, clicamos com o botão direito na opção `Dependencies` e selecionamos a opção `Manage NuGet Packages...`. Em seguida, clicamos na aba `Browse` e pesquisamos pela biblioteca que queremos instalar. Por fim, clicamos no botão `Install`.

Iremos utilizar a biblioteca `OpenAI` para gerar descrições de músicas.

## Gerando descrições de músicas
Para gerar descrições de músicas, importamos a biblioteca `OpenAI:

```csharp
using OpenAI_API;

var client = new OpenAIClient("API_KEY");
var chat = client.Chat.CreateConversation();

chat.AppendSystemMessage("Você é um bot que gera descrições de músicas.");

internal class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	private string? _descricao;

	public Musica Criar(Musica musica)
	{
		chat.AppendUserInput($"Gere uma descrição para a música {musica.Nome} de {musica.Artista}")
		musica._descricao = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
		_musicas.Add(musica);
	}

	/*public async Task<Musica> Criar(Musica musica)
	{
		chat.AppendUserInput($"Gere uma descrição para a música {musica.Nome} de {musica.Artista}")
		musica._descricao = await chat.GetResponseFromChatbotAsync();
		_musicas.Add(musica);
	}*/

	public void Tocar()
	{
		Console.WriteLine($"Tocando {Nome} de {Artista}\n");
		Console.WriteLine(_descricao);
	}
}

Musica musica = new Musica().Criar(new Musica { Nome = "Astronaut In The Ocean", Artista = "Masked Wolf" });
musica.Tocar();
```

Note que, no método `Criar`, usamos o método `GetResponseFromChatbotAsync` para obter a descrição da música. Dentre as possibilidades, utilizamos o método `GetAwaiter` para aguardar a resposta do bot e o método `GetResult` para obter o resultado. Desta forma, não precisamos transformar o método `Criar` em `async` e nem usar o `await` para aguardar a resposta do bot.

**Quando se trata de operações assíncronas, é recomendado utilizar o `async` e o `await` para aguardar o resultado.**