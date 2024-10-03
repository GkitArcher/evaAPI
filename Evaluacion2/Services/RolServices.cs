﻿using Evaluacion2.Data;
using Evaluacion2.Models;
using Microsoft.EntityFrameworkCore;


namespace Evaluacion2.Services
{
    public class RolServices
    {
        private readonly ProyectoDBContext _context;

        public RolServices(ProyectoDBContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Rol>> ObtenerTodosLosRoles()
        {
            return await _context.Roles.ToListAsync();
        }


        public async Task<List<Usuario>> ObtenerUsuariosPorRol(int rolId)
        {
            return await _context.Usuarios
                .Where(u => u.RolId == rolId)
                .ToListAsync();
        }
    }
}

