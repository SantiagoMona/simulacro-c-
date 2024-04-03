namespace simulacro.Models
{   
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set;}
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BrithDate { get; set; }
    }
}