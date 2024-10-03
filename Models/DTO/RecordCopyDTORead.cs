namespace CSHARPAPI_VinylBook.Models.DTO
{
    public record RecordCopyDTORead(
        int Id,
        string? AlbumTitle,
        string? AlbumArtist,
        string? UserFirstName,
        string? UserLastName,
        bool? Duplicate,
        string? MediaCondition,
        string? SleeveCondition,
        string? SoundCondition,
        string? CommentPrivate,
        string? CommentPublic
        );


}