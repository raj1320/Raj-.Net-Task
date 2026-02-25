using System.ComponentModel.DataAnnotations;

namespace ASP.NETCORE_WEB_API_Project1.Application.DTOs
{
    public class DeleteProductDTO
    {
      
        public int Id { get; set; }
        public string Name { get; set; } =  string.Empty;
    }
}
