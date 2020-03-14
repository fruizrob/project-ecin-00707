namespace backend.Models
{
    public class temp_categorization 
    {
        public int Id { set; get; }

        public string categorization { set; get; }

        public int patientId { set; get; }

        public bool is_warning { set; get; }

        public temp_categorization() {}

    }
}