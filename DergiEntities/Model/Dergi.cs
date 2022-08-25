using KD9OnlineDergiAPI.Entities;
using KD9OnlineDergiAPI.Model.Enums;
namespace KD9OnlineDergiAPI.Model
{
    public class Dergi
    {
        public Dergi()
        {
            baseConstructor();
        }
        public Dergi(baseDergi dergi)
        {
            baseConstructor();
            this.Base = dergi;
            //basedenBilgiOku(dergi);
        }
        private void baseConstructor()
        {
            Sayılar = new HashSet<Sayı>();
            ID = new Guid();
            Base = new baseDergi();
        }

        //public void basedenBilgiOku(baseDergi dergi)
        //{
        //    Base = dergi;
        //    //dergiAdı = dergi.dergiAdı;
        //    //dergiTürleri = dergi.dergiTürleri;
        //    //yayınAralığı = dergi.yayınAralığı;
        //    //yayınEviId = dergi.yayınEviId;
        //}
        
        private baseDergi Base { get; set; }
        public Guid ID { get; set; }

        //base dergiden gelecek
        public string dergiAdı { get { return this.Base.dergiAdı; } set { this.Base.dergiAdı = value; } }
        public DergiTürleri dergiTürleri { get { return this.Base.dergiTürleri; } set { this.Base.dergiTürleri = value; } }
        public YayınAralığı yayınAralığı { get { return this.Base.yayınAralığı; } set { this.Base.yayınAralığı = value; } }
        public int yayınEviId { get { return this.Base.yayınEviId; } set { this.Base.yayınEviId = value; } }
        public YayınEvi? yayınEvi { get; set; }
        public ICollection<Sayı>Sayılar { get; set; }

    }
}
