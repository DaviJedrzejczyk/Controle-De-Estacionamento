using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implements
{
    public class CarroDAL : ICarroDAL
    {
        private readonly EstacionamentoDB _db;
        public CarroDAL(EstacionamentoDB db)
        {
            this._db = db;
        }
        public async Task<Response> InsertEntrada(Carro carro)
        {
            try
            {
                await _db.Carros.AddAsync(carro);
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }
        public async Task<DataResponse<Carro>> GetAll()
        {
            try
            {
                List<Carro> carros = await _db.Carros.ToListAsync();
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(carros);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Carro>(ex);
            }
        }
        public async Task<DataResponse<Carro>> GetAllWithoutExits()
        {
            try
            {
                List<Carro> carros = await _db.Carros.ToListAsync();
                List<Carro> carrosSemSaidas = new();
                foreach (var item in carros)
                {
                    if (!item.TemSaida)
                    {
                        carrosSemSaidas.Add(item);
                    }
                }
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(carrosSemSaidas);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Carro>(ex);
            }
        }

        public async Task<SingleResponse<Carro>> GetById(int id)
        {
            try
            {
                Carro carro = await _db.Carros.FindAsync(id);
                if (carro is null)
                {
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Carro>();
                }
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(carro);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Carro>(ex);
            }
        }

        public async Task<DataResponse<Carro>> SearchItem(string searchString)
        {
            try
            {
                List<Carro> carros = await _db.Carros.Where(c => c.Placa.ToLower().Contains(searchString.ToLower())).ToListAsync();
                List<Carro> carrosSemSaida = new();
                foreach (var item in carros)
                {
                    if (!item.TemSaida)
                    {
                        carrosSemSaida.Add(item);
                    }
                }
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(carrosSemSaida);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Carro>(ex);
            }
        }

    }
}
