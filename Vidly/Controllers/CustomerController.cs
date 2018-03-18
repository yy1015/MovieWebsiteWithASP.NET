using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private MovieDbContext _dbContext;

        public CustomerController()
        {
            _dbContext = new MovieDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult CustomerForm()
        {
            var membershipType = _dbContext.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MemberShipType = membershipType
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MemberShipType = _dbContext.MemberShipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _dbContext.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.IsSubscribed = customer.IsSubscribed;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            // throw new System.NotImplementedException();
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipType = _dbContext.MemberShipTypes.ToList()
            }
            ;
            return View("CustomerForm", viewModel);
        }
    }
}