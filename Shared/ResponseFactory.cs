﻿using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ResponseFactory
    {
        private static ResponseFactory _factory;
        public static ResponseFactory CreateInstance()
        {
            if (_factory == null)
            {
                _factory = new ResponseFactory();
            }
            return _factory;
        }
        public Response CreateSuccessResponse() => new()
        {
            HasSuccess = true,
            Message = ResponsesConstants.MENSAGEM_SUCESSO
        };
        public Response CreateFailureResponse() => new()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA
        };
        public Response CreateFailureResponse(string message) => new()
        {
            HasSuccess = false,
            Message = message
        };
        public Response CreateFailureResponse(Exception ex) => new()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
            Exception = ex
        };
        public SingleResponse<T> CreateSuccessSingleResponse<T>(T item) => new()
        {
            HasSuccess = true,
            Message = ResponsesConstants.MENSAGEM_SUCESSO,
            Item = item
        };
        public SingleResponse<T> CreateFailureSingleResponse<T>() => new()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
        };
        public SingleResponse<T> CreateFailureSingleResponse<T>(Exception ex) => new()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
            Exception = ex
        };
        public DataResponse<T> CreateSuccessDataResponse<T>(List<T> Itens) => new()
        {
            HasSuccess = true,
            Message = ResponsesConstants.MENSAGEM_SUCESSO,
            Itens = Itens,
        };
        public DataResponse<T> CreateFailureDataResponse<T>() => new()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
        };
        public DataResponse<T> CreateFailureDataResponse<T>(string message) => new()
        {
            HasSuccess = false,
            Message = message,
        };
        public DataResponse<T> CreateFailureDataResponse<T>(Exception ex) => new()
        {
            HasSuccess = false,
            Message = ResponsesConstants.MENSAGEM_FALHA,
            Exception = ex
        };
    }
}
