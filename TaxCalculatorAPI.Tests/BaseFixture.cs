using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TaxCalculatorAPI.Models;
using TaxCalculatorAPI.Services;
using TaxCalculatorAPI.Services.Interfaces;
using Unity;

namespace TaxCalculatorAPI.Tests
{
    public abstract class BaseFixture
    {
        protected IUnityContainer Container { get; private set; }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Container = new UnityContainer();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
                .Build();

            var settings = config.GetSection("AppSettings").Get<AppSettings>();
            Container.RegisterInstance(settings);
            Container.RegisterType<ITaxCalculatorService, TaxCalculatorService>();
            Container.RegisterType<IFixerService, FixerService>();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            Container.Dispose();
        }
    }
}