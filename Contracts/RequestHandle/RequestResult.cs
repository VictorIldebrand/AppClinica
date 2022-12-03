﻿using System;
using Contracts.Utils;

namespace Contracts.RequestHandle
{
    public class RequestResult<T>
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }



        public RequestResult(T _result, bool _hasError = false, string _message = null)
        {
            if (_result != null && _result.GetType().Equals(typeof(RequestAnswer)) && _message == null)
            {
                var reason = (RequestAnswer)Enum.Parse(typeof(T), _result.ToString(), true);

                _message = reason.GetDescription();
            }

            if (HasError)
            {
                Result = default;
            }
            else
            {
                Result = _result;
            }

            Message = _message;
            HasError = _hasError;
        }
    }
}
