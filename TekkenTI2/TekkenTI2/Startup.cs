﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TekkenTI2.Startup))]
namespace TekkenTI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
