namespace CSHARPAPI_VinylBook.Models.DTO
{
    public record RecordCopyDTORead(
        int Id,
        string? AlbumInfo,
        string? UserInfo,
        bool? Duplicate,
        string? Media_Condition,
        string? Sleeve_Condition,
        string? Sound_Condition,
        string? Comment_Private,
        string? Comment_Public
        );


}