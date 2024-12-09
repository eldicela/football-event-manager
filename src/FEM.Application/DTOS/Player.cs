
namespace FEM.Application.DTOS
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
    }

    public class PlayerAddRequestModel
    {
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
