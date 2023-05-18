using System.ComponentModel.DataAnnotations;

namespace lab2CoffeeShop.Models
{
    public class MyQuery
    {
        public string QueryId { get; set; }
        public string Error { get; set; }
        public int ErrorFlag { get; set; }

        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        public string CoffeeRoastName { get; set; }
        public List<string> CoffeeRoastNames { get; set; }
        public int CoffeeRoastId { get; set; }
        public List<int> CoffeeRoastIds { get; set; }

        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        public string CoffeeTypeName { get; set; }
        public List<string> CoffeeTypeNames { get; set; }
        public int CoffeeTypeId { get; set; }
        public List<int> CoffeeTypeIds { get; set; }

        public int CountryId { get; set; }
        public List<string> CountryIds { get; set; }
        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        public string CountryName { get; set; }
        public List<string> CountryNames { get; set; }

        public List<string> CustomerIds { get; set; }
        public List<string> CustomerNames { get; set; }
        public List<string> CustomerLastNames { get; set; }
        public List<string> CustomerEmails { get; set; }
        public int CustomerId { get; set; }
        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        public string CustomerName { get; set; }
       // [Required(ErrorMessage = "Поле необхідно заповнити")]
        public string CustomerLastName { get; set; }
        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        public string CustomerEmail { get; set; }

        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        public string ManufacturerName { get; set; }
        public List<string> ManufacturerNames { get; set; }
        public int ManufacturerId { get; set; }
        public List<int> ManufacturerIds { get; set; }

        public int OrderId { get; set; }
        public List<int> OrderIds { get; set; }
        public DateTime OrderDate { get; set; }
        public List<DateTime> OrderDates { get; set; }
        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Введіть коректну кількість")]
        public double OrderAmount { get; set; }

        public int ProductId { get; set; }
        public List<int> ProductIds { get; set; }
        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        public string ProductName { get; set; }
        public List<string> ProductNames { get; set; }
        //[Required(ErrorMessage = "Поле необхідно заповнити")]
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "Введіть коректну вартість")]
        //[Display(Name = "Вартість")]
        public decimal ProductPrice { get; set; }
        public List<decimal> ProductPrices { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal MaximumPrice { get; set; }

    }
}
