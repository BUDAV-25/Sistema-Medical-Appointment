using MedicalAppointment.Application.Dtos.system.Status;
using MedicalAppointment.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MedicalAppointment.Web.Models.system.StatusTaskModel;
using Azure;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http.Json;

namespace MedicalAppointment.Web.Controllers.system.Adm
{
    public class StatusAdmController : Controller
    {
        // GET: StatusAdmController
        public async Task<IActionResult> Index()
        {
            const string url = "http://localhost:5110/api/Status/GetAllStatus";
            StatusGetAllModel statusGetAllModel = new StatusGetAllModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        statusGetAllModel = JsonConvert.DeserializeObject<StatusGetAllModel>(responseContent);
                    }
                    else
                    {
                        ViewBag.Message = "Error al obtener los status.";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }

            return View(statusGetAllModel.data);
        }


        // GET: StatusAdmController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            const string url = "http://localhost:5110/api/Status/GetStatusBy";
            StatusGetByIdModel statusGetByIdModel = new StatusGetByIdModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{url}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        statusGetByIdModel = JsonConvert.DeserializeObject<StatusGetByIdModel>(responseContent);
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
            return View(statusGetByIdModel.data);
        }

        // GET: StatusAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusSaveDto statusSaveDto)
        {
            const string url = "http://localhost:5110/api/Status/SaveStatus";
            BaseProperties model = new BaseProperties();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseTask = await client.PostAsJsonAsync(url, statusSaveDto);

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


        // GET: StatusAdmController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            const string url = "http://localhost:5110/api/Status/GetStatusBy";
            StatusGetByIdModel statusGetById = new StatusGetByIdModel();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{url}{id}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    statusGetById = JsonConvert.DeserializeObject<StatusGetByIdModel>(responseContent);
                }
                else
                {
                    ViewBag.Message = "Error al obtener el status para edición.";
                }
            }

            return View(statusGetById.data);
        }

        // NO FUNCIONA

        // POST: StatusAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusUpdateDto statusUpdateDto)
        {
            const string url = "http://localhost:5110/api/Status/UpdateStatus";

            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(statusUpdateDto), Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<BaseProperties>(await response.Content.ReadAsStringAsync());

                    if (!result.isSuccess)
                    {
                        ViewBag.Message = result.messages;
                        return View(statusUpdateDto);
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Error al actualizar el status.";
                }
            }
            return View(statusUpdateDto);
        }

    }

}