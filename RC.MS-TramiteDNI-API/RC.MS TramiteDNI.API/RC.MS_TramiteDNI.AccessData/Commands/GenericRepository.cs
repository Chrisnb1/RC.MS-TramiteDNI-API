using Microsoft.EntityFrameworkCore;
using RC.MS_TramiteDNI.Domain.Commands;
using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RC.MS_TramiteDNI.AccessData.Commands
{
    public class GenericRepository : IGenericRepository
    {
        private ApplicationDBContext _context;
        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Add<T>(T entidad) where T : class
        {
            _context.Add(entidad);
            _context.SaveChanges();
        }

        public void Update<T>(T entidad) where T : class
        {
            _context.Entry(entidad).State = EntityState.Modified;
            _context.SaveChanges();
 
        }

        public void Remove<T>(T entidad) where T : class
        {
            _context.Remove(entidad);
            _context.SaveChanges();
        }
    }
}
