using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LibraryApplicationWithAuth.Bll.IServices;
using LibraryApplicationWithAuth.Bll.Services;
using LibraryApplicationWithAuth.Dao;
using LibraryApplicationWithAuth.Dao.IRepositories;
using LibraryApplicationWithAuth.Dao.Repositories;
using LibraryApplicationWithAuth.Handlers;
using LibraryApplicationWIthAuth.Business.IServices;
using LibraryApplicationWIthAuth.Business.Services;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace LibraryApplicationWithAuth
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICredentialCheckerService, CredentialCheckerService>();
            config.DependencyResolver = new UnityResolver(container);
            CommonServiceLocator.ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new AuthenticationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
