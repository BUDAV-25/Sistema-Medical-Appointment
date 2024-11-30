using MedicalAppointment.Application.Dtos.users.User;
using MedicalAppointment.Consumption.ContractsConsumption.users;
using MedicalAppointment.Web.ModelsMethods.users.UserTaskModel;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.users.Adm
{
    public class UserAdmController : Controller
    {
        private readonly IUserContract user_Contract;
        public UserAdmController(IUserContract userContract)
        {
            user_Contract = userContract;
        }
        public async Task<IActionResult> Index()
        {
            UserGetAllModel userGetAllModel = await user_Contract.GetAll();
            return View(userGetAllModel.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            UserGetByIdModel userGetByIdModel = await user_Contract.GetById(id);
            return View(userGetByIdModel.Model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserSaveDto userSave)
        {
            UserSaveDto userSaveDto = await user_Contract.Save(userSave);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            UserGetByIdModel userGetByIdModel = await user_Contract.GetById(id);
            return View(userGetByIdModel.Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdate)
        {
            UserUpdateDto userUpdateDto = await user_Contract.Update(userUpdate);
            return RedirectToAction(nameof(Index));
        }
    }
}
