using MedicalAppointment.Application.Dtos.system.Notification;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointment.Consumption.ModelsMethods.system.Notifications;
using MedicalAppointment.Consumption.ContractsConsumption.system;


namespace MedicalAppointment.Web.Controllers.system.Adm
{
    public class NotificationsAdmController : Controller
    {
        private readonly INotificationsContracts _notificationsContracts;
        public NotificationsAdmController(INotificationsContracts notificationsContracts )
        {
            _notificationsContracts = notificationsContracts;
        }

        public async Task<IActionResult> Index()
        {
            NotificationsGetAllModel notificationsGetAll = await _notificationsContracts.GetAll();
            return View( notificationsGetAll.data);
        }

        public async Task<IActionResult> Details(int id)
        {
            NotificationsGetByIdModel notificationsGetById = await _notificationsContracts.GetById(id);
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
            NotificationSaveDto notificationSave = await _notificationsContracts.Save(notificationSaveDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            NotificationsGetByIdModel notificationsGetById = await _notificationsContracts.GetById(id);
            return View(notificationsGetById.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotificationUpdateDto notificationUpdateDto)
        {
            NotificationUpdateDto notificationUpdate = await _notificationsContracts.Update(notificationUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}