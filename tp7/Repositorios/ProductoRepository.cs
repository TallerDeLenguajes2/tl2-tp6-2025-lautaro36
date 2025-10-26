using Microsoft.Data.Sqlite;
public class ProductoRepository
{
    string stringConnection = "Data Source=Tienda.db;Cache=Shared";
    public SqliteConnection GetOpenConnection()
    {
        SqliteConnection connection = new SqliteConnection(stringConnection);
        connection.Open();
        return connection;
    }
    public void crearProducto(Producto producto) //● Crear un nuevo Producto. (recibe un objeto Producto)
    {
        using (var connection = GetOpenConnection())
        {
            string queryString = $"INSERT INTO Productos (Descripcion, Precio) VALUES (@descripcion, @precio)";
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.Add(new SqliteParameter("@descripcion", producto.Descripcion));
            command.Parameters.Add(new SqliteParameter("@precio", producto.Precio));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    // public void ModificarProducto(int IdProducto, Producto producto)
    // {
    //     using (var connection = GetOpenConnection())
    //     {
    //         string queryString = $"UPDATE Producto SET Descripcion = @descripcion, Precio = @precio";
    //         var command = new SqliteCommand(queryString, connection);

    //         command.Parameters.Add(new SqliteParameter("@descripcion", ))
    //     }
    // }
    public List<Producto> GetAll() //● Listar todos los Productos registrados. (devuelve un List de Producto)
    {
        using var connection = GetOpenConnection();
        var queryString = $"SELECT * FROM Productos";
        List<Producto> productos = [];

        var command = new SqliteCommand(queryString, connection);

        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var producto = new Producto
                {
                    IdProducto = Convert.ToInt32(reader["idProducto"]),
                    Descripcion = reader["Descripcion"].ToString(),
                    Precio = Convert.ToInt32(reader["Precio"])
                };
                productos.Add(producto);
            }
        }

        connection.Close();
        return productos;
    }

    public Producto GetDetallesByID(int id)
    {
        var producto = new Producto();

        using var connection = GetOpenConnection();
        var queryString = $"SELECT IdProducto, Descripcion, Precio FROM Productos WHERE IdProducto = @id";
        var command = new SqliteCommand(queryString, connection);

        command.Parameters.Add(new SqliteParameter("@id", id));

        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                producto.Descripcion = reader["Descripcion"].ToString();
                producto.Precio = Convert.ToInt32(reader["Precio"]);
            }
        }

        connection.Close();
        return producto;
    }

    public void DeleteByID(int id)
    {
        using (var connection = GetOpenConnection())
        {
            string queryString = $"DELETE IdProducto, Descripcion, Precio FROM Productos WHERE IdProducto = @id";
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.Add(new SqliteParameter("@id", id));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }

}