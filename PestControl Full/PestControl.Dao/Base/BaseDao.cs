using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Type;
using OnnorokomSms.Model.Mapping.Lib;
using PestControl.Model.Entity.Base;

namespace PestControl.Dao.Base
{
    public abstract class BaseDao<TEntityT, TIdT> : IBaseDao<TEntityT, TIdT> where TEntityT : class
    {
        private ISession _session;

        public ISession Session
        {
            get { return _session; }
            set { _session = value; }
        }

        public TEntityT GetById(TIdT id)
        {
            return null;
        }

        public IList LoadByName(string name)
        {
            IList list = new List<TEntityT>();
            Type type = typeof(TEntityT);
            string query = "From " + type.Name + " as e where e.Name = ?";
            list = Find(query, new object[] { name });

            return list;
        }

        public TEntityT LoadSingleByName(string name)
        {
            TEntityT list = default(TEntityT);
            Type type = typeof(TEntityT);
            string query = "From " + type.Name + " as e where e.Name = ?";
            var lists = (ArrayList)Find(query, new object[] { name });
            return (TEntityT)lists[0];
        }

        public ArrayList LoadByNameLike(string name)
        {
            ArrayList list = new ArrayList();
            Type type = typeof(TEntityT);
            string query = "From " + type.Name + " as e where e.Name like ?";
            list = (ArrayList)Find(query, new object[] { "%" + name + "%" });
            return list;
        }

        public virtual IList LoadByQuery(string query)
        {
            return Find(query);

        }

        public virtual object Save(TEntityT data)
        {
            IBaseEntity entity = (IBaseEntity)data;
            if (entity.CreationDate.Year < Constants.FIRST_BUSSINESS_YEAR)
                entity.CreationDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;
             _session.Save(data);
             _session.Clear();

             return data;
        }

        public virtual void Delete(TEntityT data)
        {
            IBaseEntity entity = (IBaseEntity)data;
            entity.ModificationDate = DateTime.Now;

            using (var trans = _session.BeginTransaction())
            {
                _session.Delete(data);
                trans.Commit();
            }
        }

        public void DeleteEntity(TIdT id)
        {
            var e = (TEntityT)_session.Get(typeof(TEntityT), id);
            _session.Delete(e);
        }


        public virtual void Update(TEntityT data)
        {
            IBaseEntity entity = (IBaseEntity)data;
            if (entity.CreationDate.Year < Constants.FIRST_BUSSINESS_YEAR)
                entity.CreationDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;

            using(var trans = _session.BeginTransaction()){
                _session.Update(data);
                trans.Commit();
            }
            
            
        }

        public void Marge(TEntityT data)
        {
            IBaseEntity entity = (IBaseEntity)data;
            if (entity.CreationDate.Year < Constants.FIRST_BUSSINESS_YEAR)
                entity.CreationDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;

            _session.Merge(data);
        }

        public virtual IList LoadAll()
        {
            Type type = typeof(TEntityT);
            string queryTxt = string.Format(@"From {0} as entity ", type);
            IQuery query = _session.CreateQuery(queryTxt);
            return query.List();
        }

        public virtual ArrayList LoadAllOk()
        {
            ArrayList list = new ArrayList();
            Type type = typeof(TEntityT);
            string query = "From " + type.Name + " as e where e.Status != ?";
            list = (ArrayList)Find(query, new object[] { Constants.STATUS_DELETED });
            return list;
        }

        public virtual object LoadById(TIdT id)
        {
            ArrayList list = new ArrayList();
            Type type = typeof(TEntityT);
            string query = "From " + type.Name + " as e where e.Id = ? and e.Status != ?";
            list = (ArrayList)Find(query, new object[] { id, Constants.STATUS_DELETED });

            if (list.Count == 0)
                return null;
            else
            {
                return list[0];
            }

        }

        public virtual void SaveOrUpdate(TEntityT data)
        {
            _session.SaveOrUpdate(data);
        }

        public IList Find(string queryTxt)
        {
            IQuery query = _session.CreateQuery(queryTxt);
            return query.List();

        }

        public IList Find(string queryTxt, object[] value)
        {
            IQuery query = _session.CreateQuery(queryTxt);
            for (int i = 0; i < value.Length; i++)
            {
                query.SetParameter(i, value[i]);
            }
            return query.List();
        }

        public IList FindByNamedQuery(string namedQuery)
        {
            IQuery query = _session.GetNamedQuery(namedQuery);
            return query.List();
        }

        public IList FindByNamedQueryAndParam(string namedQuery, object[] value)
        {
            IQuery query = _session.GetNamedQuery(namedQuery);

            if ((null != value))
            {
                for (int i = 0; i < value.Length; i++)
                {
                    query.SetParameter(i, value[i]);
                }
            }

            return query.List();
        }

        public ArrayList SearchByFieldAndKey(string searchBy, string key)
        {
            Type type = typeof(TEntityT);
            string query = string.Format(@"From {0} as entity where entity.{1} like ? and entity.Status !=?", type.Name, searchBy);
            return (ArrayList)Find(query, new object[] { key + "%", Constants.STATUS_DELETED });

        }

        public ArrayList SearchByFieldAndValue(string searchBy, object value)
        {
            Type type = typeof(TEntityT);
            string query = string.Format(@"From {0} as entity where entity.{1} = ? and entity.Status !=?", type.Name, searchBy);
            return (ArrayList)Find(query, new object[] { value, Constants.STATUS_DELETED });
        }

        public ArrayList SearchByFieldAndLikeValue(string searchBy, object value)
        {
            Type type = typeof(TEntityT);
            //PropertyInfo[] properties = type.GetProperties();

            //PropertyInfo property = GetPropertyInfoByName(properties, searchBy);

            //if (property == null)
            //    return new ArrayList(); 
            //This is code is commented at date 18/09/2011. for this change please check then remove  
            string query;

            if (value is string)
            {
                query = string.Format(@"From {0} as entity where entity.{1} like ? and entity.Status !=?", type.Name, searchBy);
                return (ArrayList)Find(query, new object[] { value + "%", Constants.STATUS_DELETED });
            }
            else
            {
                query = string.Format(@"From {0} as entity where entity.{1} = ? and entity.Status !=?", type.Name, searchBy);
                return (ArrayList)Find(query, new object[] { value, Constants.STATUS_DELETED });
            }

        }

        public ArrayList SearchBySubFieldAndValue(string searchBy, object value)
        {
            Type type = typeof(TEntityT);
            string query;
            query = string.Format(@"From {0} as entity where entity.{1} = ? and entity.Status !=?", type.Name, searchBy);
            return (ArrayList)Find(query, new object[] { value, Constants.STATUS_DELETED });

        }

        private PropertyInfo GetPropertyInfoByName(PropertyInfo[] properties, string searchBy)
        {
            foreach (PropertyInfo p in properties)
            {
                if (p.Name == searchBy)
                    return p;
            }
            return null;
        }

        /// <summary>
        /// Search entity using multiple field and multiple AND or Conditions. 
        /// </summary>
        /// <param name="searchBy">Array of multiple fileds name</param>
        /// <param name="value">Corrosponding value array of fields </param>
        /// <param name="andOrOperator"> Corrosping conditional operator.
        /// Like Name='masum' AND age >= 28 OR address LIKE mohammad. 
        /// string[] operators is the array of corrosponding =,>=,!=, like,... etc 
        /// string[] conditionalAndOrOperator is the corrosponding AND,OR, !,  conditional operator array.</param>
        /// <returns>List of matched entity object</returns>
        public ArrayList SearchByFieldsAndValues(string[] searchBy, object[] values, string[] operators, string[] conditionalAndOrOperator)
        {

            Type type = typeof(TEntityT);

            string query;
            string conditions = "";

            if (searchBy.Length > 0)
            {
                int i = 0;
                for (; i < searchBy.Length - 1; i++)
                {
                    if (operators[i].ToLower() == "like")
                    {
                        values[i] += "%";
                    }

                    conditions += string.Format("entity.{0} {1} ? {2} ", searchBy[i], operators[i], conditionalAndOrOperator[i]);
                }

                conditions += string.Format("entity.{0} {1} ? ", searchBy[i], operators[i]);

                query = string.Format(@"From {0} as entity where {1} and entity.Status !=?", type.Name, conditions);
                object[] val = new object[values.Length + 1];

                int j = 0;
                for (; j < values.Length; j++)
                {
                    val[j] = values[j];
                }

                val[j] = (object)Constants.STATUS_DELETED;

                return (ArrayList)Find(query, val);
            }
            return new ArrayList();

        }

        private FieldInfo GetFieldInfoByName(FieldInfo[] properties, string searchBy)
        {
            foreach (FieldInfo field in properties)
            {
                if (field.Name == searchBy)
                    return field;
            }
            return null;
        }

        public virtual int DeleteByNamedQuery(string queryName, object value, IType type)
        {
            object[] values = new object[] { value };
            IType[] types = new IType[] { type };
            return DeleteByNamedQuery(queryName, values, types);
        }

        public virtual int DeleteByNamedQuery(string queryName, object[] values, IType[] types)
        {
            IQuery query = _session.GetNamedQuery(queryName);

            return _session.Delete(query.QueryString, values, types);
        }


        public virtual IList FindByNamedQuery(string queryName, object value, IType type)
        {
            object[] values = new object[] { value };
            IType[] types = new IType[] { type };
            return FindByNamedQuery(queryName, values, types);
        }
        public virtual IList FindByNamedQuery(string queryName, object[] values, IType[] types)
        {
            IQuery query = _session.GetNamedQuery(queryName);

            if ((null != values) && (null != types))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    query.SetParameter(i, values[i], types[i]);
                }
            }

            return query.List();
        }

        public virtual IList FindPage(string queryString, int pageIndex, int pageSize)
        {
            IQuery query = _session.CreateQuery(queryString);

            query.SetFirstResult(pageSize * pageIndex);
            query.SetMaxResults(pageSize);

            return query.List();
        }

        public virtual IList FindPageByNamedQuery(string queryName, int pageIndex, int pageSize)
        {
            return FindPageByNamedQuery(queryName, null, null, pageIndex, pageSize);
        }

        public IList FindPageByNamedQuery(string queryName, object value, IType type, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IList FindPageByNamedQuery(string queryName, object[] values, IType[] types, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        /*public virtual IList FindPageByNamedQuery( string queryName, object value, IType type, int pageIndex, int pageSize )
        {
            object[] values = new object[] { value };
            IType[] types = new IType[] { type };
            return FindPageByNamedQuery( queryName, values, types, pageIndex, pageSize );
        }*/

        /*public virtual IList FindPageByNamedQuery( string queryName, object[] values, IType[] types, int pageIndex, int pageSize )
        {
            IQuery query = _session.GetNamedQuery(queryName);

            if ( ( null != values ) && ( null != types ) )
            {
                for ( int i = 0; i < values.Length; i++ )
                {
                    query.SetParameter( i, values[i], types[i] );
                }
            }

            query.SetFirstResult( pageSize * pageIndex );
            query.SetMaxResults( pageSize );
            return query.List();
        }*/

        public virtual IList FindPageByQuery(string queryText, object[] values, int pageIndex, int pageSize)
        {

            IQuery query = _session.CreateQuery(queryText);
            if ((null != values))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    query.SetParameter(i, values[i]);
                }
            }
            query.SetFirstResult(pageSize * pageIndex);
            query.SetMaxResults(pageSize);
            return query.List();
        }

        public virtual IList FindPageByQuery(string queryText, object[] values, IType[] types, int pageIndex, int pageSize)
        {
            IQuery query = _session.CreateQuery(queryText);
            if ((null != values))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    query.SetParameter(i, values[i], types[i]);
                }
            }
            query.SetFirstResult(pageSize * pageIndex);
            query.SetMaxResults(pageSize);
            return query.List();
        }

        public virtual int CountByNamedQuery(string queryName, object[] values, NHibernate.Type.IType[] types)
        {
            IQuery query = _session.GetNamedQuery(queryName);

            if ((null != values) && (null != types))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    query.SetParameter(i, values[i], types[i]);
                }
            }

            return (int)query.UniqueResult();
        }

    }
}
