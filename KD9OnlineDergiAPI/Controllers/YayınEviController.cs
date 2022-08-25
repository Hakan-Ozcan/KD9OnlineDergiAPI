using KD9OnlineDergiAPI.Database;
using KD9OnlineDergiAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KD9OnlineDergiAPI.Controllers
{
    [Route("admin/Evler")]
    [ApiController]
    public class YayınEviController : ControllerBase
    {
        private readonly DergiDbContext _context;

        public YayınEviController(DergiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        //api/evler
        public YayınEvi Yeni(YayınEvi yayınEvi)
        {
            _context.YayınEvleri.Add(yayınEvi);
            _context.SaveChanges();
            return yayınEvi;
        }

        //api/evler/{yayın evi adı}
        [HttpPost("{name}")]
        public YayınEvi Yeni(string name)
        {
            YayınEvi yayınEvi = new YayınEvi { Name = name };
            _context.YayınEvleri.Add(yayınEvi);
            _context.SaveChanges();
            return yayınEvi;
        }

        [HttpGet]
        public ActionResult<IEnumerable<YayınEvi>> yayınEviListesi()
        {
            if (_context.YayınEvleri.Count() == 0)
                return NotFound();
            return _context.YayınEvleri.Include(x=>x.Dergiler).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<YayınEvi> GetByIDYayinEvi(int id)
        {
            if (id < 1)
                return BadRequest();
            else
            {
                if (_context.YayınEvleri.Where(a => a.ID == id).Count() == 0)
                    return NotFound();
                else
                    return _context.YayınEvleri.Include(x=>x.Dergiler).Where(a => a.ID == id).SingleOrDefault();
            }
           
        }

        [HttpPut("{id}")]
        public ActionResult<YayınEvi> editYayinEvi(int id, YayınEvi değişecek)
        {
            if (id < 1)
                return BadRequest();

            if (değişecek.ID != id)
                return BadRequest();

            if (_context.YayınEvleri.Where(a => a.ID == id).Count() == 0)
                return NotFound();
           
            else

            try
            {
                _context.YayınEvleri.Update(değişecek);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

               return BadRequest();
            }

        }

    }
}
