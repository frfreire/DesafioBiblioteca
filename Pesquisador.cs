namespace DojoBiblioteca;

public class Pesquisador : Usuario
{
    public string Instituicao { get; set; }
    public List<string> AreasInteresse { get; set; } = new List<string>();
    
    public override int LimiteEmprestimos => 5;

    public Pesquisador(int id, string nome, string email, string instituicao) 
        : base(id, nome, email)
    {
        Instituicao = instituicao;
        TemAcessoEquipamentos = true;
    }
    
    public void AdicionarAreaInteresse(string area)
    {
        AreasInteresse.Add(area);
    }
    
    public void AdicionarAreaInteresse(string[] areas)
    {
        AreasInteresse.AddRange(areas);
    }
}