﻿using BaseApp.Models.Core;

namespace BaseApp.Models.Authorization
{
    public class Token : ModelBase
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
    }
}
