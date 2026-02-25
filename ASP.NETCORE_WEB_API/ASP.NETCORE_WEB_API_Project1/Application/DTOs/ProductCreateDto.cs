using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace ASP.NETCORE_WEB_API_Project1.Application.DTOs
{
    public class ProductCreateDto
    {

        [Required,MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50,ErrorMessage = "Keep Description short!")]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public Category Category { get; set; } = 0;

        [Required,MaxLength(100)]
        public string VandorName { get; set; } = string.Empty;

        [Required,Range(0,1000,ErrorMessage = "Stock overflow!")]
        public int Stock { get; set; }


        [Required,Range(0,10000,ErrorMessage ="Price reach maximum limit!")]
        public decimal Price { get; set; }
    }
}

