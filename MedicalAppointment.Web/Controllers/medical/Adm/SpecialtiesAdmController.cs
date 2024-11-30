using MedicalAppointment.Application.Dtos.medical.Specialties;
using MedicalAppointment.Consumption.ContractsConsumption.medical;
using MedicalAppointment.Consumption.ModelsMethods.medical.SpecialtiesTaskModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.medical.Adm
{
    public class SpecialtiesAdmController : Controller
    {
        private readonly ISpecialtiesContract specialties_Contract;
        public SpecialtiesAdmController(ISpecialtiesContract specialtiesContract)
        {
            specialties_Contract = specialtiesContract;
        }
        public async Task<IActionResult> Index()
        {
            SpecialtiesGetAllModel model = await specialties_Contract.GetAll();
            return View(model.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            SpecialtiesGetByIdModel model = await specialties_Contract.GetById(id);
            return View(model.Model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialtiesSaveDto specialtiesSave)
        {
            SpecialtiesSaveDto specialtiesSaveDto = await specialties_Contract.Save(specialtiesSave);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            SpecialtiesGetByIdModel model = await specialties_Contract.GetById(id);
            return View(model.Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialtiesUpdateDto specialtiesUpdate)
        {
            SpecialtiesUpdateDto specialtiesUpdateDto = await specialties_Contract.Update(specialtiesUpdate);
            return RedirectToAction(nameof(Index));
        }
    }
}
