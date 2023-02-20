using Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ISaidasCarroDAL
    {

        Task<Response> Insert(SaidasCarro item);
        Task<DataResponse<SaidasCarro>> GetAll();
        Task<SingleResponse<SaidasCarro>> GetById(int id);
        Task<DataResponse<SaidasCarro>> FilterData(DateTime dataEntrada, DateTime dataSaida);
    }
}
