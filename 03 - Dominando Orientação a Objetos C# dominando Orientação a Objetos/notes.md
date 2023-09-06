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
