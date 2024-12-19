using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class VendorController : ControllerBase {

    private readonly DbManager _dbManager;
    Response response = new Response();

    public VendorController(IConfiguration configuration){
        _dbManager = new DbManager(configuration);
    }

    //GET_All
    [HttpGet]
    public IActionResult GetAllVendor(){
        try{
            response.status = 200;
            response.message = "Data vendor berhasil ditampilkan!!!";
            response.data = _dbManager.GetAllVendor();
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //POST
    [HttpPost]
    public IActionResult CreateVendor([FromBody] Vendor vendors)
    {
        try {
            _dbManager.CreateVendor(vendors);
            response.status = 200;
            response.message = "Data vendor berhasil ditambahkan!!!";
            response.data = null;
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //UPDATE by Id -Put
    [HttpPut()]
    public IActionResult UpdateVendor(int id_vendor, [FromBody] Vendor vendors){
        try{
            response.status = 200;
            response.message = "Data vendor berhasil di update!!!";
            _dbManager.UpdateVendor(id_vendor, vendors);
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }



    //DELETE 
    [HttpDelete()]
    public IActionResult DeleteVendor(string nama_vendor){
        try{
            response.status = 200;
            response.message = "Data vendor berhasil di hapus!!!";
            _dbManager.DeleteVendor(nama_vendor);
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
}