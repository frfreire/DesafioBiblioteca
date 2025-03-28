namespace DojoBiblioteca;

public class Livro : ItemBiblioteca
{
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int NumeroPaginas { get; set; }
    public string Genero { get; set; }
    
    public Livro(string codigo, string titulo, string autor) 
        : base(codigo, titulo, DateTime.Now.Year)
    {
        Autor = autor;
    }
    
    public Livro(string codigo, string titulo, int anoPublicacao, string autor, 
        string isbn, int numeroPaginas, string genero) 
        : base(codigo, titulo, anoPublicacao)
    {
        Autor = autor;
        ISBN = isbn;
        NumeroPaginas = numeroPaginas;
        Genero = genero;
    }
    
    public override string GerarRelatorio()
    {
        return $"{base.GerarRelatorio()}, Autor: {Autor}, ISBN: {ISBN}, " +
               $"Gênero: {Genero}, Páginas: {NumeroPaginas}";
    }
    
    
    
}