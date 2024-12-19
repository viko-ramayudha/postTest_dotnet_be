using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class AlatController : ControllerBase {

    private readonly DbManager _dbManager;
    Response response = new Response();

    public AlatController(IConfiguration configuration){
        _dbManager = new DbManager(configuration);
    }

    //GET_All
    [HttpGet]
    public IActionResult GetAllAlat(){
        try{
            response.status = 200;
            response.message = "Data alat berhasil ditampilkan!!!";
            response.data = _dbManager.GetAllAlat();
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //GET_By_TipeAlat
    [HttpGet("{tipe_alat}")]
    public IActionResult GetByTipeAlat(string tipe_alat)
    {
        try {
            var getbytipealatList = _dbManager.GetByTipeAlat(tipe_alat);
            response.status = 200;
            response.message = "Success";
            response.data = getbytipealatList;
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //POST
    [HttpPost]
    public IActionResult CreateAlat([FromBody] Alat alats)
    {
        try {
            _dbManager.CreateAlat(alats);
            response.status = 200;
            response.message = "Data alat berhasil ditambahkan!!!";
            response.data = null;
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //UPDATE by Id -Put
    [HttpPut()]
    public IActionResult UpdtAlat(int id_alat, [FromBody] UpdtAlat alats){
        try{
            response.status = 200;
            response.message = "Nama alat berhasil di update!!!";
            _dbManager.UpdtAlat(id_alat, alats);
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }



    //DELETE 
    [HttpDelete()]
    public IActionResult DeleteAlat(int id_alat){
        try{
            response.status = 200;
            response.message = "Status kondisi data alat berhasil di ubah!!!";
            _dbManager.DeleteAlat(id_alat);
        }catch(Exception ex) {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
}