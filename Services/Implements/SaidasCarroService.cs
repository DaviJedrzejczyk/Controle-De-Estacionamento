using DataAccessLayer.Interfaces;
using Entities;
using Services.Interfaces;
using Services.Validation;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class SaidasCarroService : ISaidaCarroService
    {
        private readonly IUnityOfWork _unityOfWork;
        public SaidasCarroService(IUnityOfWork _unityOfWork)
        {
            this._unityOfWork = _unityOfWork;
        }
        public async Task<Response> Insert(SaidasCarro item)
        {
            Response responseDataValida = Validators.CreateInstance().VerificaAsDatas(item.Carro.HorarioEntrada, item.HorarioSaida);
            if (responseDataValida.HasSuccess)
            {

                SingleResponse<double> responseValorPagar = Validators.CreateInstance().VerificaQuantiaASerPaga(item.Carro.HorarioEntrada, item.HorarioSaida, item.Preco);
                if (responseValorPagar.HasSuccess)
                {
                    SingleResponse<string> responseDuracao = Validators.CreateInstance().VerificaQuantidadeTempoFicado(item.Carro.HorarioEntrada, item.HorarioSaida);
                    if (responseDuracao.HasSuccess)
                    {
                        SingleResponse<int> responseTempoCobrado = Validators.CreateInstance().PegaOTempoCobrado(item.Carro.HorarioEntrada, item.HorarioSaida);
                        if (responseTempoCobrado.HasSuccess)
                        {
                            item.ValorPagar = responseValorPagar.Item;
                            item.TempoFicado = responseDuracao.Item;
                            item.TempoCobrado = responseTempoCobrado.Item;
                            item.Carro.TemSaida = true;
                            Response response = await _unityOfWork.SaidasCarroDAL.Insert(item);
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
                        return ResponseFactory.CreateInstance().CreateFailureResponse(responseTempoCobrado.Exception.Message);
                    }
                    return ResponseFactory.CreateInstance().CreateFailureResponse(responseDuracao.Exception.Message);
                }
                return ResponseFactory.CreateInstance().CreateFailureResponse(responseValorPagar.Exception.Message);
            }
            return ResponseFactory.CreateInstance().CreateFailureResponse(responseDataValida.Message);
        }
        public async Task<DataResponse<SaidasCarro>> GetAll()
        {
            return await _unityOfWork.SaidasCarroDAL.GetAll();
        }

        public async Task<SingleResponse<SaidasCarro>> GetById(int id)
        {
            return await _unityOfWork.SaidasCarroDAL.GetById(id);
        }

        public async Task<DataResponse<SaidasCarro>> FilterData(DateTime dataEntrada, DateTime dataSaida)
        {
            Response responseDataValida = Validators.CreateInstance().VerificaAsDatas(dataEntrada, dataSaida);
            if (responseDataValida.HasSuccess)
            {
                return await _unityOfWork.SaidasCarroDAL.FilterData(dataEntrada, dataSaida);
            }
            return ResponseFactory.CreateInstance().CreateFailureDataResponse<SaidasCarro>(responseDataValida.Message);

        }
    }
}
