using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICarroService
    {
        Task<Response> InsertEntrada(Carro carro);
        Task<DataResponse<Carro>> GetAll();
        Task<DataResponse<Carro>> GetAllWithoutExits();
        Task<SingleResponse<Carro>> GetById(int id);
        Task<DataResponse<Carro>> SearchItem(string searchString);
    }
}
