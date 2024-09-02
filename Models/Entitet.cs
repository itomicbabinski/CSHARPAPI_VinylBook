using System.ComponentModel.DataAnnotations;

namespace CSHARPAPI_VinylBook.Models
{
    public abstract class Entitet
    {
        [Key]
        public int Id { get; set; }
    }
}
