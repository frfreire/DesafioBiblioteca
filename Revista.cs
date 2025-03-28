namespace DojoBiblioteca;

public class Revista : ItemBiblioteca
{
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public string Area { get; set; }
    public bool EhCientifica { get; set; }

    public Revista(string codigo, string titulo, int anoPublicacao, 
        string editora, int edicao) 
        : base(codigo, titulo, anoPublicacao)
    {
        Editora = editora;
        Edicao = edicao;
    }
    
    public override bool Emprestar(Usuario usuario, int diasEmprestimo)
    {
       
        if (EhCientifica && diasEmprestimo > 15)
            diasEmprestimo = 15;
            
        return base.Emprestar(usuario, diasEmprestimo);
    }

    public override string GerarRelatorio()
    {
        return $"{base.GerarRelatorio()}, Editora: {Editora}, " +
               $"Edição: {Edicao}, Área: {Area}, Científica: {EhCientifica}";
    }
}