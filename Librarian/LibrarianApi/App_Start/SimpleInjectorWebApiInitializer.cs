using Librarian.API.Repositories;
using System.Web.Http;
using Librarian.Entities;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

//[assembly: WebActivator.PostApplicationStartMethod(typeof(Librarian.API.SimpleInjectorWebApiInitializer), "Initialize")]
namespace Librarian.API
{
  public static class SimpleInjectorWebApiInitializer
  {
    /// <summary>
    /// Initialize the container and register it as Dependency Resolver.
    /// 
    /// Originally there is no parameter but GlobalConfiguration.Configuration is not working so the configuration was passed from WebApiConfig.cs
    /// </summary>
    public static void Initialize(HttpConfiguration config)
    {
      // Did you know the container can diagnose your configuration? 
      // Go to: https://simpleinjector.org/diagnostics
      var container = new Container();

      InitializeContainer(container);

      //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
      container.RegisterWebApiControllers(config);

      container.Verify();

      //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
      config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
    }

    private static void InitializeContainer(Container container)
    {
      // For instance:
      // container.RegisterWebApiRequest<IUserRepository, SqlUserRepository>();

      container.RegisterWebApiRequest<IAuthenticationRepository, AuthenticationRepository>();
      container.RegisterWebApiRequest<IRepository<Book>, BookRepository>();
      container.RegisterWebApiRequest<IRepository<Transaction>, TransactionRepository>();
    }
  }
}