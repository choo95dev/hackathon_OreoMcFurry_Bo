using Stock_API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stock_API.Infrastructure.Repository
{
    public class MongoDBRepository
    {
        protected readonly MongoDBContext _context;

        public MongoDBRepository(MongoDBContext context)
        {
            _context = context;
        }
    }
}
