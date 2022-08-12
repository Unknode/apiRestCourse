using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Model
{
    [Table("book")]
    public class Book
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
        
        [Column("publication_date")]
        public string Date { get; set; }
    }
}
