using Microsoft.OpenApi.Expressions;
using System.ComponentModel.DataAnnotations;

namespace BlogerAPI.Model
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Status {  get; set; }
        [Required]
        public DateTime Created { get; set; } = new DateTime();
    }
}
