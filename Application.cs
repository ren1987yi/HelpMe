using Godot;
using HelpMe.service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe
{
    public class Application
    {
        public static IServiceProvider Service = ConfigureServices();


        private static IServiceProvider ConfigureServices()
        {
            var builder = new ServiceCollection();
            // Register your services here
            // services.AddTransient<IMyService, MyService>();
            AddSingleton(builder);
            AddTransient(builder);
            return builder.BuildServiceProvider();
        }


        private static void AddSingleton(ServiceCollection builder)
        {
            builder.AddSingleton<SceneService>();
            builder.AddSingleton<BattleService>();
        }

        private static void AddTransient(ServiceCollection builder)
        {

        }
    }
}
