## Classes em C#
Na orientação a objetos, uma classe é uma abstração de uma entidade do mundo real. Ela é composta por atributos e métodos. Os atributos são as características da classe, e os métodos são as ações que a classe pode realizar. Programaticamente, uma classe descreve o comportamento de um objeto e como ele deve ser representado. Exemplo:

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

Repare que tanto o nome da classe quanto o nome dos atributos são escritos em PascalCase.

A palavra reservada `public` é um modificador de acesso, que define o nível de acesso que outros objetos terão a essa classe. Nesse caso, `public`, quando usado em uma classe, significa que ela pode ser acessada por qualquer outro objeto. Já quando usada em um atributo ou método, significa que eles podem ser acessados e/ou modificados por qualquer outro objeto.

### Objetos
Um objeto é uma instância de uma classe. Ou seja, é uma representação concreta de uma classe. Exemplo:

```csharp
Musica musica = new Musica();
musica.Nome = "Astronomia";
```

### Métodos
Métodos são ações/comportamentos que uma classe pode realizar. Um método pode receber zero ou mais parâmetros como entrada, realizar operações com esses parâmetros ou com outros dados internos da classe, e pode retornar um valor ou simplesmente executar ações sem retorno. Exemplo:

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
		// Código para tocar a música
	}
}

Musica musica = new Musica();
musica.Nome = "Astronomia";
musica.Tocar();
```

**Nota:** Considerando que a classe `Musica` foi declarada em outro arquivo, mas no mesmo escopo, é possível acessá-la sem a necessidade de importá-la. Porém, caso ela esteja em outro escopo, é necessário importá-la. Exemplo:

```csharp
using System;
```

### Modifiedores de acesso
Os modificadores de acesso definem o nível de acesso que outros objetos terão a um atributo ou método. Os modificadores de acesso principais são:

- `public`: o atributo ou método pode ser acessado ou modificado por qualquer outro objeto.
- `private`: o atributo ou método só pode ser acessado ou modificado pela própria classe.
- `protected`: o atributo ou método só pode ser acessado ou modificado pela própria classe ou por classes que herdam dela.

Caso deseje-se que um atributo ou método seja acessado ou modificado, de forma segura e auditada, por qualquer classe do mesmo pacote, podemos usar o conceito de encapsulamento. Exemplo:

```csharp
public class Musica
{
	public string Nome;
	private bool EstaDisponivel;

	public void EscreveDisponivel(bool value)
	{
		// Lógica para permitir ou não a modificação do atributo
		// segundo as regras de negócio
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

Desta forma, asseguramos que o atributo `EstaDisponivel` só pode ser modificado pela própria classe, segundo as regras de negócio, e que pode ser lido por qualquer outra classe.

### Getters e Setters
Getters e setters são métodos que permitem a leitura e escrita de atributos privados de uma classe. A linguagem C# possui uma sintaxe especial para getters e setters, que permite acessá-los como se fossem atributos públicos. Exemplo:

```csharp
public class Musica
{
	public string Nome { get; set; }
	// Volta a ser public, pois o getter e setter já fazem o encapsulamento
	public bool EstaDisponivel { get; set; }
}

Musica musica = new Musica();
musica.Nome = "Astronomia";
musica.EstaDisponivel = true;
```

Com esta sintaxe, como fazemos para definir regras de negócio para a escrita de um atributo? Exemplo:

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
			// Lógica para permitir ou não a modificação do atributo
			// segundo as regras de negócio
			EstaDisponivel = value;
		}
	}
}
```
## Atributos vs. Propriedades
Atributos e propriedades são conceitos diferentes. Atributos são as características de uma classe, uma variável declarada dentro que armazena dados associados a uma instância específica desta classe, enquanto propriedades são os métodos que permitem a leitura e escrita desses atributos. Exemplo:

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

No código acima, `Nome`, por exemplo, é um atributo, enquanto `Nome { get; set; }` é uma propriedade.

### Lambda
No C#, lambdas são funções anônimas que podem ser usadas para criar expressões ou blocos de código compactos e concisos. Eles são especialmente úteis quando se trata de trabalhar com coleções de dados, realizar operações em uma sequência de elementos ou lidar com delegados.. Exemplo:


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

	public bool Disponivel => EstaDisponivel ? "Sim" : "Não";
}
```
**Algumas vantagens das lambdas em relação ao código sem lambda**
- Concisão: As lambdas permitem escrever código de forma mais concisa, eliminando a necessidade de definir métodos separados para funções simples.

- Legibilidade: As lambdas são mais fáceis de ler e entender, especialmente quando o critério de filtragem ou a lógica do código é curto e direto.

- Flexibilidade: As lambdas podem ser usadas em várias situações, como filtrar, ordenar, mapear ou reduzir coleções de dados. Elas permitem que você especifique a lógica do código diretamente no local onde é necessário, sem a necessidade de criar métodos adicionais.

- Encerramento de escopo: As lambdas têm acesso às variáveis do escopo em que são definidas, o que permite que você capture e utilize valores externos dentro da expressão lambda. Isso pode ser útil em casos onde você precisa fazer referência a variáveis externas dentro de um loop, por exemplo.

**Quando não é recomendado o uso de código lambda?**
- Complexidade excessiva: Se a lógica da expressão lambda se tornar muito complexa ou difícil de entender, é preferível usar métodos e blocos de código separados para manter a clareza e legibilidade do código.

- Reutilização de código: Se você precisa reutilizar a lógica em várias partes do seu código, é mais adequado criar um método separado em vez de usar uma função lambda repetidamente. Isso promove a reutilização do código e torna mais fácil a manutenção.

- Aumento da complexidade do código: Em alguns casos, o uso excessivo de funções lambda pode tornar o código mais difícil de entender e dar manutenção, especialmente quando as expressões lambdas são aninhadas. Nesses casos, pode ser melhor dividir o código em partes menores e mais legíveis.

## Relacionamento entre classes
No C#, podemos criar um relacionamento entre classes utilizando a composição, que é uma forma de relacionamento em que uma classe possui uma instância de outra classe como um de seus membros. Isso permite que a classe tenha acesso aos membros e comportamentos da classe relacionada, como ilustra o código abaixo:

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
Construtores são métodos especiais que são executados quando uma instância de uma classe é criada. Eles são usados para inicializar os atributos de uma classe e podem receber parâmetros para definir os valores iniciais dos atributos. Exemplo:

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

Note que o construtor é um método que tem o mesmo nome da classe e não possui tipo de retorno. Como as propriedades da classe são somente leitura, elas só podem ser definidas no construtor.

Usar uma classe sem construtor no C# não garante que o objeto seja inicializado corretamente. Sem um construtor, não há um ponto de entrada definido para configurar o estado inicial do objeto. Isso pode levar a objetos em um estado inválido ou inconsistente, o que pode resultar em comportamento inesperado ou erros em tempo de execução.

## Propriedades opcionais
Em alguns casos, pode ser necessário definir propriedades opcionais, que não são obrigatórias para a criação de uma instância da classe. Para isso, podemos definir um construtor com parâmetros opcionais, que podem ser omitidos na criação da instância. Exemplo:

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

Desta forma, podemos omitir os parâmetros opcionais na criação da instância e definir os valores posteriormente, caso necessário.

**Obs:** Ao instanciar uma classe, podemos omitir o uso do construtor/tipo e definir os valores das propriedades diretamente, como no exemplo acima.


## Classes no mundo real
Aplicações orientadas geralmente possuem várias classes em suas estruturas. No entanto, é importante observar que a quantidade exata de classes pode variar dependendo do tamanho e complexidade do sistema. Esses tipos de aplicativos geralmente são compostos por várias classes que representam diferentes componentes e funcionalidades do sistema.

## Boas práticas
Ao criar sua classe, não se esqueça que uma boa classe na programação orientada a objetos possui algumas características importantes:

- **Coesão**: Uma boa classe possui responsabilidades bem definidas e coesas. Ela deve ter uma única responsabilidade e representar um conceito claro e específico dentro do domínio do problema. Isso facilita a compreensão e manutenção do código.

- **Baixo acoplamento**: Uma boa classe possui baixo acoplamento com outras classes. Ela deve depender apenas das informações e comportamentos necessários para realizar sua própria responsabilidade. Isso promove a reutilização do código e torna o sistema mais flexível e modular.

- **Encapsulamento**: Uma boa classe encapsula seus dados e comportamentos, fornecendo uma interface consistente e bem definida para interagir com outras partes do sistema. Isso ajuda a proteger os dados internos da classe e permite a evolução independente de seus detalhes internos.

- **Legibilidade e manutenibilidade**: Uma boa classe é fácil de ler, entender e manter. Ela segue convenções de nomenclatura adequadas, possui um código bem estruturado, utiliza comentários e documentação quando necessário, e segue os princípios de design de software, como o Princípio da Responsabilidade Única (SRP) e o Princípio Aberto/Fechado (OCP).

- **Reutilização**: Uma boa classe é projetada para ser reutilizável em diferentes partes do sistema. Ela pode ser facilmente adaptada e estendida para atender a novos requisitos sem modificar seu código original. Isso promove a eficiência no desenvolvimento e evita a duplicação de código.

