using Desafio.WebMotors.Data;

namespace Desafio.WebMotors.Repository
{
    public interface ITbAnuncioWebmotor
    {
        int Add(Data.TbAnuncioWebmotor tbAnuncioWebmotor); 
        List<Data.TbAnuncioWebmotor> GetAll();
        Data.TbAnuncioWebmotor GetTbAnuncioWebmotor(int id); 
        int Edit(Data.TbAnuncioWebmotor tbAnuncioWebmotor);
        int Delete(int Id);
    }
}
