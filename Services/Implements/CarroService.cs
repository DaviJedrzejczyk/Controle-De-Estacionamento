using DataAccessLayer.Interfaces;
using Entities;
using Services.Interfaces;
using Services.Validation;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Services.Implements
{
    public class CarroService : ICarroService
    {
        private readonly IUnityOfWork _unityOfWork;
        public CarroService(IUnityOfWork _unityOfWork)
        {
            this._unityOfWork = _unityOfWork;
        }
        public async Task<Response> InsertEntrada(Carro carro)
        {
            if (!Validators.CreateInstance().ValidatePlaca(carro.Placa))
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse("Placa Inválida");
            }
            DataResponse<Carro> data = await _unityOfWork.CarroDAL.GetAll();
            foreach (var item in data.Itens)
            {
                if (item.Placa.Equals(carro.Placa) && !item.TemSaida)
                {
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Esse carro já está estacionado!");
                }
            }
            Response response = await _unityOfWork.CarroDAL.InsertEntrada(carro);
            if (response.HasSuccess)
            {
                response = await _unityOfWork.Commit();
                if (response.Exception != null)
                {
                    return response;
                }
            }
            return response;
        }
        public async Task<DataResponse<Carro>> GetAll()
        {
            return await _unityOfWork.CarroDAL.GetAll();
        }

        public async Task<SingleResponse<Carro>> GetById(int id)
        {
            return await _unityOfWork.CarroDAL.GetById(id);
        }

        public async Task<DataResponse<Carro>> GetAllWithoutExits()
        {
            return await _unityOfWork.CarroDAL.GetAllWithoutExits();
        }

        public async Task<DataResponse<Carro>> SearchItem(string searchString)
        {
            return await _unityOfWork.CarroDAL.SearchItem(searchString);
        }
    }
}
