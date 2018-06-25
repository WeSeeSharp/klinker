﻿using System;
using BabySitter.Core.Commands;
using BabySitter.Core.Models;
using BabySitter.Core.Queries;
using BabySitter.Core.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBabySitterServices(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<BabySitterContext>(options);
            services.AddTransient<NightlyChargeCalculator>();
            services.AddTransient<IQueryHandler<GetAllBabySittersArgs, BabySitterModel[]>, GetAllBabySittersQuery>();
            services.AddTransient<IQueryHandler<GetBabySitterByIdArgs, BabySitterModel>, GetBabySitterByIdQuery>();
            services.AddTransient<ICommandWithResult<AddBabySitterArgs, BabySitterModel>, AddBabySitterCommand>();
            return services;
        }
    }
}