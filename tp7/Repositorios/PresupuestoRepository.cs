using Microsoft.Data.Sqlite;
public class PresupuestoRepository
{
    string stringConnection = "Data Source=Tienda.db;Cache=Shared";
    public SqliteConnection GetConnection()
    {
        var connection = new SqliteConnection(stringConnection);
        connection.Open();
        return connection;
    }
    public void CrearPresupuesto(Presupuesto presupuesto)
    {
        using (var connection = GetConnection())
        {
            string queryString = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@nombre, @fecha)";
            var command = new SqliteCommand(queryString, connection);

            command.Parameters.Add(new SqliteParameter("@nombre", presupuesto.NombreDestinatario));
            command.Parameters.Add(new SqliteParameter("@fecha", presupuesto.FechaCreacion));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void AgregarAlPresupuesto(int idPresupuesto, int idProducto, int cantidad)
    {
        using (var connection = GetConnection())
        {
            string stringQuery = "INSERT INTO PresupuestosDetalle (IdPresupuesto, IdProducto, Cantidad) VALUES (@idPresupuesto, @idProducto, @cantidad)";
            var command = new SqliteCommand(stringQuery, connection);

            command.Parameters.Add(new SqliteParameter("@IdProducto", idProducto));
            command.Parameters.Add(new SqliteParameter("@IdPresupuesto", idPresupuesto));
            command.Parameters.Add(new SqliteParameter("@cantidad", cantidad));

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}