using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Consumption.ContractsConsumption.system;
using MedicalAppointment.Consumption.ModelsMethods.system.Roles;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.system.Adm
{
    public class RolesAdmController : Controller
    {
        private readonly IRolesContracts _rolesContracts;
        public RolesAdmController(IRolesContracts rolesContracts)
        {
            _rolesContracts = rolesContracts;
        }
        public async Task<IActionResult> Index()
        {
            RolesGetAllModel rolesGetAll = await _rolesContracts.GetAll();
            return View(rolesGetAll.data);
        }

        public async Task<IActionResult> Details(int id)
        {
            RolesGetByIdModel rolesGetById = await _rolesContracts.GetById(id);
            return View(rolesGetById.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesSaveDto rolesSaveDto)
        {
            RolesSaveDto rolesSave = await _rolesContracts.Save(rolesSaveDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            RolesGetByIdModel rolesGetById = await _rolesContracts.GetById(id);
            return View(rolesGetById.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolesUpdateDto rolesUpdateDto)
        {
            RolesUpdateDto rolesUpdate = await _rolesContracts.Update(rolesUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
