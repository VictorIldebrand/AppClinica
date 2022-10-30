
namespace Contracts.Dto.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ra { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Period { get; set; }
        public bool Active { get; set; }
        //public string DataAcesso { get => DateTime.Now.ToString(); }
        //public DateTime data_da_consulta { get; set; }
        //public string Money { get; set; }
        //public string MoneyFormatted { get => $"R${Money},00" ; }
    }

}
