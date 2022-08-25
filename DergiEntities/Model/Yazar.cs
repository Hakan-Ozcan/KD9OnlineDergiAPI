namespace KD9OnlineDergiAPI.Model
{
    public class Yazar
    {
        public Yazar()
        {
            YazdığıSayılar = new HashSet<Sayı>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sayı> YazdığıSayılar { get; set; }
    }
}
