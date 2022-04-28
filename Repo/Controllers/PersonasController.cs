using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using Repo.Repositorio.IRepository;

namespace Repo.Controllers
{
    [Route("api/Personas")]
    [ApiController]
    public class PersonasController : Controller
    {
        private readonly IPersonaRepository _perRepo;
        public PersonasController(IPersonaRepository perRepo)
        {
            _perRepo = perRepo;
        }
        [HttpGet]
        public IActionResult GetPersonas() { 
            var listaPersonas = _perRepo.GesPersonas();
            return Ok(listaPersonas);

        }
        public class W
        {
           
            public string? valor { get; set; }
        }


        [HttpGet("get")]
        public IActionResult generarReporte()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage ep = new ExcelPackage();
                ep.Workbook.Worksheets.Add("Hoja de pruebaaa");
                ep.Workbook.Worksheets.Add("Hoja de pruebaaa 2");
                ep.Workbook.Worksheets.Add("Hoja de pruebaaa 3");

                ExcelWorksheet ew1 = ep.Workbook.Worksheets[0];
                ExcelWorksheet ew2 = ep.Workbook.Worksheets[1];
                ExcelWorksheet ew3 = ep.Workbook.Worksheets[2];
                ew1.Cells[1, 1].Value = "Celda 1";
                ew2.Cells[2, 2].Value = "Hola 2";
                ew3.Cells[3, 3].Value = "Vista 3";
                ep.SaveAs(ms);
                byte[] buffer = ms.ToArray();
                Console.WriteLine(Convert.ToBase64String(buffer));
                String json = Convert.ToBase64String(buffer);
                //  JObject json = JObject.Parse(Convert.ToBase64String(buffer));
                // List<String> response = JsonConvert.DeserializeObject<List<String>>(json);
                if (json == null)
                {
                    return NotFound();
                }
                var w = new W
                {
                    valor = json,
                };
             //   string jsonString = JsonSerializer.Serialize(json);

              
                return Ok(w);
            }   
        }
    }
}
