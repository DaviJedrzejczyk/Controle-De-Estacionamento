using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation.Constants
{
    internal class GenericConstants
    {
        public const string MENSAGEM_FALHA_DATA_ENTRADA_MAIOR_SAIDA = "A data de entrada não pode ser maior que a de saída!";
        public const string MENSAGEM_FALHA_DATA_ENTRADA_MAIOR_AGORA = "A data de entrada não pode ser maior que a data de agora!";
        public const string MENSAGEM_FALHA_DATA_SAIDA_MENOR_ENTRADA = "A data de saida não pode ser menor que a data de entrada";
    }
}
