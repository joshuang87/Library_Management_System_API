using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_API.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        public string Category_Name { get; set; }
    }
}
