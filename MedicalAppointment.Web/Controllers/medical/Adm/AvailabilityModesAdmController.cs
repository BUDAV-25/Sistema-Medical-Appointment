using MedicalAppointment.Application.Dtos.medical.AvailabilityModes;
using MedicalAppointment.Consumption.ContractsConsumption.medical;
using MedicalAppointment.Consumption.ModelsMethods.medical.AvailabilityModeTaskModel;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.medical.Adm
{
    public class AvailabilityModesAdmController : Controller
    {
        private readonly IAvailabilityModesContract availabilityModes_Contract;
        public AvailabilityModesAdmController(IAvailabilityModesContract availabilityModesContract)
        {
            availabilityModes_Contract = availabilityModesContract;
        }
        public async Task<IActionResult> Index()
        {
            AvailabilityModeGetAllModel model = await availabilityModes_Contract.GetAll();
            return View(model.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            AvailabilityModesGetByIdModel model = await availabilityModes_Contract.GetById(id);
            return View(model.Model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailabilityModesSaveDto availabilitySave)
        {
            AvailabilityModesSaveDto availabilityModesSave = await availabilityModes_Contract.Save(availabilitySave);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            AvailabilityModesGetByIdModel model = await availabilityModes_Contract.GetById(id);
            return View(model.Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AvailabilityModesUpdateDto availabilityUpdate)
        {
            AvailabilityModesUpdateDto availabilityModesUpdate = await availabilityModes_Contract.Update(availabilityUpdate);
            return RedirectToAction(nameof(Index));
        }
    }
}
