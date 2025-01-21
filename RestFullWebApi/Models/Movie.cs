using System.ComponentModel.DataAnnotations;

namespace RestFullWebApi.Models
{
    public class Movie
    {
        // Propriedade que representa o identificador único do filme (chave primária).
        public int Id { get; set; }

        // Título do filme. Campo obrigatório e com limite de 100 caracteres.
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "The Title must not exceed 100 characters.")]
        public string? Title { get; set; }

        // Gênero do filme. Campo opcional com limite de 50 caracteres.
        [StringLength(50, ErrorMessage = "The Genre must not exceed 50 characters.")]
        public string? Genre { get; set; }

        // Data de lançamento do filme. Campo opcional, mas deve ser um valor válido de data.
        [DataType(DataType.Date, ErrorMessage = "The ReleaseDate must be a valid date.")]
        public DateTime ReleaseDate { get; set; }
    }
}
