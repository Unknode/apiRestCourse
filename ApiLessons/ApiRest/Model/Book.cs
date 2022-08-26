using System.ComponentModel.DataAnnotations.Schema;
using ApiRest.Model.Base;

namespace ApiRest.Model
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("title")]
        public string Title { get; set; }
        
        [Column("publication_date")]
        public string Date { get; set; }
    }
}
