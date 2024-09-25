using Evaluacion2.Models;

namespace Evaluacion2.Responses
{
    public class ProyectoResponses : ResponseBase<Proyecto>
    {
    }

    public class ProyectosResponses : ResponseBase<List<Proyecto>> 
    { 
    }

    public class NuevoProyectoResponses : ResponseBase<bool> 
    { 
    }

    public class EliminarProyectoResponses : ResponseBase<bool> 
    { 
    }

    public class ActualizarProyectoResponses : ResponseBase<bool>
    {
    }
}
