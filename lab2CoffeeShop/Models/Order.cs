using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab2CoffeeShop.Models;

public partial class Order
{
    public int Id { get; set; }

    [Display(Name = "Продукт")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int ProductId { get; set; }

    [Display(Name = "Покупець")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public int CustomerId { get; set; }

    [Display(Name = "Дата замовлення")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public DateTime Date { get; set; }

    [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Кількість товару повинна бути у числовому форматі")]
    [Display(Name = "Кількість (кг)")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public double Amount { get; set; }

    [Display(Name = "Покупець")]
    public virtual Customer Customer { get; set; } = null!;

    [Display(Name = "Продукт")]
    public virtual Product Product { get; set; } = null!;
}
