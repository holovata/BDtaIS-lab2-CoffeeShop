using lab2CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace lab2CoffeeShop.Controllers
{
    public class QueriesController : Controller
    {
        private const string CONN_STR = "Server=DESKTOP-978U9AM\\SQLEXPRESS;Database=DBCoffeeShop;Trusted_Connection=True;Trust Server Certificate=True;";

        private const string Q1_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\Q1.sql";
        private const string Q2_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\Q2.sql";
        private const string Q3_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\Q3.sql";
        private const string Q4_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\Q4.sql";
        private const string Q5_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\Q5.sql";

        private const string C1_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\C1.sql";
        private const string C2_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\C2.sql";
        private const string C3_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\C3.sql";

        private const string K1_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\K1.sql";

        private const string T1_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\T1.sql";
        private const string T2_PATH = @"C:\Work\k26\БДтІС\lab2\lab2CoffeeShop\lab2CoffeeShop\SQL\T2.sql";

        private const string ERR_ROAST = "Види обжарювання, що задовольняють дану умову, відсутні.";
        private const string ERR_CTYPE = "Типи кави, що задовольняють дану умову, відсутні.";
        private const string ERR_COUNTRY = "Країни, що задовольняють дану умову, відсутні.";
        private const string ERR_CUST = "Покупці, що задовольняють дану умову, відсутні.";
        private const string ERR_PROD = "Товари, що задовольняють дану умову, відсутні.";
        private const string ERR_MAN = "Виробники, що задовольняють дану умову, відсутні.";
        private const string ERR_ORDER = "Замовлення, що задовольняють дану умову, відсутні.";

        private const string ERR_AVG = "Неможливо обрахувати середню ціну, оскільки продукти відсутні.";
        private const string ERR_MAX = "Неможливо обрахувати максимальну ціну, оскільки продукти відсутні.";
        private const string ERR_MIN = "Неможливо обрахувати Мінімальну ціну, оскільки продукти відсутні.";
        //прописать остальные ошибки

        private readonly DbcoffeeShopContext _context;
        public QueriesController(DbcoffeeShopContext context)
        {
            _context = context;
        }

        public IActionResult Index(int errorCode)
        {
            var customers = _context.Customers.Select(c => c.Name).Distinct().ToList(); //s4
            if (errorCode == 1)
            {
                ViewBag.ErrorFlag = 1;
                ViewBag.PriceError = "Введіть коректну вартість";
            }
            if (errorCode == 2)
            {
                ViewBag.ErrorFlag = 2;
                ViewBag.ProdNameError = "Поле необхідно заповнити";
            }

            var empty = new SelectList(new List<string> { "--Пусто--" });
            //filling checkboxes
            var anyCoffeeRoasts = _context.CoffeeRoasts.Any();
            ViewBag.CoffeeRoastIds = anyCoffeeRoasts ? new SelectList(_context.CoffeeRoasts, "Id", "Id") : empty;
            ViewBag.CoffeeRoastNames = anyCoffeeRoasts ? new SelectList(_context.CoffeeRoasts, "Name", "Name") : empty;

            var anyCoffeeTypes = _context.CoffeeTypes.Any();
            ViewBag.CoffeeTypeIds = anyCoffeeTypes ? new SelectList(_context.CoffeeTypes, "Id", "Id") : empty;
            ViewBag.CoffeeTypeNames = anyCoffeeTypes ? new SelectList(_context.CoffeeTypes, "Name", "Name") : empty;

            var anyCountry = _context.Countries.Any();
            ViewBag.CountryIds = _context.Countries.Any() ? new SelectList(_context.Countries, "Id", "Id") : empty;
            ViewBag.CountryNames = _context.Countries.Any() ? new SelectList(_context.Countries, "Name", "Name") : empty;

            var anyCustomers = _context.Customers.Any();
            ViewBag.CustomerIds = anyCustomers ? new SelectList(_context.Customers, "Id", "Id") : empty;
            ViewBag.CustomerNames = anyCustomers ? new SelectList(customers) : empty;
            ViewBag.CustomerEmails = anyCustomers ? new SelectList(_context.Customers, "Email", "Email") : empty;
            ViewBag.CustomerLastNames = anyCustomers ? new SelectList(_context.Customers, "LastName", "LastName") : empty;

            var anyManufacturers = _context.Manufacturers.Any();
            ViewBag.ManufacturerIds = anyManufacturers ? new SelectList(_context.Manufacturers, "Id", "Id") : empty;
            ViewBag.ManufacturerNames = anyManufacturers ? new SelectList(_context.Manufacturers, "Name", "Name") : empty;

            var anyProducts = _context.Products.Any();
            ViewBag.ProductIds = anyProducts ? new SelectList(_context.Products, "Id", "Id") : empty;
            ViewBag.ProductNames = anyProducts ? new SelectList(_context.Products, "Name", "Name") : empty;

            var anyOrders = _context.Orders.Any();
            ViewBag.OrderIds = anyOrders ? new SelectList(_context.Orders, "Id", "Id") : empty;
            ViewBag.OrderDates = anyOrders ? new SelectList(_context.Orders, "Date", "Date") : empty;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Query1(MyQuery q) //1. Знайти продукти, які постачає виробник А
        {
            string query = System.IO.File.ReadAllText(Q1_PATH);
            query = query.Replace("A", "N\'" + q.ManufacturerName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            q.QueryId = "Q1";
            q.ProductNames = new List<string>();
            //q.ProductPrices = new List<decimal>();
            //q.CoffeeTypeNames = new List<string>();

            using (var connection = new SqlConnection(CONN_STR))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            //q.CoffeeTypeNames.Add(reader.GetString(0));
                            q.ProductNames.Add(reader.GetString(0));
                            flag++;
                        }

                        if (flag == 0)
                        {
                            q.ErrorFlag = 1;
                            q.Error = ERR_PROD;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Query2(MyQuery q) //2. Знайти середню вартість продукції, яку виробляє виробник А
        {
            string query = System.IO.File.ReadAllText(Q2_PATH);
            query = query.Replace("X", "N\'" + q.ManufacturerName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            q.QueryId = "Q2";

            using (var connection = new SqlConnection(CONN_STR))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        q.AveragePrice = Convert.ToDecimal(result);
                    }
                    else
                    {
                        q.ErrorFlag = 1;
                        q.Error = ERR_AVG;
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Query3(MyQuery q) //3. Знайти імена та пошти покупців, що придбали хоча б один продукт обжарювання В

        {
            string query = System.IO.File.ReadAllText(Q3_PATH);
            query = query.Replace("B", "N\'" + q.CoffeeRoastName + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');

            q.QueryId = "Q3";
            q.CustomerNames = new List<string>();
            q.CustomerLastNames = new List<string>();
            q.CustomerEmails = new List<string>();

            using (var connection = new SqlConnection(CONN_STR))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            q.CustomerNames.Add(reader.GetString(0));
                            q.CustomerLastNames.Add(reader.GetString(1));
                            q.CustomerEmails.Add(reader.GetString(2));
                            flag++;
                        }

                        if (flag == 0)
                        {
                            q.ErrorFlag = 1;
                            q.Error = ERR_CUST;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Query4(MyQuery q) //4. Знайти назви виробників, які виробляють продукцію не за ціною Р
        {
            if (ModelState.IsValid)
            {
                string query = System.IO.File.ReadAllText(Q4_PATH);
                query = query.Replace("J", q.ProductPrice.ToString());
                query = query.Replace("\r\n", " ");
                query = query.Replace('\t', ' ');

                q.QueryId = "Q4";
                q.ManufacturerNames = new List<string>();

                using (var connection = new SqlConnection(CONN_STR))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        using (var reader = command.ExecuteReader())
                        {
                            int flag = 0;
                            while (reader.Read())
                            {
                                q.ManufacturerNames.Add(reader.GetString(0));
                                flag++;
                            }

                            if (flag == 0)
                            {
                                q.ErrorFlag = 1;
                                q.Error = ERR_MAN;
                            }
                        }
                    }
                    connection.Close();
                }
                return RedirectToAction("Result", q);
            }
            return RedirectToAction("Index", new { errorCode = 1 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Query5(MyQuery q) //5. Знайти виробників, які не виробляють продукцію типу Y
        {
            if (ModelState.IsValid)
            {
                string query = System.IO.File.ReadAllText(Q5_PATH);
                query = query.Replace("Y", "N\'" + q.CoffeeTypeName + "\'");
                query = query.Replace("\r\n", " ");
                query = query.Replace('\t', ' ');
                q.QueryId = "Q5";
                q.ManufacturerNames = new List<string>();

                using (var connection = new SqlConnection(CONN_STR))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        using (var reader = command.ExecuteReader())
                        {
                            int flag = 0;
                            while (reader.Read())
                            {
                                q.ManufacturerNames.Add(reader.GetString(0));
                                flag++;
                            }

                            if (flag == 0)
                            {
                                q.ErrorFlag = 1;
                                q.Error = ERR_MAN;
                            }
                        }
                    }
                    connection.Close();
                }
                return RedirectToAction("Result", q);
            }

            return RedirectToAction("Index", new { errorCode = 2 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DifficultQuery1(MyQuery q) //1. Знайти імена, прізвища та пошти покупців, що прибдали точно ті ж продукти, що і покупець Z
        {
            string query = System.IO.File.ReadAllText(C1_PATH);
            query = query.Replace("Z", "N\'" + q.CustomerEmail.ToString() + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');
            q.QueryId = "C1";
            q.CustomerNames = new List<string>();
            q.CustomerLastNames = new List<string>();
            q.CustomerEmails = new List<string>();

            using (var connection = new SqlConnection(CONN_STR))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            q.CustomerNames.Add(reader.GetString(0));
                            q.CustomerLastNames.Add(reader.GetString(1));
                            q.CustomerEmails.Add(reader.GetString(2));
                            flag++;
                        }

                        if (flag == 0)
                        {
                            q.ErrorFlag = 1;
                            q.Error = ERR_CUST;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DifficultQuery2(MyQuery q) //2. Знайти пошти покупців з прізвищем Z, що придбали всі продукти магазину
        {
            string query = System.IO.File.ReadAllText(C2_PATH);
            query = query.Replace("Z", "N\'" + q.CustomerLastName.ToString() + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');
            q.QueryId = "C2";
            q.CustomerLastNames = new List<string>();
            q.CustomerEmails = new List<string>();

            using (var connection = new SqlConnection(CONN_STR))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            q.CustomerLastNames.Add(reader.GetString(0));
                            q.CustomerEmails.Add(reader.GetString(1));
                            flag++;
                        }

                        if (flag == 0)
                        {
                            q.ErrorFlag = 1;
                            q.Error = ERR_CUST;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", q);
        }

        public IActionResult DifficultQuery3(MyQuery q)
        {
            string query = System.IO.File.ReadAllText(C3_PATH);
            query = query.Replace("Z", q.ManufacturerId.ToString());
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');
            q.QueryId = "C3";
            q.CountryNames = new List<string>();

            using (var connection = new SqlConnection(CONN_STR))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        int flag = 0;
                        while (reader.Read())
                        {
                            q.CountryNames.Add(reader.GetString(0));
                            flag++;
                        }

                        if (flag == 0)
                        {
                            q.ErrorFlag = 1;
                            q.Error = ERR_COUNTRY;
                        }
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", q);
        }
        public IActionResult KQuery1(MyQuery q)
        {
            string query = System.IO.File.ReadAllText(K1_PATH);
            query = query.Replace("Z", "N\'" + q.CustomerLastName.ToString() + "\'");
            query = query.Replace("\r\n", " ");
            query = query.Replace('\t', ' ');
            q.QueryId = "K1";

            using (var connection = new SqlConnection(CONN_STR))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        q.MaximumPrice = Convert.ToDecimal(result);
                    }
                    else
                    {
                        q.ErrorFlag = 1;
                        q.Error = ERR_AVG;
                    }
                }
                connection.Close();
            }
            return RedirectToAction("Result", q);

        }

        public IActionResult TeacherQuery1(MyQuery q)
        {
            throw new NotImplementedException();

        }

        public IActionResult TeacherQuery2(MyQuery q)
        {
            throw new NotImplementedException();
            
        }

        public IActionResult Result(MyQuery queryResult)
        {
            return View(queryResult);
        }

    }
}
