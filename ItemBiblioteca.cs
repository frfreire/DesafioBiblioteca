namespace DojoBiblioteca;

public abstract class ItemBiblioteca : IEmprestavel, IRelatorio
{
    public string Codigo { get; private set; }
    public string Titulo { get; set; }
    public int AnoPublicacao { get; set; }
    public bool EstaDisponivel { get; protected set; } = true;
    public Usuario UsuarioAtual { get; protected set; }
    public DateTime? DataEmprestimo { get; protected set; }
    public DateTime? DataDevolucao { get; protected set; }
    
    public ItemBiblioteca(string codigo, string titulo, int anoPublicacao)
    {
        Codigo = codigo;
        Titulo = titulo;
        AnoPublicacao = anoPublicacao;
    }
    
    public virtual bool Emprestar(Usuario usuario, int diasEmprestimo)
    {
        if (!EstaDisponivel)
            return false;

        if (!usuario.PodeEmprestar())
            return false;

        EstaDisponivel = false;
        UsuarioAtual = usuario;
        DataEmprestimo = DateTime.Now;
        DataDevolucao = DateTime.Now.AddDays(diasEmprestimo);
        
        usuario.AdicionarEmprestimo(this);
        Biblioteca.RegistrarAtividade($"Item {Codigo} emprestado para {usuario.Nome}");
        
        return true;
    }
    
    public virtual bool Devolver()
    {
        if (EstaDisponivel)
            return false;

        EstaDisponivel = true;
        
        // Verifica atraso e aplica penalidade se necessário
        if (DateTime.Now > DataDevolucao)
        {
            TimeSpan atraso = DateTime.Now - DataDevolucao.Value;
            UsuarioAtual.AplicarPenalidade((int)atraso.TotalDays);
            Biblioteca.RegistrarAtividade($"Item {Codigo} devolvido com atraso de {(int)atraso.TotalDays} dias");
        }
        else
        {
            Biblioteca.RegistrarAtividade($"Item {Codigo} devolvido");
        }

        UsuarioAtual.RemoverEmprestimo(this);
        UsuarioAtual = null;
        DataEmprestimo = null;
        DataDevolucao = null;
        
        return true;
    }
    
    public virtual string GerarRelatorio()
    {
        return $"Código: {Codigo}, Título: {Titulo}, Ano: {AnoPublicacao}, " +
               $"Disponível: {EstaDisponivel}";
    }
    
}