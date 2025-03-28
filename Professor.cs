namespace DojoBiblioteca;

public class Professor : Usuario
{
    public string Departamento { get; set; }
    public string AreaPesquisa { get; set; }
    
    public override int LimiteEmprestimos => 7;

    public Professor(int id, string nome, string email, string departamento) 
        : base(id, nome, email)
    {
        Departamento = departamento;
        TemAcessoEquipamentos = true;  // Professores têm acesso por padrão
    }
    
    public override bool PodeEmprestar()
    {
        return ItensEmprestados.Count < LimiteEmprestimos;
    }
    
}