namespace backend.Models
{
    public class patient
    {
        public int Id { get; set; }
        public int years { get; set; }
        public string diagnosis { get; set; }
        public string current_acount { get; set; }
        public string destination { get; set; }
        public string type_bed { get; set; }
        public bool more_12h { get; set; }
        public string him { get; set; }
        public string ugcc { get; set; }
        public int start { get; set; }
        public int sectorId { get; set; }
    }
}