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