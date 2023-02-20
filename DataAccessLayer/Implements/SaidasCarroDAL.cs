using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implements
{
    public class SaidasCarroDAL : ISaidasCarroDAL
    {
        private readonly EstacionamentoDB _db;
        public SaidasCarroDAL(EstacionamentoDB db)
        {
            _db = db;
        }
        public async Task<Response> Insert(SaidasCarro item)
        {
            try
            {
                await _db.SaidasCarros.AddAsync(item);
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }
        public async Task<DataResponse<SaidasCarro>> GetAll()
        {
            try
            {
                List<SaidasCarro> saidas = await _db.SaidasCarros.Include(c => c.Carro).AsNoTracking().ToListAsync();
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(saidas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<SaidasCarro>(ex);
            }
        }

        public async Task<SingleResponse<SaidasCarro>> GetById(int id)
        {
            try
            {
                SaidasCarro saidas = await _db.SaidasCarros.FindAsync(id);
                if (saidas is null)
                {
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<SaidasCarro>();
                }
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(saidas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<SaidasCarro>(ex);
            }
        }

        public async Task<DataResponse<SaidasCarro>> FilterData(DateTime dataEntrada, DateTime dataSaida)
        {
            try
            {
                List<SaidasCarro> carros = await _db.SaidasCarros.Include(c => c.Carro).Where(c => c.Carro.HorarioEntrada >= dataEntrada && c.HorarioSaida <= dataSaida).ToListAsync();
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(carros);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<SaidasCarro>(ex);
            }
        }
    }
}
