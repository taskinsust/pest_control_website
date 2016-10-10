using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Dao.Base;

namespace PestControl.Services.Base
{
    public interface IBaseService
    {
        void Flush();
        ArrayList SearchEntityByKey<TEntityT, TIdT>(IBaseDao<TEntityT, TIdT> dao, string key, object value);
        ArrayList SearchEntityByKey<TEntityT, TIdT>(IBaseDao<TEntityT, TIdT> dao, string[] fields, object[] values, string[] operators, string[] conditionalOperator);
        ArrayList SearchEntityByKeyAndLikeValue<TEntityT, TIdT>(IBaseDao<TEntityT, TIdT> dao, string field, object value);


        DateTime FloorDate(DateTime dt);
        DateTime CeilDate(DateTime dt);
    }
}
