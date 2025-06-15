using LaraFashionAPI.Data;
using LaraFashionAPI.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaraFashionAPI.Controllers
{
    [Route("/manager")]
    [ApiController]
    public class ManagerControler : ControllerBase
    {
        private readonly GoogleSheetManagement _sheetManagement;

        public ManagerControler(GoogleSheetManagement sheetManagement)
        {
            _sheetManagement = sheetManagement;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _sheetManagement.UpdateSheet("Products!A2", "hi");
            return Ok();
        }
    }
}
