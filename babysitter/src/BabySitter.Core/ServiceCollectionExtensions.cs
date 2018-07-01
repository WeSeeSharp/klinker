using System;
using BabySitter.Core.BabySitters;
using BabySitter.Core.BabySitters.Commands;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.BabySitters.Queries;
using BabySitter.Core.BabySitters.Shifts.Commands;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.BabySitters.Shifts.Queries;
using BabySitter.Core.BabySitters.Validation;
using BabySitter.Core.General;
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
            services.AddTransient<ICommandWithResult<AddBabySitterArgs, SitterModel>, AddBabySitterCommand>();
            services.AddTransient<ICommandWithResult<StartShiftArgs, ShiftModel>, StartShiftCommand>();
            services.AddTransient<ICommand<UpdateBabySitterArgs>, UpdateBabySitterCommand>();
            services.AddTransient<ICommand<EndShiftArgs>, EndShiftCommand>();
            services.AddTransient<IValidator<Sitter>, SitterValidator>();
            return services;
        }
    }
}