namespace backend.Models
{
    public class mov_history
    {
       public int Id { set; get; }
       public int userId { set; get; }
       public int patientsId { set; get; }
       public string origin { set; get; }
       public string destination { set; get; }
       public int date { set; get; }
       public int time { set; get; }
    }
}