using System;
using BabySitter.Core.BabySitters;
using BabySitter.Core.BabySitters.Commands;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.BabySitters.Queries;
using BabySitter.Core.BabySitters.Shifts.Commands;
using BabySitter.Core.BabySitters.Shifts.Entities;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.BabySitters.Shifts.Queries;
using BabySitter.Core.BabySitters.Shifts.Services;
using BabySitter.Core.BabySitters.Shifts.Validation;
using BabySitter.Core.BabySitters.Validation;
using BabySitter.Core.General;
using BabySitter.Core.General.Cqrs;
using BabySitter.Core.General.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBabySitterServices(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<DatabaseContext>(options);
            services.AddTransient<NightlyChargeCalculator>();
            services.AddTransient<IQueryHandler<GetAllBabySittersArgs, SitterModel[]>, GetAllBabySittersQuery>();
            services.AddTransient<IQueryHandler<GetBabySitterByIdArgs, SitterModel>, GetBabySitterByIdQuery>();
            services.AddTransient<IQueryHandler<GetBabySitterShiftsArgs, ShiftModel[]>, GetBabySitterShiftsQuery>();
            services.AddTransient<IQueryHandler<GetBabySitterShiftByIdArgs, ShiftModel>, GetBabySitterShiftByIdQuery>();
            services.AddTransient<ICommandHandlerWithResult<AddBabySitterArgs, SitterModel>, AddBabySitterCommand>();
            services.AddTransient<ICommandHandlerWithResult<StartShiftArgs, ShiftModel>, StartShiftCommand>();
            services.AddTransient<ICommandHandler<UpdateBabySitterArgs>, UpdateBabySitterCommand>();
            services.AddTransient<ICommandHandler<EndShiftArgs>, EndShiftCommand>();
            services.AddTransient<IValidator<Sitter>, SitterValidator>();
            services.AddTransient<IValidator<Shift>, ShiftValidator>();
            services.AddTransient<IQueryBus, QueryBus>();
            services.AddTransient<ICommandBus, CommandBus>();
            services.AddLogging();
            return services;
        }
    }
}