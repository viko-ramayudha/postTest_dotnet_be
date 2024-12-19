using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("api/[controller]")]
[ApiController]

public class JadwalPerawatanController : ControllerBase {

    private readonly DbManager _dbManager;
    Response response = new Response();

    public JadwalPerawatanController(IConfiguration configuration){
        _dbManager = new DbManager(configuration);
    }


    //GetAllJadwal
    [HttpGet("MemunculkanData")]

    public IActionResult GetJadwal()
    {
        try
        {
            response.status = 200;
            response.message = "Jadwal alat yang sedang dilakukan perawatan!!!";
            response.data = _dbManager.GetDataJadwal();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //TambahJadwal
    [HttpPost("TambahDataJadwal")]

    public IActionResult CreateJadwal([FromBody] JadwalPerawatan jadwal)
    {
        try
        {
            string result = _dbManager.CreateDataJadwal(jadwal);
            if (result == "Alat masih berfungsi dengan baik")
            {
                response.status = 400;
                response.message = result;
            }
            else if (result == "Alat tidak ada" || result == "Vendor tidak ada")
            {
                response.status = 404;
                response.message = result;
            }
            else
            {
                response.status = 200;
                response.message = "Berhasil";
                _dbManager.CreateDataJadwal(jadwal);
            }
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    //Laporan
    [HttpGet("Laporan")]

    public IActionResult GetLaporan()
    {
        try
        {
            response.status = 200;
            response.message = "Succes";
            response.data = _dbManager.GetDataLaporan();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }
}