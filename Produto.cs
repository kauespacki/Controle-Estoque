namespace ControleEstoque;

interface IProduto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public int Quantidade { get; set; }
}

enum Categoria
{
    Eletronicos = 1,
    Moda = 2,
    Brinquedos = 3,
    Cosmeticos = 4,
    Alimentos = 5,
    Casa = 6
}

class Produto : IProduto
{
    public Produto(int id, string nome, Categoria categoria, int quantidade = 0)
    {
        Id = id;
        Nome = nome;
        Categoria = categoria;
        Quantidade = quantidade;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public int Quantidade { get; set; }
}