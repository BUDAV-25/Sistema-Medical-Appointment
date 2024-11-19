using MedicalAppointment.Application.Contracts.users;
using MedicalAppointment.Application.Dtos.users.User;
using MedicalAppointment.Persistance.Models.users;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.users
{
    public class UserController : Controller
    {
        private readonly IUserService user_Service;
        public UserController(IUserService userService)
        {
            user_Service = userService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await user_Service.GetAll();
            if (result.IsSuccess)
            {
                List<UsersModel> usersModel = (List<UsersModel>)result.Model;
                return View(usersModel);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await user_Service.GetById(id);
            if (result.IsSuccess)
            {
                UsersModel userModel = (UsersModel)result.Model;
                return View(userModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserSaveDto userSave)
        {
            try
            {
                userSave.CreatedAt = DateTime.Now;
                var result = await user_Service.SaveAsync(userSave);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Messages;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await user_Service.GetById(id);
            if (result.IsSuccess)
            {
                UsersModel userModel = (UsersModel)result.Model;
                return View(userModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdate)
        {
            try
            {
                userUpdate.UpdatedAt = DateTime.Now;
                var result = await user_Service.UpdateAsync(userUpdate);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Messages;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
