using Evaluacion2.Models;
namespace Evaluacion2.Responses
{
    public class UsuarioResponses : ResponseBase<Usuario>
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
}
