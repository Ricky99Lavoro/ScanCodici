using API_Articoli.Functions;
using API_Articoli.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Articoli.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticoliController : ControllerBase
    {
        [HttpGet]
        public List<ItemArt> GetOrdini(int Id_DocTes)
        {
            return Funzioni_Get.GetItems(Id_DocTes, out string error);
        }

        [HttpPut]
        public void PutOrdini(int Qta, int Id_DocTes, string CodArt)
        {
            //Funzioni_Salva.SaveQuantity(Qta, Id_DocTes, CodArt, out string error);
        }
    }
}