using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Web.Models.Core;
using MedicalAppointment.Web.Models.system.NotificationsTaskModel;
using MedicalAppointment.Web.Models.system.StatusTaskModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;

namespace MedicalAppointment.Web.Controllers.system.Adm
{
    public class NotificationsAdmController : Controller
    {
        // GET: NotificationsAdmController
        public async Task <IActionResult> Index()
        {
            const string url = "http://localhost:5110/api/Notifications/GetAllNotifications";
            NotificationsGetAllModel notificationsGetAllModel = new NotificationsGetAllModel();

            try
            {
                using (var client = new HttpClient()) 
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        notificationsGetAllModel = JsonConvert.DeserializeObject<NotificationsGetAllModel>(responseContent);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener las notificaciones.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }
            return View(notificationsGetAllModel.data);
        }

        // GET: NotificationsAdmController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            const string url = "http://localhost:5110/api/Notifications/GetNotificationsBy";
            NotificationsGetByIdModel notificationsGetById = new NotificationsGetByIdModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{url}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        notificationsGetById = JsonConvert.DeserializeObject<NotificationsGetByIdModel>(responseContent);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los detalles de la notificacion.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }
            return View(notificationsGetById.data);
        }

        // GET: NotificationsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificationsAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(NotificationSaveDto notificationSaveDto)
        {
            const string url = "http://localhost:5110/api/Notifications/SaveNotifications";
            BaseProperties model = new BaseProperties();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseTask = await client.PostAsJsonAsync(url, notificationSaveDto);

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
                        ViewBag.Message = "Error al crear el status.";
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

        // GET: NotificationsAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotificationsAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, IFormCollection collection)
        {
            const string url = "http://localhost:5110/api/Notifications/GetNotificationsBy";
            NotificationsGetByIdModel notificationsGetById = new NotificationsGetByIdModel();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{url}{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    notificationsGetById = JsonConvert.DeserializeObject<NotificationsGetByIdModel>(responseContent);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el status para edición.";
                }
            }

            return View(notificationsGetById.data);
        }

        // GET: NotificationsAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotificationsAdmController/Delete/5
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
