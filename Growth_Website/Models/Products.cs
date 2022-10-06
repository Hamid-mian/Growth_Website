using Microsoft.EntityFrameworkCore;

namespace Growth_Website.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string? imagename { get; set; }
        public string? productName {get;set;}
        public int price { get; set; }
      
        public string? productType { get; set; }

        public string? createdByUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
