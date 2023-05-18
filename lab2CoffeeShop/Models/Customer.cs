using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab2CoffeeShop.Models;

public partial class Customer
{
    //private const string RGX_EMAIL = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
    private const string RGX_EMAIL = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*)@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
    public int Id { get; set; }

    [Display(Name = "Ім'я")]
    [StringLength(50)]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Name { get; set; } = null!;

    [Display(Name = "Прізвище")]
    [StringLength(50)]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email")]
    [StringLength(50)]
    [RegularExpression(RGX_EMAIL, ErrorMessage = "Введіть коректну електронну адресу")]
    [Required(ErrorMessage = "Поле не повинно бути пустим!")]
    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
