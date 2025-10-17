using Microsoft.Data.Sqlite;
string connectionString = "Data Source=Tienda.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un porgrama real
    // la aplicamos para poder crear nuestra base de datos desde cero
    string createTableQuery = "CREATE TABLE IF NOT EXISTS productos (id INTEGER PRIMARY KEY, nombre TEXT, precio REAL)";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }
    
    // Insertar datos
    // string insertQuery = "INSERT INTO productos (nombre, precio) VALUES ('Melon', 0.90), ('Pera', 0.30)";
    //         using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
    //         {   
    //             insertCmd.ExecuteNonQuery();
    //             Console.WriteLine("Datos insertados en la tabla 'productos'.");
    //         }
    // Leer datos
            string selectQuery = "SELECT * FROM Productos";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
            using (SqliteDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("Datos en la tabla 'Productos':");
                while (reader.Read())
                {
                    Console.WriteLine($"Nombre: {reader["Descripcion"]}, Precio: {reader["Precio"]}");
                }
            }

            connection.Close();
}