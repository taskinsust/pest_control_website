using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Type;

namespace PestControl.Dao.Base
{
    public interface IBaseDao<TEntityT, idT>
    {
        ISession Session { get; set; }
        object Save(TEntityT data);
        void Delete(TEntityT data);
        void DeleteEntity(idT id);
        void Update(TEntityT data);
        void SaveOrUpdate(TEntityT data);
        void Marge(TEntityT data);

        IList LoadAll();
        ArrayList LoadAllOk();
        object LoadById(idT id);
        //TEntityT GetById(idT id);
        IList LoadByName(string name);
        TEntityT LoadSingleByName(string name);
        IList LoadByQuery(string query);
        ArrayList SearchByFieldAndKey(string searchBy, string key);
        ArrayList LoadByNameLike(string name);
        ArrayList SearchByFieldAndValue(string field, object value);
        ArrayList SearchByFieldAndLikeValue(string searchBy, object value);
        ArrayList SearchByFieldsAndValues(string[] fields, object[] values, string[] operators, string[] andOrOperator);
        ArrayList SearchBySubFieldAndValue(string searchBy, object value);

        IList Find(string query);
        IList Find(string query, object[] value);
        IList FindByNamedQuery(string namedQuery);
        IList FindByNamedQueryAndParam(string namedQuery, object[] value);
        int DeleteByNamedQuery(string queryName, object value, IType type);
        int DeleteByNamedQuery(string queryName, object[] values, IType[] types);
        IList FindByNamedQuery(string queryName, object value, IType type);
        IList FindByNamedQuery(string queryName, object[] values, IType[] types);
        IList FindPage(string queryString, int pageIndex, int pageSize);
        IList FindPageByNamedQuery(string queryName, int pageIndex, int pageSize);
        IList FindPageByNamedQuery(string queryName, object value, IType type, int pageIndex, int pageSize);
        IList FindPageByNamedQuery(string queryName, object[] values, IType[] types, int pageIndex, int pageSize);
        int CountByNamedQuery(string queryName, object[] values, NHibernate.Type.IType[] types);
        IList FindPageByQuery(string queryText, object[] values, int pageIndex, int pageSize);
    }
}
