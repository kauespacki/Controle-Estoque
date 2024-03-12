namespace ControleEstoque;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        var estoque = new Estoque();
        var cadeira = new Produto(1, "Cadeira Gamer", Categoria.Casa, 4);
        var espelho = new Produto(2, "Espelho", Categoria.Casa, 2);
        var telefone = new Produto(3, "Telefone fixo", Categoria.Casa, 20);
        var camisa = new Produto(4, "Camisa", Categoria.Moda, 7);
        
        estoque.PoucoEstoque += OnPoucoEstoque;
        estoque.EstoqueRemovido += EstoqueOnEstoqueRemovido;
        
        estoque.Adicionar(cadeira);
        estoque.Adicionar(espelho);
        estoque.Adicionar(telefone);
        estoque.Adicionar(camisa);
        
        estoque.AtualizarQuantidade(cadeira, 10);
        estoque.AtualizarQuantidade(telefone, 3);
        estoque.AtualizarQuantidade(camisa, 2);
        estoque.AtualizarQuantidade(telefone, 0);
        estoque.Remover(espelho);
    }
    
    private static void EstoqueOnEstoqueRemovido(object? sender, EstoqueRemovidoEventArgs e)
    {
        Console.WriteLine($"!!! Estoque do produto de id {e.Produto.Id} ({e.Produto.Nome}) foi removido !!!");
    }

    static void OnPoucoEstoque(object? sender, PoucoEstoqueEventArgs e)
    {
        Console.WriteLine($"!!! Pouco estoque do produto de id {e.Produto.Id} ({e.Produto.Nome}) !!!");
        Console.WriteLine($"Estoque atual: {e.Produto.Quantidade}");
    }
}
