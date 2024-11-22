using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Web.Models.appointments.AppointmentsTaskModel;
using MedicalAppointment.Web.Models.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;

namespace MedicalAppointment.Web.Controllers.appointments.Adm
{
    public class AppointmentsAdmController : Controller
    {
        // GET: AppointmentsAdmController
        public async Task<IActionResult> Index()
        {
            const string url = "http://localhost:5120/api/Appointments/GetAllAppointments";
            AppointmentsGetAllModel appointmentsGetAll = new AppointmentsGetAllModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        appointmentsGetAll = JsonConvert.DeserializeObject<AppointmentsGetAllModel>(responseContent);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los appointments.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View(appointmentsGetAll.data);
        }

        // GET: AppointmentsAdmController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            const string url = "http://localhost:5120/api/Appointments/GetEntityByAppointments";
            AppointmentsGetByIdModel appointmentsGetById = new AppointmentsGetByIdModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{url}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        appointmentsGetById = JsonConvert.DeserializeObject<AppointmentsGetByIdModel>(responseContent);
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
            return View(appointmentsGetById.data);
        }

        // GET: AppointmentsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentsAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentsSaveDto appointmentsSaveDto)
        {
            const string url = "http://localhost:5120/api/Appointments/SaveAppointments";
            BaseProperties baseProperties = new BaseProperties();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseTask = await client.PostAsJsonAsync(url, appointmentsSaveDto);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        baseProperties = JsonConvert.DeserializeObject<BaseProperties>(response);

                        if (!baseProperties.isSuccess)
                        {
                            ViewBag.Message = baseProperties.messages;
                            return View();
                        }
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        ViewBag.Message = baseProperties.messages;
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

        // GET: AppointmentsAdmController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            const string url = "http://localhost:5120/api/Appointments/GetEntityByAppointments";
            AppointmentsGetByIdModel appointmentsGetById = new AppointmentsGetByIdModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{url}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        appointmentsGetById = JsonConvert.DeserializeObject<AppointmentsGetByIdModel>(responseContent);
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
            return View(appointmentsGetById.data);
        }

        // POST: AppointmentsAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentsUpdateDto appointmentsUpdateDto)
        {
            BaseProperties baseProperties = new BaseProperties();

            try
            {
                const string url = "http://localhost:5120/api/Appointments/UpdateAppointments";
                using (var client = new HttpClient())
                {
                    appointmentsUpdateDto.UpdateAt = DateTime.Now;
                    var responseTask = await client.PutAsJsonAsync<AppointmentsUpdateDto>(url, appointmentsUpdateDto);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        baseProperties = JsonConvert.DeserializeObject<BaseProperties>(response);

                        if (!baseProperties.isSuccess)
                        {
                            ViewBag.Message = baseProperties.messages;
                            return View();
                        }
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        ViewBag.Message = baseProperties.messages;
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
