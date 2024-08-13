using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuth.Data.Entities
{
    [Table("Category", Schema ="dbo")]
    public class Category
    {
        [Key]        
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }      
        public ICollection<BookDTO> Books { get; set; } = new List<BookDTO>();
    }
}
