using System.Linq;
using System.Net;
using System.Web.Mvc;
using CRMAplication.Interfaces;
using CRMAplication.Models;

namespace CRMAplication.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarLogin _carLogin;
        private readonly IEmailService _emailService;

        public CarsController(ICarRepository carRepository, ICarLogin carLogin, IEmailService emailService)
        {
            _carRepository = carRepository;
            _carLogin = carLogin;
            _emailService = emailService;
        }
        // GET: Cars
        public ActionResult Index()
        {
            if (_carLogin.IsUserAuthorized())
            {
                return View("Index", _carRepository.GetWhere(x => x.Id > 0));
            }

            return View("~/Views/Cars/IndexUnAuthorized.cshtml", _carRepository.GetWhere(x => x.Id > 0).Where(x => x.Activity));
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {

                _carRepository.Create(car);
                var message = _emailService.CreateMailMessage(car);
                _emailService.SendEmail(message);

                return RedirectToAction("Index");
            }
            return View(car);
        }
        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.Update(car);

                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = _carRepository.GetWhere(x => x.Id == id).FirstOrDefault();

            _carRepository.Delete(car);
            return RedirectToAction("Index");
        }
    }
}
