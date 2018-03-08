using SQLite;

namespace BaseApp.LocalDatabase.Models
{
    public class ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
