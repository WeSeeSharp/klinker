﻿using System.Linq;
using System.Threading.Tasks;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.General;
using Microsoft.EntityFrameworkCore;

namespace BabySitter.Core.BabySitters.Shifts.Queries
{
    public class GetBabySitterShiftsArgs
    {
        public int SitterId { get; }

        public GetBabySitterShiftsArgs(int sitterId)
        {
            SitterId = sitterId;
        }
    }

    public class GetBabySitterShiftsQuery : IQueryHandler<GetBabySitterShiftsArgs, ShiftModel[]>
    {
        private readonly DatabaseContext _context;

        public GetBabySitterShiftsQuery(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ShiftModel[]> Execute(GetBabySitterShiftsArgs args)
        {
            return await _context.Shifts
                .Where(s => s.Sitter.Id == args.SitterId)
                .Select(Shift.ToModelExpression())
                .ToArrayAsync();
        }
    }
}