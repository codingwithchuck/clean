using System;

namespace Clean.Core.Domain
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        
        public DateTime? LastModifiedDateTime { get; set; }
    }
}