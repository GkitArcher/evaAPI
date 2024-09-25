using Evaluacion2.Models;

namespace Evaluacion2.Responses
{
    public class TareaResponse : ResponseBase<Tarea>
    {
    }

    public class TareasResponse : ResponseBase<List<Tarea>>
    {
    }

    public class NuevaTareaResponse : ResponseBase<bool>
    {
    }

    public class EliminarTareaResponse : ResponseBase<bool>
    {
    }

    public class ActualizarTareaResponse : ResponseBase<bool>
    {
    }
}
