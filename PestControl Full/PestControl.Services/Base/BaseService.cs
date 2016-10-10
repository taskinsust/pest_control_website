using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PestControl.Dao.Base;

namespace PestControl.Services.Base
{
    public class BaseService : IBaseService
    {
        protected internal ISession _session;

        public ArrayList SearchEntityByKey<TEntityT, TIdT>(IBaseDao<TEntityT, TIdT> dao, string field, object value)
        {
            return dao.SearchByFieldAndValue(field, value);
        }

        public ArrayList SearchEntityByKeyAndLikeValue<TEntityT, TIdT>(IBaseDao<TEntityT, TIdT> dao, string field, object value)
        {
            return dao.SearchByFieldAndLikeValue(field, value);
        }

        public ArrayList SearchEntityByKey<TEntityT, TIdT>(IBaseDao<TEntityT, TIdT> dao, string[] fields, object[] values, string[] operators, string[] conditionalOperator)
        {
            return dao.SearchByFieldsAndValues(fields, values, operators, conditionalOperator);
        }

        public void Flush()
        {
            _session.Flush();
        }

        public DateTime FloorDate(DateTime dt)
        {
            DateTime nDt = new DateTime(dt.Year, dt.Month, dt.Day);
            return nDt;
        }

        public DateTime CeilDate(DateTime dt)
        {
            DateTime nDt = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            return nDt;
        }

    }
}
