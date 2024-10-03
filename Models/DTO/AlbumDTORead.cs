namespace CSHARPAPI_VinylBook.Models.DTO
{
    public record AlbumDTORead(
        int Id,
        string? Title,
        string? Artist,
        bool? Language,
        string? Genre
        );


}