using BaseApp.Models.Api;
using BaseApp.Models.Interfaces.Authorization;
using BaseApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseApp.Service.Services
{
    public class ValueService : ServiceBase<Value>, IValueService
    {
        public ValueService(IToken _token) : base("Values", _token)
        {

        }
    }
}
