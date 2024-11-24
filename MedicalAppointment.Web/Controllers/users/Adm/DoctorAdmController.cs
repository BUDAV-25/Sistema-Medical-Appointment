using MedicalAppointment.Application.Dtos.users.Doctor;
using MedicalAppointment.Web.Models.Core;
using MedicalAppointment.Web.Models.users.DoctorTaskModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalAppointment.Web.Controllers.users.Adm
{
    public class DoctorAdmController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5028/api/";

            DoctorGetAllModel doctorGetAllModel = new DoctorGetAllModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync("Doctor/GetAllDoctors");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    doctorGetAllModel = JsonConvert.DeserializeObject<DoctorGetAllModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }
            return View(doctorGetAllModel.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5028/api/";
            DoctorGetByIdModel doctorGetById = new DoctorGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync($"Doctor/GetDoctorby{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    doctorGetById = JsonConvert.DeserializeObject<DoctorGetByIdModel>(response);
                }
            }
            return View(doctorGetById.Model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorSaveDto doctorSave)
        {
            BaseProperties model = new BaseProperties();
            try
            {
                string url = "http://localhost:5028/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    doctorSave.CreatedAt = DateTime.Now;
                    var responseTask = await client.PostAsJsonAsync<DoctorSaveDto>("Doctor/SaveDoctor", doctorSave);

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
                DoctorGetByIdModel doctorGetById = new DoctorGetByIdModel();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var responseTask = await client.GetAsync($"Doctor/GetDoctorby{id}");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        doctorGetById = JsonConvert.DeserializeObject<DoctorGetByIdModel>(response);
                    }
                }
                return View(doctorGetById.Model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorUpdateDto doctorUpdate)
        {
            BaseProperties model = new BaseProperties();
            try
            {
                string url = "http://localhost:5028/api/";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    doctorUpdate.UpdatedAt = DateTime.Now;
                    var responseTask = await client.PutAsJsonAsync<DoctorUpdateDto>("Doctor/UpdateDoctorby", doctorUpdate);

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
