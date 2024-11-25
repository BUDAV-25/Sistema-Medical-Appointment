using MedicalAppointment.Application.Dtos.system.Notification;
using Microsoft.AspNetCore.Mvc;
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
            NotificationsGetByIdModel notificationsGetById = await _notificationsClientService.GetNotificationsById(id);
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
            NotificationSaveDto notificationSave = await _notificationsClientService.SaveNotification(notificationSaveDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            NotificationsGetByIdModel notificationsGetById = await _notificationsClientService.GetNotificationsById(id);
            return View(notificationsGetById.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotificationUpdateDto notificationUpdateDto)
        {
            NotificationUpdateDto notificationUpdate = await _notificationsClientService.UpdateNotification(notificationUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}