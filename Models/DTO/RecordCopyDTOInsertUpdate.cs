using System.ComponentModel.DataAnnotations;

namespace CSHARPAPI_VinylBook.Models.DTO
{
    public record RecordCopyDTOInsertUpdate(
        [Required(ErrorMessage = "Album required!")]
        int? AlbumIdn,

        [Required(ErrorMessage = "User required!")]
        int? UserIdn, 

        bool? Duplicate,
        string? Media_Condition,
        string? Sleeve_Condition,
        string? Sound_Condition,
        string? Comment_Private,
        string? Comment_Public


        );


}