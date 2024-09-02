using System.ComponentModel.DataAnnotations.Schema;

namespace CSHARPAPI_VinylBook.Models
{
 
        public class Album : Entitet
        {
            public string? Title { get; set; }
            public string? Artist { get; set; }
            public bool? Language { get; set; }
            public string? Genre { get; set; }
            
        }
   
}
