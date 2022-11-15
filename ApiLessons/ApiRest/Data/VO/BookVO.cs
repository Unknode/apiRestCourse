using ApiRest.Model.Base;

namespace ApiRest.Data.VO
{
    public class BookVO : BaseEntity
    { 
        public string Author { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
    }
}
