using ASPNetMVCExtendingIdentity2Roles.App_code;
using NHibernate;
using PestControl.Core;
using PestControl.Model.Entity;
using PestControl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace PestControl.Web.Constraints
{
    public class FriendlyURLConstraint : IRouteConstraint
    {
        private ISession _session;
        private ISessionFactory _sessionFactory;
        private void CreateSession()
        {
            _sessionFactory = new NhSessionFactory().GetSessionFactory();
            _session = _sessionFactory.OpenSession();
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string friendlyURL = values["friendlyURL"].ToString();
            CreateSession();
            var menu = _session.QueryOver<Menu>().Where(x => x.FriendlyUrl == friendlyURL && x.Status >= 0).SingleOrDefault();
            if (menu != null) return true;


            var subMenu = _session.QueryOver<ProductServices>().Where(x => x.FriendlyUrl == friendlyURL && x.Status >= 0).SingleOrDefault();
            if (subMenu != null) return true;
            
            return false;
        }
    }
}