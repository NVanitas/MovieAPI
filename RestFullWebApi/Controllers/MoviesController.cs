using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFullWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestFullWebApi.Controllers
{
    // Define a rota base para o controlador: "api/Movies"
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // Campo para o contexto do banco de dados
        private readonly MovieContext _movieContext;

        // Construtor que recebe o contexto por injeção de dependência
        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        // GET: api/Movies
        /// <summary>
        /// Retorna todos os filmes cadastrados no banco de dados.
        /// </summary>
        /// <returns>Uma lista de filmes ou um status 404 se o banco estiver indisponível.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_movieContext.Movies == null)
            {
                return NotFound("Movies database is not available.");
            }

            // Retorna todos os filmes como uma lista
            return await _movieContext.Movies.ToListAsync();
        }

        // GET: api/Movies/{id}
        /// <summary>
        /// Retorna um filme específico com base no ID.
        /// </summary>
        /// <param name="id">ID do filme.</param>
        /// <returns>O filme correspondente ou um status 404 se não for encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_movieContext.Movies == null)
            {
                return NotFound("Movies database is not available.");
            }

            // Busca o filme pelo ID
            var movie = await _movieContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound($"No movie found with ID {id}.");
            }

            return movie;
        }

        // POST: api/Movies
        /// <summary>
        /// Adiciona um novo filme ao banco de dados.
        /// </summary>
        /// <param name="movie">Objeto filme a ser adicionado.</param>
        /// <returns>O filme recém-criado e seu status.</returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            if (_movieContext.Movies == null)
            {
                return Problem("Movies database is not available.");
            }

            // Adiciona o filme ao banco de dados
            _movieContext.Movies.Add(movie);
            await _movieContext.SaveChangesAsync();

            // Retorna o filme criado com o status 201 (Created)
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT: api/Movies/{id}
        /// <summary>
        /// Atualiza os dados de um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="movie">Dados atualizados do filme.</param>
        /// <returns>Status 204 (No Content) se bem-sucedido ou erros apropriados.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            // Verifica se o ID do parâmetro corresponde ao ID no corpo da requisição
            if (id != movie.Id)
            {
                return BadRequest("The ID in the route does not match the ID in the request body.");
            }

            if (_movieContext.Movies == null)
            {
                return NotFound("Movies database is not available.");
            }

            // Marca o estado do filme como modificado
            _movieContext.Entry(movie).State = EntityState.Modified;

            try
            {
                // Salva as alterações no banco de dados
                await _movieContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Verifica se o filme existe antes de lançar uma exceção
                if (!MovieExists(id))
                {
                    return NotFound($"No movie found with ID {id}.");
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Movies/{id}
        /// <summary>
        /// Remove um filme existente do banco de dados.
        /// </summary>
        /// <param name="id">ID do filme a ser removido.</param>
        /// <returns>Status 204 (No Content) se bem-sucedido ou erros apropriados.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_movieContext.Movies == null)
            {
                return NotFound("Movies database is not available.");
            }

            // Busca o filme pelo ID
            var movie = await _movieContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound($"No movie found with ID {id}.");
            }

            // Remove o filme do banco de dados
            _movieContext.Movies.Remove(movie);
            await _movieContext.SaveChangesAsync();

            return NoContent();
        }

        // Método privado para verificar se um filme existe pelo ID
        private bool MovieExists(int id)
        {
            return _movieContext.Movies?.Any(m => m.Id == id) ?? false;
        }
    }
}
