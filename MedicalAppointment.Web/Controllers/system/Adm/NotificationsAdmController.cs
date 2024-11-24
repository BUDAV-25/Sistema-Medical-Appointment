using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using MedicalAppointment.Consumption.ModelsMethods.system.Notifications;
using System.Text;
using MedicalAppointment.Consumption.IClientService.system;


namespace MedicalAppointment.Web.Controllers.system.Adm
{
    public class NotificationsAdmController : Controller
    {
        private readonly INotificationsClientService _notificationsClientService;

        public NotificationsAdmController(INotificationsClientService notificationsClientService )
        {
                _notificationsClientService = notificationsClientService;
        }

        public async Task<IActionResult> Index()
        {
            NotificationsGetAllModel notificationsGetAll = await _notificationsClientService.GetNotifications();
            return View( notificationsGetAll.data);
        }

        public async Task<IActionResult> Details(int id)
        {
            NotificationsGetByIdModel notificationsGetById = await _notificationsClientService.GetNotificationsById();
            return View(notificationsGetById.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotificationSaveDto notificationSaveDto)
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

        public async Task<IActionResult> Edit(int id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotificationUpdateDto notificationUpdateDto)
        {
            const string url = "http://localhost:5110/api/Notifications/UpdateNotifications";
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(notificationUpdateDto), Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{url}{notificationUpdateDto.NotificationID}", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<BaseProperties>(await response.Content.ReadAsStringAsync());

                    if (!result.isSuccess)
                    {
                        ViewBag.Message = result.messages;
                        return View(notificationUpdateDto);
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error al actualizar la notificaion.";
                }
            }
            return View(notificationUpdateDto);

        }
    }
}




