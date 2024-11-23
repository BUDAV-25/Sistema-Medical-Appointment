using MedicalAppointment.Application.Dtos.users.User;
using MedicalAppointment.Web.Models.Core;
using MedicalAppointment.Web.Models.users.UserTaskModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalAppointment.Web.Controllers.users.Adm
{
    public class UserAdmController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5028/api/";

            UserGetAllModel userGetAllModel = new UserGetAllModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync("User/GetAllUsers");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    userGetAllModel = JsonConvert.DeserializeObject<UserGetAllModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }
            return View(userGetAllModel.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5028/api/";

            UserGetByIdModel userGetByIdModel = new UserGetByIdModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync($"User/GetUserBy{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    userGetByIdModel = JsonConvert.DeserializeObject<UserGetByIdModel>(response);
                }
            }
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
            BaseProperties model = new BaseProperties();
            try
            {
                string url = "http://localhost:5028/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    userSave.CreatedAt = DateTime.Now;
                    var responseTask = await client.PostAsJsonAsync<UserSaveDto>("User/SaveUser", userSave);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<BaseProperties>(response);

                        if (!model.isSuccess)
                        {
                            ViewBag.Message = model.messages;
                            return View();
                        }
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                string url = "http://localhost:5028/api/";

                UserGetByIdModel userGetByIdModel = new UserGetByIdModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var responseTask = await client.GetAsync($"User/GetUserBy{id}");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        userGetByIdModel = JsonConvert.DeserializeObject<UserGetByIdModel>(response);
                    }
                }
                return View(userGetByIdModel.Model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDto userUpdate)
        {
            BaseProperties model = new BaseProperties();
            try
            {
                string url = "http://localhost:5028/api/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    userUpdate.UpdatedAt = DateTime.Now;
                    var responseTask = await client.PutAsJsonAsync<UserUpdateDto>("User/UpdateUser", userUpdate);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<BaseProperties>(response);
                        
                        if (!model.isSuccess)
                        {
                            ViewBag.Message = model.messages;
                            return View();
                        }
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
