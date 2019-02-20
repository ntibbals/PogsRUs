using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public enum PogType
    {      
        Slammer = 0,
        [Display(Name = "Milk Cap")]
        MilkCap = 1,        
    }

    /// <summary>
    /// Model for Products that will be sold.
    /// </summary>
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a SKU")]
        [Display(Name = "SKU")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "Please provide a name for your product")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select the type of pog.")]
        [Display(Name = "Pog Type")]
        public PogType PogType { get; set; }

        [Required(ErrorMessage = "Please provide a price for your product")]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please provide a description for your product")]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide an image for your product")]
        [Display(Name = "Product Image")]
        public string Image { get; set; }

    }
}
