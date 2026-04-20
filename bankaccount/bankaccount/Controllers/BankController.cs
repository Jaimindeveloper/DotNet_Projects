using Microsoft.AspNetCore.Mvc;

namespace bankaccount.Controllers
{
    public class BankController : Controller
    {
        [Route("/bank")]
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Bank Account API! Use /bank/account to manage your accounts.");
        }

        [Route("/bank/account-details")]
        public IActionResult AccountDetails()   
        {
            var bankAccount = new BankAccount
            {
                AccountNumber = "123456789",
                AccountHolderName = "John Doe",
                Balance = 1000.00m
            };

            return Json(bankAccount);
        }

        [Route("/bank/statement")]
        public IActionResult Statement()
        {
            return File("~/sample.pdf", "application/pdf", "BankStatement.pdf");
        }

        [Route("/bank/account-statement/{accountNumber}")]
        public IActionResult AccountStatement(int? accountNumber)
        {
            if (!accountNumber.HasValue)
            {
                return BadRequest("Account number is required.");
            }

            var bankAccount = new BankAccount
            {
                AccountNumber = accountNumber.Value.ToString(),
                AccountHolderName = "John Doe",
                Balance = 1000.00m
            };

            return Json(bankAccount);
        }
    }
}
