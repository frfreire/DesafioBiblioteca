namespace DojoBiblioteca;

public class Estudante : Usuario
{
    public string Curso { get; set; }
    public int AnoIngresso { get; set; }
    
    public override int LimiteEmprestimos => 3;
    
    public Estudante(int id, string nome, string email, string curso, int anoIngresso) 
        : base(id, nome, email)
    {
        Curso = curso;
        AnoIngresso = anoIngresso;
        TemAcessoEquipamentos = false;  // Estudantes não têm acesso por padrão
    }
}