using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Model
{    
    public class Category
    {         
        public int Id { get; set; }        
        public int Name { get; set; }        
    }
}
