using System.ComponentModel.DataAnnotations;

namespace BlogerAPI.Model
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public DateTime Created { get; set; } = new DateTime();
    }
}
