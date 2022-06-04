namespace Desafio.WebMotors.Models
{
    public class AnuncioDados
    {
        public List<Make> Makes { get; set; }
        public List<CarModel> Models { get; set; }
        public List<Version> Versions { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public Data.TbAnuncioWebmotor TbAnuncioWebmotor = new Data.TbAnuncioWebmotor();
    }
}
