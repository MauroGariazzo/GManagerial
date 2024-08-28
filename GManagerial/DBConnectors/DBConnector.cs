using System.Data.SqlClient;

/*-creare un collegamento con il db tramite l'oggetto SqlConnection
-aprire o chiudere la connessione con il db attraverso i metodi Open() e Close() che richiamano il metodo open e close della classe SqlConnection
-eseguire le operazioni CRUD(CREATE, READ, UPDATE, DELETE) usando i metodi insert, load, update, delete*/


namespace GManagerial.DBConnectors
{
    internal class DBConnector:IDBConnector
    {
        SqlConnection _connection;
        public DBConnector(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnectionObj()
        {
            return _connection;
        }

        public void Insert(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }

        public SqlDataReader Load(SqlCommand command)
        {
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void Update(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }

        public void Delete(SqlCommand command) 
        {
            command.ExecuteNonQuery();
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close() 
        {
            _connection.Close();   
        }
    }
}
