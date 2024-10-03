using System.ComponentModel.DataAnnotations;

namespace CSHARPAPI_VinylBook.Models.DTO
{
    public record UserDTOInsertUpdate(
        [Required(ErrorMessage = "FirstName required!")]
        string? Uname,
       
        [Required(ErrorMessage = "LastName required!")]
        string? Ulastname,

        [Required(ErrorMessage = "Email required!")]
        string? Uemail,
        
        string? Uphone,
        string? Uaddress

        );


}