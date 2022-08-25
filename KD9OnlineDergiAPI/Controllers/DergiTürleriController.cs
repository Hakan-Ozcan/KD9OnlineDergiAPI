using KD9OnlineDergiAPI.Model.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KD9OnlineDergiAPI.Controllers
{
    [Route("yayin-evleri/tur")]
    [ApiController]
    public class DergiTürleriController : ControllerBase
    {
        [HttpGet]
        public Dictionary<string,DergiTürleri> list()
        {
            string[] isimler = Enum.GetNames<DergiTürleri>();
            DergiTürleri[] değerler = Enum.GetValues<DergiTürleri>();

            Dictionary<string,DergiTürleri> keys = new Dictionary<string,DergiTürleri> ();

            for (int i = 0; i < isimler.Length; i++)
            {
                keys.Add(isimler[i], değerler[i]);
            }
            return keys;
        }

        //[HttpGet("{rowNo}")]
        //public DergiTürleri item(int rowNo)
        //{
        //    return (DergiTürleri)rowNo;
        //}
    }
}
