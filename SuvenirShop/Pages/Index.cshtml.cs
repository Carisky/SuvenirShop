using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuvenirShop.Models;
using SuvenirShop.Services;

namespace SuvenirShop.Pages;

public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Product Product { get; set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.FirstOrDefaultAsync(p => p.Name == "sova");

            if (Product == null)
            {
                // Handle the case where the product is not found
                Product = new Product
                {
                    Name = "Магнит \"Сова\"",
                    Price = 0,
                    Amount = 0
                };
            }
        }

        public IActionResult OnPost()
        {
            // Получение данных из формы
            var address = Request.Form["address"];
            var fullName = Request.Form["full-name"];
            var cardNumber = Request.Form["card-number"];
            var cardCVV = Request.Form["card-cvv"];
            var cardExpireDate = Request.Form["card-expire-date"];


            _logger.LogInformation($"Address: {address}, FullName: {fullName}, CardNumber: {cardNumber}, CardCVV: {cardCVV}, CardExpireDate: {cardExpireDate}");
            return RedirectToPage("/Index");
        }
    }

