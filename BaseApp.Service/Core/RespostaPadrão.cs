using System;
using System.Collections.Generic;
using System.Text;

namespace BaseApp.Service.Core
{
    public class RespostaPadrão<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Content { get; set; }
    }
}
