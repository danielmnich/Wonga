namespace Wonga.Models
{
    public class User
    {
        public int Id { get; set; }
        public decimal LoanAmount { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
