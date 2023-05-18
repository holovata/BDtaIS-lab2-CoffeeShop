using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab2CoffeeShop.Models;

public partial class CoffeeType
{
    public int Id { get; set; }

    [Display(Name = "Вид кави")]
    [StringLength(30)]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
