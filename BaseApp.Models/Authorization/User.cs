using BaseApp.Models.Core;

namespace BaseApp.Models.Authorization
{
    public class User : ModelBase
    {
        public string UserID { get; set; }
        public string AccessKey { get; set; }
    }
}
