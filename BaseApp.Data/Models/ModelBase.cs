using SQLite;

namespace BaseApp.Data.Models
{
    public class ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
