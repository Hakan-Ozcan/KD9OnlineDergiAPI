using KD9OnlineDergiAPI.Database;
using KD9OnlineDergiAPI.Entities;
using KD9OnlineDergiAPI.Model;
using KD9OnlineDergiAPI.Model.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KD9OnlineDergiAPI.Controllers
{
    [Route("yayin-evleri/[controller]")]
    [ApiController]
    public class DergiController : ControllerBase
    {
        private readonly DergiDbContext _context;

        public DergiController(DergiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Dergi> Ekle(baseDergi yeniBilgi)
        {  
            try
            {
                Dergi yeni = new Dergi(yeniBilgi);

                //yeniBilgi = yeni;

                //yeni.dergiAdı = yeniBilgi.dergiAdı;
                //yeni.dergiTürleri = yeniBilgi.dergiTürleri;
                //yeni.yayınAralığı = yeniBilgi.yayınAralığı;
                //yeni.yayınEviId = yeniBilgi.yayınEviId; 

                //yeni.basedenBilgiOku(yeniBilgi); // constructer sayesinde boşa çıktı

                _context.Dergiler.Add(yeni);
                _context.SaveChanges();
                return GetByIdDergi(yeni.ID);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dergi>> Dergiler()
        {
            return _context.Dergiler.Include(d=>d.yayınEvi).ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Dergi> GetByIdDergi(Guid Id)
        {
            return _context.Dergiler.Include(d => d.yayınEvi).Where(d => d.ID == Id).SingleOrDefault();
        }
 
    }
}
