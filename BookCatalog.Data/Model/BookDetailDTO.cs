using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Model;
namespace BookCatalog.Data.Model
{    
    public class BookDetailDTO
    {         
        public long Id { get; set; }        
        public string Title { get; set; }       
        public string Description { get; set; }
        public DateTime PublishDateUtc { get; set; }
        public string CategoryName { get; set; }
    }
}
