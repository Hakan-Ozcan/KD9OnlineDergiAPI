namespace KD9OnlineDergiAPI.Model
{
    public class YayınEvi
    {
        public YayınEvi()
        {
            Dergiler = new HashSet<Dergi>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Dergi> Dergiler { get; set; }    
    }
}
