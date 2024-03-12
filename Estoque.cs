namespace ControleEstoque;

interface IEstoque
{
    public List<Produto> Produtos { get; set; }

    public void Adicionar(Produto produto);
    public void Remover(Produto produto);
    public void AtualizarQuantidade(Produto produto, int quantidade);
    public void Ver();
}

class Estoque : IEstoque
{
    public event EventHandler<PoucoEstoqueEventArgs> PoucoEstoque;
    public event EventHandler<EstoqueRemovidoEventArgs> EstoqueRemovido;  
    
    public Estoque()
    {
        Produtos = new List<Produto>();
    }

    public List<Produto> Produtos { get; set; }
    
    public void Adicionar(Produto produto)
    {
        Produtos.Add(produto);
    }

    public void Remover(Produto produto)
    {
        Produtos.Remove(produto);
        OnEstoqueRemovido(new EstoqueRemovidoEventArgs(produto));
    }

    public void AtualizarQuantidade(Produto produto, int quantidade)
    {
        produto.Quantidade = quantidade;
        if (quantidade <= 3)
        {
            OnPoucoEstoque(new PoucoEstoqueEventArgs(produto));
        }

        if (quantidade == 0)
        {
            Remover(produto);
        }
    }

    public void Ver()
    {
        if (Produtos.Count == 0)
        {
            Console.WriteLine("Não há nenhum produto no estoque.");
            return;
        }
        // Console.Clear();
        Console.WriteLine("Produtos");
        foreach (var produto in Produtos)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Id: {produto.Id}");
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Categoria: {produto.Categoria}");
            Console.WriteLine($"Quantidade: {produto.Quantidade}");
        }
        Console.WriteLine("-------------------------");
    }

    protected virtual void OnEstoqueRemovido(EstoqueRemovidoEventArgs e)
    {
        EstoqueRemovido?.Invoke(this, e);
    }

    protected virtual void OnPoucoEstoque(PoucoEstoqueEventArgs e)
    {
        PoucoEstoque?.Invoke(this, e);
    }
}

class PoucoEstoqueEventArgs : EventArgs
{
    public PoucoEstoqueEventArgs(Produto produto)
    {
        Produto = produto;
    }

    public Produto Produto { get; set; }
}

class EstoqueRemovidoEventArgs : EventArgs
{
    public EstoqueRemovidoEventArgs(Produto produto)
    {
        Produto = produto;
    }

    public Produto Produto { get; set; }
}