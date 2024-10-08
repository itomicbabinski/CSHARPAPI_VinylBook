using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CSHARPAPI_VinylBook.Models
{
 
        public class Album : Entitet
        {
            public string? Title { get; set; }
            public string? Artist { get; set; }
        
            public bool? Language { get; set; }
            public string? Genre { get; set; }

            public ICollection<RecordCopy>? RecordCopyes { get; } = [];

    }
   
}

