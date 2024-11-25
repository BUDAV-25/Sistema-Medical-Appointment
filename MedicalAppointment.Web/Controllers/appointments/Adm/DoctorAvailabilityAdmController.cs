using MedicalAppointment.Application.Dtos.appointments.DoctorAvailability;
using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Domain.Entities.appointments;
using MedicalAppointment.Web.Models.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
/*
namespace MedicalAppointment.Web.Controllers.appointments.Adm
{
    public class DoctorAvailabilityAdmController : Controller
    {
        // GET: DoctorAvailabilityAdmController
        public async Task<IActionResult> Index()
        {
            const string url = "http://localhost:5120/api/DoctorAvailability/GetAllDoctorAvailabity";
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
        public async Task<IActionResult> Details(int id)
        {
            const string url = "http://localhost:5120/api/DoctorAvailability/GetEntityBy";
            DoctorAvailabilityGetByIdModel doctorAvailabilityGetBy = new DoctorAvailabilityGetByIdModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{url}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        doctorAvailabilityGetBy = JsonConvert.DeserializeObject<DoctorAvailabilityGetByIdModel>(responseContent);
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


        // GET: DoctorAvailabilityAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorAvailabilityAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailabilitySaveDto)
        {
            const string url = "http://localhost:5120/api/DoctorAvailability/SaveDoctorAvailability";
            BaseProperties model = new BaseProperties();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseTask = await client.PostAsJsonAsync(url, doctorAvailabilitySaveDto);

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
                    else
                    {
                        ViewBag.Message = model.messages;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error en la solicitud: " + ex.Message;
            }
            return View();
        }

        // GET: DoctorAvailabilityAdmController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            const string url = "http://localhost:5120/api/DoctorAvailability/GetEntityBy";
            DoctorAvailabilityGetByIdModel doctorAvailabilityGetBy = new DoctorAvailabilityGetByIdModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{url}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        doctorAvailabilityGetBy = JsonConvert.DeserializeObject<DoctorAvailabilityGetByIdModel>(responseContent);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los detalles de la disponibilidad del doctor.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }
            return View(doctorAvailabilityGetBy.data);
        }

        // POST: DoctorAvailabilityAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(DoctorAvailabilityUpdateDto doctorAvailabilityUpdateDto)
        {
            const string url = "http://localhost:5120/api/DoctorAvailability/UpdateDoctorAvailability";
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(doctorAvailabilityUpdateDto), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{url}?{doctorAvailabilityUpdateDto.AvailabilityID}", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<BaseProperties>(await response.Content.ReadAsStringAsync());

                    if (!result.isSuccess)
                    {
                        ViewBag.Message = result.messages;
                        return View(doctorAvailabilityUpdateDto);
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error al actualizar el doctoravailability.";
                }
            }
            return View(doctorAvailabilityUpdateDto);

        }
    }
}
*/