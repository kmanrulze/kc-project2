using System;
using System.Collections.Generic;
using System.Text;
using Dbnd.Logic.Interfaces;

namespace Dbnd.Data.Repository
{
    class Repository : IRepository
    {
        private readonly ApplicationContext _context;
        public Repository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
