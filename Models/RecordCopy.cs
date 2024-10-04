using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CSHARPAPI_VinylBook.Models
{
 
    public class RecordCopy : Entitet
    {
        [ForeignKey("owner_id")]
        public required User User { get; set; }

        [ForeignKey("album_id")]
        public required Album Album { get; set; }
        public bool? Duplicate { get; set; }
        public string? Media_Condition { get; set; }
        public string? Sleeve_Condition { get; set; }
        public string? Sound_Condition { get; set; }
        public string? Comment_Private { get; set; }

        public string? Comment_Public { get; set; }

     }



}