## Namespaces em C#
A linguagem C# suporta o conceito de namespaces. Um namespace � um conjunto de classes e interfaces. Um namespace pode ser definido como um cont�iner que fornece um contexto exclusivo para os itens de nome. Os nomes de classes, estruturas, interfaces, enumeradores e outros tipos de dados devem ser exclusivos em um namespace. 

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

Usamos a sintaxe `namespace` para declarar um namespace. Ele cont�m o nome do projeto e da pasta m�e, onde o arquivo est� localizado.

Em adi��o ao namespace, podemos usar a palavra-chave `using` para importar um namespace para o nosso c�digo. Isso permite que voc� use o nome de uma classe sem especificar o nome do namespace.

```csharp
using SoundScreen.Modelos;

Musica musica = new Musica();
```

Dois namespaces diferentes podem conter tipos de dados com o mesmo nome. Por exemplo, o namespace `System.Collections` cont�m uma classe chamada `ArrayList` e o namespace `System.Data` tamb�m cont�m uma classe chamada `ArrayList`. O nome completo de uma classe inclui o nome do namespace. Por exemplo, o nome completo da classe `ArrayList` no namespace `System.Collections` � `System.Collections.ArrayList`. O nome completo da classe `ArrayList` no namespace `System.Data` � `System.Data.ArrayList`.

```csharp
using CollectionsArrayList = System.Collections.ArrayList;
using DataArrayList = System.Data.ArrayList;

CollectionsArrayList list1 = new CollectionsArrayList();
DataArrayList list2 = new DataArrayList();
```

Para evitar conflitos de nome, podemos usar um alias para um namespace. Um alias � um nome alternativo que pode ser usado para um namespace. 

Namespaces s�o �teis para organizar o c�digo-fonte e para evitar conflitos de nome. Eles tamb�m podem ser usados para definir escopos, permitindo que voc� use o mesmo nome para um elemento em diferentes partes do c�digo.

**Fully Qualified Name (FQN)**
O nome totalmente qualificado de um tipo de dados inclui o nome do namespace. Por exemplo, o nome totalmente qualificado da classe `ArrayList` no namespace `System.Collections` � `System.Collections.ArrayList`.

## Visibilidade internal
O modificador `internal` � um modificador de acesso. Ele pode ser aplicado a classes e membros de classe. Um membro de classe com o modificador `internal` s� pode ser acessado dentro do mesmo projeto (assembly). Um assembly � um arquivo execut�vel ou uma biblioteca de classes. 

```csharp
internal class Musica
{
	// ...
}

```

## Visibilidade est�tica
S�o blocos de instru��o que de alguma maneira est�o relacionados ao tipo ao qual aquele m�todo pertence, mas n�o utilizam nenhum dado ou outro m�todo de objetos do tipo. Al�m de m�todos est�ticos, tamb�m podemos criar campos est�ticos. Neste caso, o valor do campo est� associado ao tipo e n�o ao objeto. Um cen�rio muito comum � armazenar constantes associadas �quele tipo.

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
## Heran�a
Um dos pilares da orienta��o a objetos � a heran�a. Ela permite que uma classe herde caracter�sticas de outra classe. A classe que herda � chamada de classe derivada ou subclasse. A classe que � herdada � chamada de classe base ou superclasse. 

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

A classe `MusicaFavorita` herda da classe `Musica`. Isso significa que a classe `MusicaFavorita`, por exemplo, pode usar a propriedade `Nome` ou o m�todo `Tocar` da classe `Musica`, isto **se o membro for p�blico**.

Note que a sintaxe para heran�a � `class SubClasse : SuperClasse`.

## Sobreposi��o de m�todos
A sobreposi��o de m�todos � um recurso da linguagem que permite que uma classe derivada forne�a uma implementa��o espec�fica para um m�todo que j� est� implementado em uma classe base. 

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

Como vemos, para que seja poss�vel a sobreposi��o de m�todos, � necess�rio usar o modificador `virtual` na classe base e o modificador `override` na classe derivada.

Apesar de termos sobrescrito o m�todo `Tocar` na classe `MusicaFavorita`, ainda � poss�vel acessar o m�todo `Tocar` da classe `Musica` usando a palavra-chave `base`.

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

Na heran�a, classes ancestrais podem ter comportamentos substitu�dos ou sobrescritos por seus descendentes. Para indicar essa possibilidade, declaramos o membro no ancestral como virtual, e no descendente que for sobrescrev�-lo, marcamos o membro da classe com override. Se ainda assim quisermos executar a parte de c�digo que estiver no ancestral, usamos a palavra reservada base.

## Interfaces
Uma interface � um tipo de refer�ncia semelhante a uma classe, mas que s� pode conter declara��es de membros abstratos e constantes. N�o � poss�vel criar uma inst�ncia de uma interface. Uma interface � implementada por uma classe ou struct. 

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

A sintaxe para definir uma interface � `interface NomeDaInterface`. Ela define um contrato que deve ser implementado por uma classe ou struct. 

Conforme aconselhado pela Microsoft, o nome de uma interface deve come�ar com a letra `I`.

## Ancestral-raiz
Usando um atalho do Visual Studio em que digitamos a palavra `override`, seguida de um espa�o, resulta na apresenta��o de todos os m�todos que podem ser sobrescritos. Neste momento, apareceram tr�s m�todos: `ToString()`, `GetHashCode()` e `Equals()`. Afinal, de onde v�m esses m�todos?

Na verdade, todas as classes herdam de um �ancestral-raiz�: a classe `Object`. Podemos dizer que objetos criados a partir de qualquer classe s�o `Object`. E � nessa classe que est�o declarados esses tr�s m�todos.

Para que serve cada um desses m�todos?

- O m�todo `ToString()` pode ser utilizado para gerar uma representa��o textual do tipo cujo objeto pertence. A implementa��o padr�o existente em `Object` somente imprime o nome do tipo. Podemos sobrescrever esse m�todo para retornar um texto mais significativo.

- O m�todo `Equals()` retorna um valor booleano para indicar se o objeto � equivalente a outro passado como argumento do m�todo. Podemos sobrescrever esse m�todo para representar uma nova l�gica de equival�ncia.

- O m�todo `GetHashCode()` � usado em conjunto com a sobrescrita de Equals(). Em algumas cole��es, usamos um c�digo hash para identificar o objeto no conjunto. Se a condi��o de igualdade for alterada, � preciso tamb�m alterar o c�digo identificador para o objeto.
- 
## IEnumerable
A interface `IEnumerable` � usada para fornecer uma maneira de iterar sobre uma cole��o. Ela define um m�todo `GetEnumerator()`, que retorna um objeto que implementa a interface `IEnumerator`. 

Ela � �til quando queremos criar uma cole��o que pode ser percorrida, mas n�o queremos expor a implementa��o da cole��o ou permitir que a cole��o seja modificada. 

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
Para instalar uma biblioteca, primeiro precisamos nos certificar de que o projeto/solu��o est� aberto no Visual Studio. Em seguida, clicamos com o bot�o direito na op��o `Dependencies` e selecionamos a op��o `Manage NuGet Packages...`. Em seguida, clicamos na aba `Browse` e pesquisamos pela biblioteca que queremos instalar. Por fim, clicamos no bot�o `Install`.

Iremos utilizar a biblioteca `OpenAI` para gerar descri��es de m�sicas.

## Gerando descri��es de m�sicas
Para gerar descri��es de m�sicas, importamos a biblioteca `OpenAI:

```csharp
using OpenAI_API;

var client = new OpenAIClient("API_KEY");
var chat = client.Chat.CreateConversation();

chat.AppendSystemMessage("Voc� � um bot que gera descri��es de m�sicas.");

internal class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	private string? _descricao;

	public Musica Criar(Musica musica)
	{
		chat.AppendUserInput($"Gere uma descri��o para a m�sica {musica.Nome} de {musica.Artista}")
		musica._descricao = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
		_musicas.Add(musica);
	}

	/*public async Task<Musica> Criar(Musica musica)
	{
		chat.AppendUserInput($"Gere uma descri��o para a m�sica {musica.Nome} de {musica.Artista}")
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

Note que, no m�todo `Criar`, usamos o m�todo `GetResponseFromChatbotAsync` para obter a descri��o da m�sica. Dentre as possibilidades, utilizamos o m�todo `GetAwaiter` para aguardar a resposta do bot e o m�todo `GetResult` para obter o resultado. Desta forma, n�o precisamos transformar o m�todo `Criar` em `async` e nem usar o `await` para aguardar a resposta do bot.

**Quando se trata de opera��es ass�ncronas, � recomendado utilizar o `async` e o `await` para aguardar o resultado.**