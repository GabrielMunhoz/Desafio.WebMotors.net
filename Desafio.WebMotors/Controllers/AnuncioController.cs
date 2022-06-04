using Microsoft.AspNetCore.Mvc;
using Desafio.WebMotors.Data;
using Desafio.WebMotors.Models;
using Desafio.WebMotors.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Desafio.WebMotors.Controllers
{
    public class AnuncioController : Controller
    {
        ITbAnuncioWebmotor _tbAnuncioWebmotor;
        public AnuncioController(ITbAnuncioWebmotor tbAnuncioWebmotor)
        {
            _tbAnuncioWebmotor = tbAnuncioWebmotor;
        }
        public async Task<IActionResult> Index()
        {
            List<TbAnuncioWebmotor> listAnuncios = _tbAnuncioWebmotor.GetAll();

            return View(listAnuncios);
        }
        public IActionResult Preview(int id)
        {
            TbAnuncioWebmotor anuncio = _tbAnuncioWebmotor.GetTbAnuncioWebmotor(id);

            int marca = Convert.ToInt32(anuncio.Marca);
            int model = Convert.ToInt32(anuncio.Modelo);
            int version = Convert.ToInt32(anuncio.Versao);
            string marcaNome = Services.Services.getMakes().Result.Find(m => m.ID == marca).Name;
            string modeloNome = Services.Services.getModels(marca).Result.Find(m => m.ID == model).Name;
            string versionNome = Services.Services.getVersion(model).Result.Find(m => m.ID == version).Name;

            TbAnuncioWebmotor anuncioFormatado = new TbAnuncioWebmotor
            {
                Ano = anuncio.Ano,
                Id = anuncio.Id,
                Marca = marcaNome,
                Modelo = modeloNome,
                Versao = versionNome,
                Observacao = anuncio.Observacao,
                Quilometragem = anuncio.Quilometragem

            };

            return View(anuncioFormatado);
        }
        public async Task<IActionResult> Add(TbAnuncioWebmotor AnuncioWebmotor)
        {
            try
            {
                if (AnuncioWebmotor.Id > 0 )
                {
                    int result = _tbAnuncioWebmotor.Edit(AnuncioWebmotor);
                }
                else
                {

                    int result = _tbAnuncioWebmotor.Add(AnuncioWebmotor);
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddView()
        {
            List<SelectListItem> marcas = Services.Services.getMakes().Result.Select(n =>
                      new SelectListItem
                      {
                          Value = n.ID.ToString(),
                          Text = n.Name
                      }).ToList();

            var marca = new SelectListItem()
            {
                Value = null,
                Text = "--- Selecione a marca ---"
            };
            marcas.Insert(0, marca);
            ViewBag.Marcas = marcas;

            return View("add");
        }
        public IActionResult Edit(int id)
        {
            TbAnuncioWebmotor anuncio = _tbAnuncioWebmotor.GetTbAnuncioWebmotor(id);

            List<SelectListItem> marcas = Services.Services.getMakes().Result.Select(n =>
                      new SelectListItem
                      {
                          Value = n.ID.ToString(),
                          Text = n.Name
                      }).ToList();

            
            
            ViewBag.Marcas = marcas;


            int marca = Convert.ToInt32(anuncio.Marca);

            List<SelectListItem> modelos = Services.Services.getModels(marca).Result.Select(n =>
                      new SelectListItem
                      {
                          Value = n.ID.ToString(),
                          Text = n.Name
                      }).ToList();

           
            ViewBag.Modelos = modelos;


            int modelo = Convert.ToInt32(anuncio.Modelo);

            List<SelectListItem> versoes = Services.Services.getVersion(modelo).Result.Select(n =>
                      new SelectListItem
                      {
                          Value = n.ID.ToString(),
                          Text = n.Name
                      }).ToList();

           
            ViewBag.Versoes = versoes;

            return View("add", anuncio);
        }
        public IActionResult Edited(TbAnuncioWebmotor anuncioWebmotor)
        {
            _tbAnuncioWebmotor.Edit(anuncioWebmotor);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            int count = _tbAnuncioWebmotor.Delete(id);

            return RedirectToAction("Index");
        }

        //Metodos utilizados no front
        [HttpGet]
        public JsonResult getModels(int idMake = 1)
        {
            List<SelectListItem> models = Services.Services.getModels(idMake).Result.Select(n =>
                       new SelectListItem
                       {
                           Value = n.ID.ToString(),
                           Text = n.Name
                       }).ToList();
            SelectList selectList = new SelectList(models, "Value", "Text");
            return Json(JsonConvert.SerializeObject(selectList));
        }
        [HttpGet]
        public JsonResult getVersions(int idModel = 1)
        {
            List<SelectListItem> versions = Services.Services.getVersion(idModel).Result.Select(n =>
                       new SelectListItem
                       {
                           Value = n.ID.ToString(),
                           Text = n.Name
                       }).ToList();
            SelectList selectList = new SelectList(versions, "Value", "Text");

            return Json(JsonConvert.SerializeObject(selectList));
        }

    }
}
