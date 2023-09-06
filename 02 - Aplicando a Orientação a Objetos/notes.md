## Classes em C#
Na orienta��o a objetos, uma classe � uma abstra��o de uma entidade do mundo real. Ela � composta por atributos e m�todos. Os atributos s�o as caracter�sticas da classe, e os m�todos s�o as a��es que a classe pode realizar. Programaticamente, uma classe descreve o comportamento de um objeto e como ele deve ser representado. Exemplo:

```csharp
public class Musica
{
	public string Nome;
	public string Artista;
	public string Album;
	public string Genero;
	public int Ano;
	public string Duracao;
}
```

Repare que tanto o nome da classe quanto o nome dos atributos s�o escritos em PascalCase.

A palavra reservada `public` � um modificador de acesso, que define o n�vel de acesso que outros objetos ter�o a essa classe. Nesse caso, `public`, quando usado em uma classe, significa que ela pode ser acessada por qualquer outro objeto. J� quando usada em um atributo ou m�todo, significa que eles podem ser acessados e/ou modificados por qualquer outro objeto.

### Objetos
Um objeto � uma inst�ncia de uma classe. Ou seja, � uma representa��o concreta de uma classe. Exemplo:

```csharp
Musica musica = new Musica();
musica.Nome = "Astronomia";
```

### M�todos
M�todos s�o a��es/comportamentos que uma classe pode realizar. Um m�todo pode receber zero ou mais par�metros como entrada, realizar opera��es com esses par�metros ou com outros dados internos da classe, e pode retornar um valor ou simplesmente executar a��es sem retorno. Exemplo:

```csharp
public class Musica
{
	public string Nome;
	public string Artista;
	public string Album;
	public string Genero;
	public int Ano;
	public string Duracao;
	
	public void Tocar()
	{
		// C�digo para tocar a m�sica
	}
}

Musica musica = new Musica();
musica.Nome = "Astronomia";
musica.Tocar();
```

**Nota:** Considerando que a classe `Musica` foi declarada em outro arquivo, mas no mesmo escopo, � poss�vel acess�-la sem a necessidade de import�-la. Por�m, caso ela esteja em outro escopo, � necess�rio import�-la. Exemplo:

```csharp
using System;
```

### Modifiedores de acesso
Os modificadores de acesso definem o n�vel de acesso que outros objetos ter�o a um atributo ou m�todo. Os modificadores de acesso principais s�o:

- `public`: o atributo ou m�todo pode ser acessado ou modificado por qualquer outro objeto.
- `private`: o atributo ou m�todo s� pode ser acessado ou modificado pela pr�pria classe.
- `protected`: o atributo ou m�todo s� pode ser acessado ou modificado pela pr�pria classe ou por classes que herdam dela.

Caso deseje-se que um atributo ou m�todo seja acessado ou modificado, de forma segura e auditada, por qualquer classe do mesmo pacote, podemos usar o conceito de encapsulamento. Exemplo:

```csharp
public class Musica
{
	public string Nome;
	private bool EstaDisponivel;

	public void EscreveDisponivel(bool value)
	{
		// L�gica para permitir ou n�o a modifica��o do atributo
		// segundo as regras de neg�cio
		EstaDisponivel = value;
	}

	public bool LeDisponivel()
	{
		return EstaDisponivel;
	}
}

Musica musica = new Musica();
musica.Nome = "Astronomia";
musica.EscreveDisponivel(true);
Console.WriteLine(musica.LeDisponivel());
```

Desta forma, asseguramos que o atributo `EstaDisponivel` s� pode ser modificado pela pr�pria classe, segundo as regras de neg�cio, e que pode ser lido por qualquer outra classe.

### Getters e Setters
Getters e setters s�o m�todos que permitem a leitura e escrita de atributos privados de uma classe. A linguagem C# possui uma sintaxe especial para getters e setters, que permite acess�-los como se fossem atributos p�blicos. Exemplo:

```csharp
public class Musica
{
	public string Nome { get; set; }
	// Volta a ser public, pois o getter e setter j� fazem o encapsulamento
	public bool EstaDisponivel { get; set; }
}

Musica musica = new Musica();
musica.Nome = "Astronomia";
musica.EstaDisponivel = true;
```

Com esta sintaxe, como fazemos para definir regras de neg�cio para a escrita de um atributo? Exemplo:

```csharp
public class Musica
{
	private bool EstaDisponivel;

	public bool Disponivel
	{
		get
		{
			return EstaDisponivel;
		}
		set
		{
			// L�gica para permitir ou n�o a modifica��o do atributo
			// segundo as regras de neg�cio
			EstaDisponivel = value;
		}
	}
}
```
## Atributos vs. Propriedades
Atributos e propriedades s�o conceitos diferentes. Atributos s�o as caracter�sticas de uma classe, uma vari�vel declarada dentro que armazena dados associados a uma inst�ncia espec�fica desta classe, enquanto propriedades s�o os m�todos que permitem a leitura e escrita desses atributos. Exemplo:

```csharp
public class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }
	public string Duracao { get; set; }
}
```

No c�digo acima, `Nome`, por exemplo, � um atributo, enquanto `Nome { get; set; }` � uma propriedade.

### Lambda
No C#, lambdas s�o fun��es an�nimas que podem ser usadas para criar express�es ou blocos de c�digo compactos e concisos. Eles s�o especialmente �teis quando se trata de trabalhar com cole��es de dados, realizar opera��es em uma sequ�ncia de elementos ou lidar com delegados.. Exemplo:


```csharp
public class Musica
{
	private bool EstaDisponivel;

	public bool Disponivel
	{
		get => EstaDisponivel;
		set => EstaDisponivel = value;
	}
}
```

Ou apenas no getter:

```csharp
public class Musica
{
	private bool EstaDisponivel;

	public bool Disponivel => EstaDisponivel ? "Sim" : "N�o";
}
```
**Algumas vantagens das lambdas em rela��o ao c�digo sem lambda**
- Concis�o: As lambdas permitem escrever c�digo de forma mais concisa, eliminando a necessidade de definir m�todos separados para fun��es simples.

- Legibilidade: As lambdas s�o mais f�ceis de ler e entender, especialmente quando o crit�rio de filtragem ou a l�gica do c�digo � curto e direto.

- Flexibilidade: As lambdas podem ser usadas em v�rias situa��es, como filtrar, ordenar, mapear ou reduzir cole��es de dados. Elas permitem que voc� especifique a l�gica do c�digo diretamente no local onde � necess�rio, sem a necessidade de criar m�todos adicionais.

- Encerramento de escopo: As lambdas t�m acesso �s vari�veis do escopo em que s�o definidas, o que permite que voc� capture e utilize valores externos dentro da express�o lambda. Isso pode ser �til em casos onde voc� precisa fazer refer�ncia a vari�veis externas dentro de um loop, por exemplo.

**Quando n�o � recomendado o uso de c�digo lambda?**
- Complexidade excessiva: Se a l�gica da express�o lambda se tornar muito complexa ou dif�cil de entender, � prefer�vel usar m�todos e blocos de c�digo separados para manter a clareza e legibilidade do c�digo.

- Reutiliza��o de c�digo: Se voc� precisa reutilizar a l�gica em v�rias partes do seu c�digo, � mais adequado criar um m�todo separado em vez de usar uma fun��o lambda repetidamente. Isso promove a reutiliza��o do c�digo e torna mais f�cil a manuten��o.

- Aumento da complexidade do c�digo: Em alguns casos, o uso excessivo de fun��es lambda pode tornar o c�digo mais dif�cil de entender e dar manuten��o, especialmente quando as express�es lambdas s�o aninhadas. Nesses casos, pode ser melhor dividir o c�digo em partes menores e mais leg�veis.

## Relacionamento entre classes
No C#, podemos criar um relacionamento entre classes utilizando a composi��o, que � uma forma de relacionamento em que uma classe possui uma inst�ncia de outra classe como um de seus membros. Isso permite que a classe tenha acesso aos membros e comportamentos da classe relacionada, como ilustra o c�digo abaixo:

```csharp
public class Musica
{
	public string Nome { get; set; }
	public string Artista { get; set; }
	public string Album { get; set; }
	public string Genero { get; set; }
	public int Ano { get; set; }
	public string Duracao { get; set; }
}

public class Playlist
{
	public string Nome { get; set; }
	public List<Musica> Musicas { get; set; }
}
```
## Construtores
Construtores s�o m�todos especiais que s�o executados quando uma inst�ncia de uma classe � criada. Eles s�o usados para inicializar os atributos de uma classe e podem receber par�metros para definir os valores iniciais dos atributos. Exemplo:

```csharp
public class Musica
{
	public string Nome { get; }
	public string Artista { get; }
	public string Album { get; }
	public string Genero { get; }
	public int Ano { get; }
	public string Duracao { get; }

	public Musica(string nome, string artista, string album, string genero, int ano, string duracao)
	{
		Nome = nome;
		Artista = artista;
		Album = album;
		Genero = genero;
		Ano = ano;
		Duracao = duracao;
	}
}

Musica musica = new Musica("Nome", "Artista", "Album", "Genero", 2021, "3:00");
```

Note que o construtor � um m�todo que tem o mesmo nome da classe e n�o possui tipo de retorno. Como as propriedades da classe s�o somente leitura, elas s� podem ser definidas no construtor.

Usar uma classe sem construtor no C# n�o garante que o objeto seja inicializado corretamente. Sem um construtor, n�o h� um ponto de entrada definido para configurar o estado inicial do objeto. Isso pode levar a objetos em um estado inv�lido ou inconsistente, o que pode resultar em comportamento inesperado ou erros em tempo de execu��o.

## Propriedades opcionais
Em alguns casos, pode ser necess�rio definir propriedades opcionais, que n�o s�o obrigat�rias para a cria��o de uma inst�ncia da classe. Para isso, podemos definir um construtor com par�metros opcionais, que podem ser omitidos na cria��o da inst�ncia. Exemplo:

```csharp
public class Musica
{
	public string Nome { get; }
	public string Artista { get; }
	public string Album { get; }
	public string Genero { get; }
	public int Ano { get; set; }
	public string Duracao { get; set; }

	public Musica(string nome, string artista, string album, string genero)
	{
		Nome = nome;
		Artista = artista;
		Album = album;
		Genero = genero;
		Ano = ano;
		Duracao = duracao;
	}
}

Musica musica = new("Nome", "Artista", "Album", "Genero") { Ano = 2021, Duracao = "3:00" };
```

Desta forma, podemos omitir os par�metros opcionais na cria��o da inst�ncia e definir os valores posteriormente, caso necess�rio.

**Obs:** Ao instanciar uma classe, podemos omitir o uso do construtor/tipo e definir os valores das propriedades diretamente, como no exemplo acima.


## Classes no mundo real
Aplica��es orientadas geralmente possuem v�rias classes em suas estruturas. No entanto, � importante observar que a quantidade exata de classes pode variar dependendo do tamanho e complexidade do sistema. Esses tipos de aplicativos geralmente s�o compostos por v�rias classes que representam diferentes componentes e funcionalidades do sistema.

## Boas pr�ticas
Ao criar sua classe, n�o se esque�a que uma boa classe na programa��o orientada a objetos possui algumas caracter�sticas importantes:

- **Coes�o**: Uma boa classe possui responsabilidades bem definidas e coesas. Ela deve ter uma �nica responsabilidade e representar um conceito claro e espec�fico dentro do dom�nio do problema. Isso facilita a compreens�o e manuten��o do c�digo.

- **Baixo acoplamento**: Uma boa classe possui baixo acoplamento com outras classes. Ela deve depender apenas das informa��es e comportamentos necess�rios para realizar sua pr�pria responsabilidade. Isso promove a reutiliza��o do c�digo e torna o sistema mais flex�vel e modular.

- **Encapsulamento**: Uma boa classe encapsula seus dados e comportamentos, fornecendo uma interface consistente e bem definida para interagir com outras partes do sistema. Isso ajuda a proteger os dados internos da classe e permite a evolu��o independente de seus detalhes internos.

- **Legibilidade e manutenibilidade**: Uma boa classe � f�cil de ler, entender e manter. Ela segue conven��es de nomenclatura adequadas, possui um c�digo bem estruturado, utiliza coment�rios e documenta��o quando necess�rio, e segue os princ�pios de design de software, como o Princ�pio da Responsabilidade �nica (SRP) e o Princ�pio Aberto/Fechado (OCP).

- **Reutiliza��o**: Uma boa classe � projetada para ser reutiliz�vel em diferentes partes do sistema. Ela pode ser facilmente adaptada e estendida para atender a novos requisitos sem modificar seu c�digo original. Isso promove a efici�ncia no desenvolvimento e evita a duplica��o de c�digo.

