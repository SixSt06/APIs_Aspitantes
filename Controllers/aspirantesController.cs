using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class aspirantesController : ControllerBase
    {
        [HttpGet("Insert")]
        public string Insert(string nombre, string apellido, string correoElectronico, string numTelefonico, string lugarNacimiento)
        {
            var Insert = new AspirantesSQLStrorage();
            bool resultado = Insert.Insert(nombre, apellido, correoElectronico, numTelefonico, lugarNacimiento);
            if (resultado)
            {
                return "Almacenado en SQL Server desde API con .Net Core";
            }
            else
            {
                return "No se almaceno";
            }
        }

        [HttpGet("Update")]
        public string Update(int id, string nombre, string apellido, string correoElectronico, string numTelefonico, string lugarNacimiento)
        {
            var update = new AspirantesSQLStrorage();
            bool resultado = update.Update(id, nombre, apellido, correoElectronico, numTelefonico, lugarNacimiento);
            if (resultado)
            {
                return "Actualizado en SQL Server desde API con .NET Core";
            }
            else
            {
                return "No se pudo actualizar";
            }
        }

        [HttpGet("Delete")]
        public string Delete(int id)
        {
            var delete = new AspirantesSQLStrorage();
            bool resultado = delete.Delete(id);
            if (resultado)
            {
                return "Eliminado en SQL Server desde API con .NET Core";
            }
            else
            {
                return "No se pudo eliminar";
            }
        }


        [HttpGet("GetById")]
        public JsonResult Consultar(int id)
        {
            var Consulta = new AspirantesSQLStrorage();
            var Lista = Consulta.GetById(id);
            return new JsonResult(Lista);
        }

        [HttpGet("GetAll")]
        public JsonResult ConsultarTodo()
        {
            var Consulta = new AspirantesSQLStrorage();
            var Lista = Consulta.GetAll();
            return new JsonResult(Lista);
        }
    }
}
