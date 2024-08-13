using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Authorization.Model.Entities
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }      
    }
}
