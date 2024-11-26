using MedicalAppointment.Application.Dtos.system.Status;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointment.Consumption.ModelsMethods.system.Status;
using MedicalAppointment.Consumption.ContractsConsumption.system;

namespace MedicalAppointment.Web.Controllers.system.Adm
{
    public class StatusAdmController : Controller
    {
        private readonly IStatusContracts _statusContracts;
        public StatusAdmController(IStatusContracts statusContracts)
        {
            _statusContracts = statusContracts;
        }

        public async Task<IActionResult> Index()
        {
            StatusGetAllModel statusGetAll = await _statusContracts.GetAll();
            return View(statusGetAll.data);
        }

        public async Task<IActionResult> Details(int id)
        {
            StatusGetByIdModel statusGetById = await _statusContracts.GetById(id);
            return View(statusGetById.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusSaveDto statusSaveDto)
        {
            StatusSaveDto statusSave = await _statusContracts.Save(statusSaveDto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            StatusGetByIdModel statusGetById = await _statusContracts.GetById(id);
            return View(statusGetById.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusUpdateDto statusUpdateDto)
        {
            StatusUpdateDto statusUpdate = await _statusContracts.Update(statusUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
