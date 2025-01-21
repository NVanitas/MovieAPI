using Microsoft.EntityFrameworkCore;

namespace RestFullWebApi.Models
{
    // Classe que representa o contexto do banco de dados para a aplicação.
    // O DbContext é responsável pela comunicação entre a aplicação e o banco de dados.
    public class MovieContext : DbContext
    {
        // Construtor que recebe as opções de configuração para o contexto do banco de dados.
        // Essas opções são passadas para o construtor da classe base DbContext.
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        // DbSet que representa a coleção de filmes no banco de dados.
        // Cada instância de Movie corresponde a uma linha na tabela 'Movies' do banco de dados.
        // O null! é utilizado para desabilitar a análise de nulidade do compilador, indicando que a propriedade será inicializada corretamente.
        public DbSet<Movie> Movies { get; set; } = null!;
    }
}
