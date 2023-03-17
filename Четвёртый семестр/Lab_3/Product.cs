using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    [Serializable]
    public class Product
    {
        public Product() { }
        public Product(string Name, string ID, string Type,int Amount, double Size, double Price, string Date,  Organization Organization)
        { 
            this.Name = Name;
            this.ID = ID;
            this.Amount = Amount;
            this.Price = Price;
            this.Date = Date;
            this.Type = Type;
            this.Organization = Organization; 
        }

        public Organization? Organization { get; set; } = new Organization();
        [Required]
        [RegularExpression(@"\w+", ErrorMessage = "Неправильно введено название!")]
        public string? Name;
        public string? ID;
        public string? Type;
        public int? Amount;
        public double? Size;
        [Required]
        public double? Price;
        public string? Date;
    }
}
