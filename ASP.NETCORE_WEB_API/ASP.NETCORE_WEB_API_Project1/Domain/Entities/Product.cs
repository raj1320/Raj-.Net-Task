using ASP.NETCORE_WEB_API_Project1.Domain.Enums;

namespace ASP.NETCORE_WEB_API_Project1.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = 0;
        public decimal  Price {  get; set; }
        public string VandorName {  get; set; }=string.Empty;
        public int Stock {  get; set; }
        public bool IsAvailable { get; set; } = false;
    }
}
