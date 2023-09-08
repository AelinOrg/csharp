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