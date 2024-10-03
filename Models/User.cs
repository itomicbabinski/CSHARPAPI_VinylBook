using System.ComponentModel.DataAnnotations.Schema;

namespace CSHARPAPI_VinylBook.Models
{

        public class User : Entitet
        {
            public string? Uname { get; set; }
            public string? Ulastname { get; set; }
            public string? Uemail { get; set; }
            public string? Uphone{ get; set; }
            public string? Uaddress { get; set; }
            public ICollection<Album>? Albums { get; set; }
            public ICollection<RecordCopy>? RecordCopyes { get; set; }
    }

}
