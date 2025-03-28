namespace DojoBiblioteca;

public class MidiaDigital : ItemBiblioteca
{
    public string Tipo { get; set; }  // DVD, CD, Blu-ray, etc.
    public string Diretor { get; set; }
    public int Duracao { get; set; }  // em minutos
    public bool RequerEquipamento { get; set; }

    public MidiaDigital(string codigo, string titulo, int anoPublicacao, 
        string tipo, int duracao) 
        : base(codigo, titulo, anoPublicacao)
    {
        Tipo = tipo;
        Duracao = duracao;
        RequerEquipamento = true;
    }
    
    public override bool Emprestar(Usuario usuario, int diasEmprestimo)
    {
        if (RequerEquipamento && !usuario.TemAcessoEquipamentos)
        {
            Biblioteca.RegistrarAtividade($"Tentativa de empréstimo de mídia negada: {usuario.Nome} não tem acesso a equipamentos");
            return false;
        }
            
        return base.Emprestar(usuario, diasEmprestimo);
    }

    public override string GerarRelatorio()
    {
        return $"{base.GerarRelatorio()}, Tipo: {Tipo}, " +
               $"Diretor: {Diretor}, Duração: {Duracao} min";
    }
    
}