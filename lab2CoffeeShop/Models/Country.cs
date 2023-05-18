using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab2CoffeeShop.Models;

public partial class Country
{
    public int Id { get; set; }

    [Display(Name = "Назва країни")]
    [StringLength(100)]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Manufacturer> Manufacturers { get; } = new List<Manufacturer>();
}
