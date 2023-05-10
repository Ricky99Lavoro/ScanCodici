using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Articoli.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentiController : ControllerBase
    {
        [HttpPut("Drop")]
        public void DropTable()
        {
            Functions.Funzioni_Table.DropTableP_Items(out string error);
            //return Ok();
        }
        [HttpPut("Create")]
        public void CreateTable()
        {
            Functions.Funzioni_Table.CreateTableP_Items(out string error);
            //return Ok();
        }
        [HttpPost]
        public void InsertTable(int Id_DocRig, string Codart, string DesDocRig, int Quantitare, int Quantita, int QuantitaPre, string Alias)
        {
            Functions.Funzioni_Table.InsertTableP_Items(Id_DocRig, Codart, DesDocRig, Quantitare, Quantita, QuantitaPre, Alias, out string error);
            //return Ok();
        }


        //[HttpPost]
        //public ActionResult CreaDocumento(int Id_DocRig, string Codart, string DesDocRig, int Quantitare, int Quantita, int QuantitaPre, string Alias)
        //{
        //    Functions.Funzioni_Table.CreateTableP_Items(Id_DocRig, Codart, DesDocRig, Quantitare, Quantita, QuantitaPre, Alias, out string error);
        //    return Ok();
        //}
    }
}
