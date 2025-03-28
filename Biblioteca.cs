namespace DojoBiblioteca;

public class Biblioteca
{
    private static List<string> _registroAtividades = new List<string>();
    private List<ItemBiblioteca> _acervo = new List<ItemBiblioteca>();
    private List<Usuario> _usuarios = new List<Usuario>();
    
    public IReadOnlyList<ItemBiblioteca> Acervo => _acervo.AsReadOnly();
    public IReadOnlyList<Usuario> Usuarios => _usuarios.AsReadOnly();
    public static IReadOnlyList<string> RegistroAtividades => _registroAtividades.AsReadOnly();
    
    public void AdicionarItem(ItemBiblioteca item)
    {
        _acervo.Add(item);
        RegistrarAtividade($"Item adicionado: {item.Titulo}");
    }

    public void AdicionarUsuario(Usuario usuario)
    {
        _usuarios.Add(usuario);
        RegistrarAtividade($"Usuário cadastrado: {usuario.Nome}");
    }
    
    public ItemBiblioteca BuscarItem(string codigo)
    {
        return _acervo.Find(item => item.Codigo == codigo);
    }

    public List<ItemBiblioteca> BuscarItem(string titulo, bool correspondenciaExata)
    {
        if (correspondenciaExata)
            return _acervo.FindAll(item => item.Titulo == titulo);
        else
            return _acervo.FindAll(item => item.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase));
    }

    public Usuario BuscarUsuario(int id)
    {
        return _usuarios.Find(user => user.Id == id);
    }

    public Usuario BuscarUsuario(string email)
    {
        return _usuarios.Find(user => user.Email == email);
    }


    public static void RegistrarAtividade(string descricao)
    {
        string log = $"[{DateTime.Now}] {descricao}";
        _registroAtividades.Add(log);
        Console.WriteLine(log);  // Para debug
    }


    public void ExibirEstatisticas()
    {
        int livrosDisponiveis = _acervo.Count(item => item is Livro && item.EstaDisponivel);
        int revistasDisponiveis = _acervo.Count(item => item is Revista && item.EstaDisponivel);
        int midiasDisponiveis = _acervo.Count(item => item is MidiaDigital && item.EstaDisponivel);
        int totalEmprestados = _acervo.Count(item => !item.EstaDisponivel);

        Console.WriteLine("\n==== ESTATÍSTICAS DA BIBLIOTECA ====");
        Console.WriteLine($"Total de itens: {_acervo.Count}");
        Console.WriteLine($"Livros disponíveis: {livrosDisponiveis}");
        Console.WriteLine($"Revistas disponíveis: {revistasDisponiveis}");
        Console.WriteLine($"Mídias disponíveis: {midiasDisponiveis}");
        Console.WriteLine($"Total de itens emprestados: {totalEmprestados}");
        Console.WriteLine($"Total de usuários: {_usuarios.Count}");
        Console.WriteLine("===================================\n");
    }
}