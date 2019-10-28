using System;
using System.Collections.Generic;
using System.Text;
using Dbnd.Logic.Interfaces;
using Dbnd.Data.Entities;

namespace Dbnd.Data.Repository
{
    class Repository : IRepository
    {
        private readonly DbndContext _context;
        public Repository(DbndContext context)
        {
            _context = context;
        }
    }
}
