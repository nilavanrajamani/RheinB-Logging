using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using EarlyInitializationSample.Models;
using Microsoft.Extensions.Logging;
using Serilog;
using EarlyInitializationSample.Entities;
using EarlyInitializationSample.Data.Interfaces;
using EarlyInitializationSample.Data;
using Newtonsoft.Json;

namespace EarlyInitializationSample.Controllers
{
    public class HomeController : Controller
    {
        static int _callCount;

        readonly ILogger<HomeController> _logger;
        readonly IDiagnosticContext _diagnosticContext;
        private readonly IDataRepositoryCatalog dataRepositoryCatalog;

        public HomeController(ILogger<HomeController> logger, IDiagnosticContext diagnosticContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _diagnosticContext = diagnosticContext ?? throw new ArgumentNullException(nameof(diagnosticContext));
            this.dataRepositoryCatalog = new DataRepositoryCatalog(logger);
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello, world!");
            _diagnosticContext.Set("IndexCallCount", Interlocked.Increment(ref _callCount));

            return View();
        }

        public IActionResult Privacy()
        {
            throw new InvalidOperationException("Something went wrong.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddPerson()
        {
            Person person = new Person();
            person.FirstName = "Nilavan";
            person.LastName = "Rajamani";
            person.Address = "Chennai";

            //Perform AddOperartion  
            dataRepositoryCatalog.PersonRepository.Add(person);
            return Content(JsonConvert.SerializeObject(person), "application/json");
        }

        public IActionResult UpdateAddress()
        {
            Address address = new Address();
            address.Street = "Street1";
            address.Door = "Door";
            address.Pincode = "Pincode";

            //Perform AddOperartion  
            dataRepositoryCatalog.AddressRepository.Update(address);
            return Json(address);
        }

        public IActionResult DeleteCompany()
        {
            Company company = new Company();
            company.Address = "CompanyAddress";
            company.Name = "CompanyName";            

            //Perform AddOperartion  
            dataRepositoryCatalog.CompanyRepository.Delete(company);
            return Json(company);
        }
    }
}
