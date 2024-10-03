using System.ComponentModel.DataAnnotations;

namespace CSHARPAPI_VinylBook.Models.DTO
{
    public record AlbumDTOInsertUpdate(
        [Required(ErrorMessage = "Title required!")]
        string? Title,

        [Required(ErrorMessage = "Artist required!")]
        string? Artist,

        bool? Language,
        string? Genre


        );


}