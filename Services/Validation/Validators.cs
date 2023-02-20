using Services.Validation.Constants;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Validation
{
    internal class Validators
    {
        private static Validators _factory;
        public static Validators CreateInstance()
        {
            if (_factory == null)
            {
                _factory = new Validators();
            }
            return _factory;
        }

        public bool ValidatePlaca(string placa)
        {
            bool isMatch = Regex.IsMatch(placa, "[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");
            if (!isMatch)
            {
                return false;
            }
            return true;
        }
        public SingleResponse<double> VerificaQuantiaASerPaga(DateTime dataEntrada, DateTime dataSaida, double valor)
        {
            TimeSpan timeSpan = dataSaida - dataEntrada;
            if (timeSpan.TotalMinutes <= 30)
            {
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(valor / 2);
            }
            else if (timeSpan.Minutes <= 10)
            {
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(valor * timeSpan.Hours);
            }
            else if (timeSpan.Minutes > 10)
            {
                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(valor * (timeSpan.Hours + 1));
            }
            return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(valor * timeSpan.Hours);
        }
        public SingleResponse<string> VerificaQuantidadeTempoFicado(DateTime dataEntrada, DateTime dataSaida)
        {
            TimeSpan time = dataSaida - dataEntrada;
            var tempoFicado = time.ToString("''hh':'mm':'ss''");
            return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(tempoFicado);
        }
        public SingleResponse<int> PegaOTempoCobrado(DateTime dataEntrada, DateTime dataSaida)
        {
            TimeSpan time = dataSaida - dataEntrada;
            int data = 0;
            if (time.Minutes < 15)
            {
                data = time.Hours;
            }
            else
            {
                data = time.Hours + 1;
            }
            return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(data);
        }

        public Response VerificaAsDatas(DateTime dataEntrada, DateTime dataSaida)
        {
            if (dataEntrada > dataSaida)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(GenericConstants.MENSAGEM_FALHA_DATA_ENTRADA_MAIOR_SAIDA);
            }
            else if (dataEntrada > DateTime.Now)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(GenericConstants.MENSAGEM_FALHA_DATA_ENTRADA_MAIOR_AGORA);
            }
            else if(dataSaida < dataEntrada)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(GenericConstants.MENSAGEM_FALHA_DATA_SAIDA_MENOR_ENTRADA);
            }
            return ResponseFactory.CreateInstance().CreateSuccessResponse();
        }

    }
}
