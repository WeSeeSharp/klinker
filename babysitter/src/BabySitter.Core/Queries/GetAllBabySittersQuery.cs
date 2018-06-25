﻿using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.Models;
using BabySitter.Core.Storage;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.Queries
{
    public class GetAllBabySittersArgs
    {
        
    }
    
    public class GetAllBabySittersQuery : IQueryHandler<GetAllBabySittersArgs, BabySitterModel[]>
    {
        private readonly BabySitterContext _context;

        public GetAllBabySittersQuery(BabySitterContext context)
        {
            _context = context;
        }

        public async Task<BabySitterModel[]> Execute(GetAllBabySittersArgs args)
        {
            return await _context.BabySitters
                .Select(Entities.BabySitter.ToModelExpression())
                .ToArrayAsync();
        }
    }
}