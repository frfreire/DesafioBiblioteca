namespace DojoBiblioteca;

public abstract class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataRegistro { get; private set; }
    public int PontosDeAtraso { get; protected set; }
    public bool TemAcessoEquipamentos { get; set; }
    
    private List<ItemBiblioteca> _itensEmprestados = new List<ItemBiblioteca>();
    
    public IReadOnlyList<ItemBiblioteca> ItensEmprestados => _itensEmprestados.AsReadOnly();
    
    public abstract int LimiteEmprestimos { get; }

    protected Usuario(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
        DataRegistro = DateTime.Now;
    }
    
    public virtual bool PodeEmprestar()
    {
        return _itensEmprestados.Count < LimiteEmprestimos && PontosDeAtraso < 5;
    }
    
    public void AdicionarEmprestimo(ItemBiblioteca item)
    {
        _itensEmprestados.Add(item);
    }

    public void RemoverEmprestimo(ItemBiblioteca item)
    {
        _itensEmprestados.Remove(item);
    }
    
    public void AplicarPenalidade(int dias)
    {
        PontosDeAtraso += dias;
    }
    
    public void ListarEmprestimos()
    {
        Console.WriteLine($"Itens emprestados para {Nome}:");
        foreach (var item in _itensEmprestados)
        {
            Console.WriteLine($"- {item.Titulo} (Devolução: {item.DataDevolucao?.ToShortDateString()})");
        }
    }
}