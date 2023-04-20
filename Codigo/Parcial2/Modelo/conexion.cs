using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;

namespace Modelo
{
    class conexion
    {
        public OdbcConnection cconexion()
        {
            
            OdbcConnection conn = new OdbcConnection("Dsn=siu");
            try
            {
                conn.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("Conexion exitosa");
            }
            return conn;
        }

        
        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No se pudo conectar");
            }
        }



    }
}
