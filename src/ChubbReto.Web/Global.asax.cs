using Autofac;
using Autofac.Integration.Mvc;
using ChubbReto.Application.Authors;
using ChubbReto.Application.Books;
using ChubbReto.Application.Genres;
using ChubbReto.Application.Shared;
using ChubbReto.Domain.Repositories;
using ChubbReto.Infraestructure.Database;
using ChubbReto.Infraestructure.Repositories;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ChubbReto.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            string connectionString = ConfigurationManager
                                .ConnectionStrings["DefaultConnection"]
                                .ConnectionString;


            var builder = new ContainerBuilder();

            builder.RegisterInstance(new SqlConnectionFactory(connectionString))
                                    .As<IDbConnectionFactory>()
                                    .SingleInstance();

            builder.RegisterInstance(new BookSettings
            {
                MaxBooksPerAuthor = int.Parse(ConfigurationManager.AppSettings["MaxBooksPerAuthor"] ?? "5")
            }).SingleInstance();

            //Repositories
            builder.RegisterType<GenreRepositry>().As<IGenreRepository>().InstancePerRequest();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerRequest();
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerRequest();

            //Services
            builder.RegisterType<GenreService>().As<IGenreService>().InstancePerRequest();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerRequest();
            builder.RegisterType<BookService>().As<IBookService>().InstancePerRequest();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
