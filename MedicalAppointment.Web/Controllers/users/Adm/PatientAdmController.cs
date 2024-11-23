using MedicalAppointment.Application.Dtos.users.Patient;
using MedicalAppointment.Web.Models.Core;
using MedicalAppointment.Web.Models.users.PatientTaskModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MedicalAppointment.Web.Controllers.users.Adm
{
    public class PatientAdmController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5028/api/";

            PatientGetAllModel patientGetAllModel = new PatientGetAllModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync("Patient/GetAllPatients");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    patientGetAllModel = JsonConvert.DeserializeObject<PatientGetAllModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }
            return View(patientGetAllModel.Model);
        }

        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5028/api/";
            PatientGetByIdModel patientGetByIdModel = new PatientGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync($"Patient/GetPatientby{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    patientGetByIdModel = JsonConvert.DeserializeObject<PatientGetByIdModel>(response);
                }
            }
            return View(patientGetByIdModel.Model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientSaveDto patientSave)
        {
            BaseProperties model = new BaseProperties();
            try
            {
                string url = "http://localhost:5028/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    patientSave.CreatedAt = DateTime.Now;
                    var responseTask = await client.PostAsJsonAsync<PatientSaveDto>("Patient/SavePatient", patientSave);

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
            string url = "http://localhost:5028/api/";
            PatientGetByIdModel patientGetByIdModel = new PatientGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync($"Patient/GetPatientby{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    patientGetByIdModel = JsonConvert.DeserializeObject<PatientGetByIdModel>(response);
                }
            }
            return View(patientGetByIdModel.Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientUpdateDto patientUpdate)
        {
            BaseProperties model = new BaseProperties();
            try
            {
                string url = "http://localhost:5028/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    patientUpdate.UpdatedAt = DateTime.Now;
                    var responseTask = await client.PutAsJsonAsync<PatientUpdateDto>("Patient/UpdatePatient", patientUpdate);

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
    }
}
