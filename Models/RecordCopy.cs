using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace CSHARPAPI_VinylBook.Models
{

    public class RecordCopy : Entitet
    {
        [ForeignKey("user")]
        public required User User { get; set; }

        [ForeignKey("album")]
        public required Album Album { get; set; }
        public bool? Duplicate { get; set; }
        public string? MediaConditiont { get; set; }
        public string? SleevConditiont { get; set; }
        public string? SoundConditiont { get; set; }
        public string? CommentPrivate { get; set; }
        public string? CommentPublic { get; set; }

     }

}