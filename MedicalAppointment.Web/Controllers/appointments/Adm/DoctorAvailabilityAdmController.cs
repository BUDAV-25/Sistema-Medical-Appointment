using MedicalAppointment.Web.Models.appointments.DoctorAvailabilityTaskModel;
using MedicalAppointment.Web.Models.system.StatusTaskModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalAppointment.Web.Controllers.appointments.Adm
{
    public class DoctorAvailabilityAdmController : Controller
    {
        // GET: DoctorAvailabilityAdmController
        public async Task <IActionResult >Index()
        {
            const string url = "http://localhost:5110/api/DoctorAvailability/GetAllDoctorAvailabity";
            DoctorAvailabilityGetAllModel doctorAvailabilityGetAll = new DoctorAvailabilityGetAllModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        doctorAvailabilityGetAll = JsonConvert.DeserializeObject<DoctorAvailabilityGetAllModel>(responseContent);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener las disponibilidades.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View(doctorAvailabilityGetAll.data);
        }

        // GET: DoctorAvailabilityAdmController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            const string url = "http://localhost:5110/api/DoctorAvailability/GetEntityBy";
            DoctorAvailabilityGetByModel doctorAvailabilityGetBy= new DoctorAvailabilityGetByModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{url}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        doctorAvailabilityGetBy = JsonConvert.DeserializeObject<DoctorAvailabilityGetByModel>(responseContent);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los detalles del status.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }
            return View(doctorAvailabilityGetBy.data);
        }

        // POST: DoctorAvailabilityAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorAvailabilityAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorAvailabilityAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorAvailabilityAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorAvailabilityAdmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
