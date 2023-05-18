using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab2CoffeeShop.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    [Display(Name = "Назва")]
    [StringLength(60)]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; } = null!;

    [Display(Name = "Країна")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int CountryId { get; set; }

    [Display(Name = "Країна")]
    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
