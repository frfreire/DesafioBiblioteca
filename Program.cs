// Criando a biblioteca

using DojoBiblioteca;

Biblioteca biblioteca = new Biblioteca();
        
// Adicionando alguns itens
biblioteca.AdicionarItem(new Livro("L001", "O Senhor dos Anéis", 1954, "J.R.R. Tolkien", "9788533613379", 1200, "Fantasia"));
biblioteca.AdicionarItem(new Livro("L002", "Fundação", 1951, "Isaac Asimov", "9788576572663", 320, "Ficção Científica"));
biblioteca.AdicionarItem(new Revista("R001", "National Geographic", 2022, "National Geographic", 135));
biblioteca.AdicionarItem(new MidiaDigital("M001", "Star Wars: Uma Nova Esperança", 1977, "DVD", 121));
        
// Adicionando usuários
biblioteca.AdicionarUsuario(new Estudante(1, "João Silva", "joao@email.com", "Engenharia", 2021));
biblioteca.AdicionarUsuario(new Professor(2, "Maria Santos", "maria@email.com", "Ciência da Computação"));
biblioteca.AdicionarUsuario(new Pesquisador(3, "Carlos Pereira", "carlos@email.com", "Instituto de Pesquisa"));
        
// Realizando operações
Usuario usuario1 = biblioteca.BuscarUsuario(1);
ItemBiblioteca item1 = biblioteca.BuscarItem("L001");
        
// Empréstimo
item1.Emprestar(usuario1, 14);
        
// Tentativa de emprestar item já emprestado
ItemBiblioteca item2 = biblioteca.BuscarItem("L002");
Usuario usuario2 = biblioteca.BuscarUsuario(2);
item2.Emprestar(usuario2, 21);
item2.Emprestar(usuario1, 14);  // Deve falhar - atingiu limite
        
// Devolução
item1.Devolver();
        
// Listando itens de um usuário
usuario2.ListarEmprestimos();
        
// Exibindo estatísticas
biblioteca.ExibirEstatisticas();
        
// Exibindo informações detalhadas
Console.WriteLine(item1.GerarRelatorio());