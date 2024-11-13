using MedicalAppointment.Application.Contracts.system;
using MedicalAppointment.Application.Dtos.appointments.Appointments;
using MedicalAppointment.Application.Dtos.system.Notification;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Application.Services.System;
using MedicalAppointment.Persistance.Models.system;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.system
{
    public class NotificationsController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task <IActionResult> Index()
        {
            var result = await _notificationService.GetAll();

            if (result.IsSuccess)
            {
                List<NotificationsModel> notificationService = (List<NotificationsModel>)result.Data;

                return View(notificationService);
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _notificationService.GetById(id);

            if (result.IsSuccess)
            {
                NotificationsModel notificationsModel = (NotificationsModel)result.Data;

                return View(notificationsModel);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(NotificationSaveDto notificationSave)
        {
            try
            {
                var result = await _notificationService.SaveAsync(notificationSave);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Messages;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _notificationService.GetById(id);

            if (result.IsSuccess)
            {
                NotificationsModel notificationsModel = (NotificationsModel)result.Data;

                return View(notificationsModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(NotificationUpdateDto notificationUpdate)
        {
            try
            {
                var result = await _notificationService.UpdateAsync(notificationUpdate);

                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    ViewBag.Message = result.Messages;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

    }
}
