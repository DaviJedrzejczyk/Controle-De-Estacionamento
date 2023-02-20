using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICarroDAL
    {
        Task<Response> InsertEntrada(Carro carro);
        Task<DataResponse<Carro>> GetAll();
        Task<DataResponse<Carro>> GetAllWithoutExits();
        Task<SingleResponse<Carro>> GetById(int id);
        Task<DataResponse<Carro>> SearchItem(string searchString);
    }
}
