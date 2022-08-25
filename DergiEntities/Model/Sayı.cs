namespace KD9OnlineDergiAPI.Model
{
    public class Sayı
    {
        public Sayı()
        {
            Yazarlar = new HashSet<Yazar>();
        }
        //İkisi beraber primary key--Composite Key
        public Guid  DergiId { get; set; }
        public Dergi Dergi { get; set; }
        public int sayı { get; set; }
        public DateTime YayınTarihi { get; set; }
        public int SayfaSayısı { get; set; }
        public decimal Fiyat { get; set; }

        public ICollection<Yazar> Yazarlar { get; set; }
    }
}
