using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using PestControl.Model.Entity;

namespace ASPNetMVCExtendingIdentity2Roles.App_code
{
    public class NhSessionFactory
    {
        private ISessionFactory _sessionFactory;

        public ISessionFactory GetSessionFactory()
        {
            /*if (_sessionFactory == null)
            {*/
            _sessionFactory = Fluently.Configure().
                      Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager
                //.ConnectionStrings["UdvashErpConnectionString"].ConnectionString))
                          .ConnectionStrings["DefaultConnection"].ConnectionString))
                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Gallery>())
                //.ExposeConfiguration(BuildSchema)
                      .BuildSessionFactory();

            //  _sessionFactory = Fluently.Configure()
            //.Database(
            //  MsSqlConfiguration.MsSql2008.ConnectionString(
            //      x => x
            //      .Server("localhost")
            //      .Database("PestControl")
            //      .Username("taskin")
            //      .Password("123456")
            //      )
            //)
            //.Mappings(m =>
            //  m.FluentMappings.AddFromAssemblyOf<Client>())
            //      .ExposeConfiguration(BuildSchema)
            //.BuildSessionFactory();
            /* }*/
            return _sessionFactory;
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration obj)
         {
            var se = new SchemaExport(obj);
            se.Execute(true, true, false);
        }

        public ISession OpenSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}