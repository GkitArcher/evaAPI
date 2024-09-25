using Evaluacion2.Models;

namespace Evaluacion2.Responses
{
    public class UsuarioResponse : ResponseBase<Usuario>
    {
    }

    public class UsuariosResponse : ResponseBase<List<Usuario>>
    {
    }

    public class NuevoUsuarioResponse : ResponseBase<bool>
    {
    }

    public class EliminarUsuarioResponse : ResponseBase<bool>
    {
    }

    public class ActualizarUsuarioResponse : ResponseBase<bool>
    {
    }

    // Clase base para las respuestas
    public abstract class ResponseBase<T>
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }
    }
}
