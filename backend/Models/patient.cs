namespace backend.Models
{
    public class patient
    {
        public int Id { get; set; }
        public int age { get; set; }
        public string diagnosis { get; set; }
        public int current_acount { get; set; }
        public string destination { get; set; }
        public bool stretcher { get; set; }
        public string type_stretcher { get; set; }
        public bool more_12h { get; set; }
        public string him { get; set; }
        public string UGCC { get; set; }
        public int sectorId { get; set; }
    }
}