using Microsoft.AnalysisServices.AdomdClient;
namespace cube_api.Data
{
    public class CubeConnection
    {
        private readonly string _connectionString;

        public CubeConnection()
        {
            // Ajustar la cadena de conexión a tu servidor SSAS
            _connectionString = "Data Source=LOCALHOST;Catalog=CubeTecnoNic;";
        }

        public AdomdConnection GetConnection()
        {
            try
            {
                var connection = new AdomdConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                // Aquí capturamos cualquier excepción y lanzamos una personalizada
                throw new Exception("No se ha podido conectar al cubo de datos. Verifique la conexión y los parámetros. Detalle del error: " + ex.Message);
            }
        }
    }
}
