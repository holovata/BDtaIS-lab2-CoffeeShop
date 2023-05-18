using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab2CoffeeShop.Models;

public partial class Product
{
    public int Id { get; set; }

    [Display(Name = "Назва")]
    [StringLength(50)]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; } = null!;

    [Display(Name = "Вид обсмажування")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int RoastId { get; set; }

    [Display(Name = "Тип кави")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int TypeId { get; set; }

    [Display(Name = "Виробник")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int ManufacturerId { get; set; }

    [Display(Name = "Ціна (грн/кг)")]
    [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Вартість товару повинна бути у числовому форматі")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public decimal Price { get; set; }

    [Display(Name = "Виробник")]
    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    [Display(Name = "Вид обсмажування")]
    public virtual CoffeeRoast Roast { get; set; } = null!;

    [Display(Name = "Тип кави")]
    public virtual CoffeeType Type { get; set; } = null!;
}
