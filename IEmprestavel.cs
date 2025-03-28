namespace DojoBiblioteca;

public interface IEmprestavel
{
    bool EstaDisponivel { get; }
    DateTime? DataDevolucao { get; }
    bool Emprestar(Usuario usuario, int diasEmprestimo);
    bool Devolver();
}