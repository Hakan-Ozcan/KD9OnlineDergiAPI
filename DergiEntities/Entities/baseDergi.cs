using KD9OnlineDergiAPI.Model.Enums;

namespace KD9OnlineDergiAPI.Entities
{
    public class baseDergi
    {
        public string dergiAdı { get; set; }
        public DergiTürleri dergiTürleri { get; set; }
        public YayınAralığı yayınAralığı { get; set; }
        public int yayınEviId { get; set; }
    }
}
