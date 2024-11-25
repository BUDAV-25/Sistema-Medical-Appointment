using MedicalAppointment.Application.Dtos.system.Roles;
using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Consumption.IClientService.system;
using MedicalAppointment.Consumption.ModelsMethods.system.Roles;
using MedicalAppointment.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace MedicalAppointment.Web.Controllers.system.Adm
{
    public class RolesAdmController : Controller
    {
        private readonly IRolesClientService _rolesClientService;
        public RolesAdmController(IRolesClientService rolesClientService)
        {
                _rolesClientService = rolesClientService;
        }
        public async Task<IActionResult> Index()
        {
            RolesGetAllModel rolesGetAll = await _rolesClientService.GetRoles();
            return View(rolesGetAll.data);
        }

        public async Task<IActionResult> Details(int id)
        {
            RolesGetByIdModel rolesGetById = await _rolesClientService.GetRolesById();
            return View(rolesGetById.data);
        }

        // GET: RolesAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesSaveDto rolesSaveDto)
        {
            rolesSaveDto.CreatedAt = DateTime.Now;
            const string url = "http://localhost:5110/api/Roles/SaveRoles";
            BaseProperties model = new BaseProperties();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseTask = await client.PostAsJsonAsync(url, rolesSaveDto);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        var response = await responseTask.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<BaseProperties>(response);

                        if (!model.isSuccess)
                        {
                            ViewBag.Message = model.messages;
                            return View();
                        }

                        return RedirectToAction(nameof(Index));
                    }

                    ViewBag.Message = "Error al guardar el rol.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View();
        }



        // GET: RolesAdmController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            const string url = "http://localhost:5110/api/Roles/GetRolesBy";
            RolesGetByIdModel statusGetById = new RolesGetByIdModel();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{url}{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    statusGetById = JsonConvert.DeserializeObject<RolesGetByIdModel>(responseContent);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el status para edición.";
                }
            }

            return View(statusGetById.data);
        }

        // NO FUNCIONA

        // POST: RolesAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolesUpdateDto rolesUpdateDto)
        {
            const string url = "http://localhost:5110/api/Roles/UpdateRoles";
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(rolesUpdateDto), Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"{url}{rolesUpdateDto.RoleID}", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<BaseProperties>(await response.Content.ReadAsStringAsync());

                    if (!result.isSuccess)
                    {
                        ViewBag.Message = result.messages;
                        return View(rolesUpdateDto);
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error al actualizar el status.";
                }
            }
            return View(rolesUpdateDto);

        }
    }
}
