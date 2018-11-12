using SQLite;

namespace justdoit {
    public interface ISQLite {
        SQLiteConnection GetConnection();
    }
}
