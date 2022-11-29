using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Course_Homework.Startup))]
namespace Course_Homework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
