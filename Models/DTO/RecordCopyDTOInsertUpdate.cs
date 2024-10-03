using System.ComponentModel.DataAnnotations;

namespace CSHARPAPI_VinylBook.Models.DTO
{
    public record RecordCopyDTOInsertUpdate(
        [Required(ErrorMessage = "Album required!")]
        int? AlbumId,

        [Required(ErrorMessage = "User required!")]
        int? UserId, 

        bool? Duplicate,
        string? MediaCondition,
        string? SleeveCondition,
        string? SoundCondition,
        string? CommentPrivate,
        string? CommentPublic


        );


}