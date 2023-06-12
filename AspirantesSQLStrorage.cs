using System.Data;
using System.Data.SqlClient;
using WebApplication1.Entities;

namespace WebApplication1
{
    public class AspirantesSQLStrorage
    {
        public List<Aspirantes> AspirantesList;

        public bool Insert(string nombre, string apellido, string correoElectronico, string numTelefonico, string lugarNacimiento)
        {
            var connect = new SqlConnection("Server=68.168.208.58; Initial Catalog=AspirantesWeb; User Id=aspiranteUser; Password=Oa76p81h&");
            var query = new SqlCommand("INSERT INTO adminDrug.Aspirantes (nombre, apellido, correoElectronico, numTelefonico, lugarNacimiento) VALUES (@nombre, @apellido, @correoElectronico, @numTelefonico, @lugarNacimiento)", connect);
            query.Parameters.AddWithValue("@nombre", nombre);
            query.Parameters.AddWithValue("@apellido", apellido);
            query.Parameters.AddWithValue("@correoElectronico", correoElectronico);
            query.Parameters.AddWithValue("@numTelefonico", numTelefonico);
            query.Parameters.AddWithValue("@lugarNacimiento", lugarNacimiento);
            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return true;

            }
            catch (Exception)
            {

                connect.Close();
                return false;
            }
        }

        public bool Update(int id, string nombre, string apellido, string correoElectronico, string numTelefonico, string lugarNacimiento)
        {
            var connect = new SqlConnection("Server=68.168.208.58; Initial Catalog=AspirantesWeb; User Id=aspiranteUser; Password=Oa76p81h&");
            var query = new SqlCommand("UPDATE AspirantesWeb.adminDrug.Aspirantes SET nombre = @nombre, apellido = @apellido, correoElectronico = @correoElectronico, numTelefonico = @numTelefonico, lugarNacimiento = @lugarNacimiento WHERE id = @id", connect);
            query.Parameters.AddWithValue("@id", id);
            query.Parameters.AddWithValue("@nombre", nombre);
            query.Parameters.AddWithValue("@apellido", apellido);
            query.Parameters.AddWithValue("@correoElectronico", correoElectronico);
            query.Parameters.AddWithValue("@numTelefonico", numTelefonico);
            query.Parameters.AddWithValue("@lugarNacimiento", lugarNacimiento);

            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception)
            {
                connect.Close();
                return false;
            }
        }

        public bool Delete(int id)
        {
            var connect = new SqlConnection("Server=68.168.208.58; Initial Catalog=AspirantesWeb; User Id=aspiranteUser; Password=Oa76p81h&");
            var query = new SqlCommand("DELETE FROM AspirantesWeb.adminDrug.Aspirantes WHERE id = @id", connect);
            query.Parameters.AddWithValue("@id", id);

            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception)
            {
                connect.Close();
                return false;
            }
        }

        public List<Aspirantes> GetAll()
        {
            var dt = new DataTable();
            var connect = new SqlConnection("Server=68.168.208.58; Initial Catalog=AspirantesWeb; User Id=aspiranteUser; Password=Oa76p81h&");
            var cmd = new SqlCommand("SELECT * FROM AspirantesWeb.adminDrug.Aspirantes", connect);
            try
            {
                AspirantesList = new List<Aspirantes>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Aspirantes client = new Aspirantes();
                    client.id = int.Parse((dt.Rows[i]["id"]).ToString());
                    client.nombre = dt.Rows[i]["nombre"].ToString();
                    client.apellido = dt.Rows[i]["apellido"].ToString();
                    client.correoElectronico = dt.Rows[i]["correoElectronico"].ToString();
                    client.numTelefonico = dt.Rows[i]["numTelefonico"].ToString();
                    client.lugarNacimiento = dt.Rows[i]["lugarNacimiento"].ToString();
                    AspirantesList.Add(client);
                }
                return AspirantesList;
            }
            catch (Exception)
            {
                connect.Close();
                return AspirantesList;
            }
        }

        public List<Aspirantes> GetById(int id)
        {
            var dt = new DataTable();
            var connect = new SqlConnection("Server=68.168.208.58; Initial Catalog=AspirantesWeb; User Id=aspiranteUser; Password=Oa76p81h&");
            var cmd = new SqlCommand("SELECT * FROM AspirantesWeb.Aspirantes WHERE id ='" + id + "'", connect);
            try
            {
                AspirantesList = new List<Aspirantes>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Aspirantes client = new Aspirantes();
                    client.id = int.Parse((dt.Rows[i]["id"]).ToString());
                    client.nombre = dt.Rows[i]["nombre"].ToString();
                    client.apellido = dt.Rows[i]["apellido"].ToString();
                    client.correoElectronico = dt.Rows[i]["correoElectronico"].ToString();
                    client.numTelefonico = dt.Rows[i]["numTelefonico"].ToString();
                    client.lugarNacimiento = dt.Rows[i]["lugarNacimiento"].ToString();
                    AspirantesList.Add(client); ;
                }
                return AspirantesList;
            }
            catch (Exception)
            {
                connect.Close();
                return AspirantesList;
            }
        }
    }
}
