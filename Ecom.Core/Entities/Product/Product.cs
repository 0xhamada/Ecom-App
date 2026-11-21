using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Ecom.Core.Entities.Product
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }

        public virtual List<Photo> Photos { get; set; } = new List<Photo>();
        public int CategoryId { get;set; }
        [ForeignKey(nameof(CategoryId))]
        
        public virtual Category Categories { get; set; }
    }
}
