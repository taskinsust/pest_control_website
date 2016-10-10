using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PestControl.Dao;
using PestControl.Model.Entity;
using PestControl.Services.Base;
using PestControl.Core;
using PestControl.Services.Models;

namespace PestControl.Services
{
    public interface IContactService : IBaseService
    {
        void Save(Contact entity);
        bool ChangeContactStatus(Contact contactObj, int status);
        Contact GetContact(long Id);
        bool ConfirmContactRequest(Contact contactObj, int status);

        bool UpdateContact(Contact contact);
    }

    public class ContactService : BaseService, IContactService
    {
        private readonly IContactDao _contactDao;
        private readonly ISubMenuDao _subMenuDao;

        public ContactService(ISession session)
        {
            _session = session;
            _contactDao = new ContactDao() { Session = session };
        }

        public void Save(Contact entity)
        {
            if (entity.Id > 0)
            {
                _session.Update(entity);
            }
            else
            {
                _session.Save(entity);
            }
        }
        public bool UpdateContact(Contact newObj)
        {
            using (var trans = _session.BeginTransaction())
            {
                try
                {
                    var contactObj = GetContact(newObj.Id);
                    contactObj.FirstName = newObj.FirstName;
                    contactObj.LastName = newObj.LastName;
                    contactObj.Email = newObj.Email;
                    contactObj.Phone = newObj.Phone;
                    contactObj.Address = newObj.Address;
                    contactObj.State = newObj.State;
                    contactObj.Message = newObj.Message;
                    contactObj.ContactStatus= newObj.ContactStatus;
                    contactObj.ZipCode = newObj.ZipCode;
                    contactObj.Schedual = newObj.Schedual;
                    _session.Update(contactObj);
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return false;
                }

            }
        }
        public Contact GetContact(long Id)
        {
            return (Contact)_session.QueryOver<Contact>().Where(x => x.Id == Id).SingleOrDefault();
        }

        public bool ChangeContactStatus(Contact contactObj, int status)
        {
            using (var trans = _session.BeginTransaction())
            {
                try
                {
                    contactObj.ContactStatus = status;
                    _session.Update(contactObj);
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool ConfirmContactRequest(Contact contactObj, int status)
        {
            using (var trans = _session.BeginTransaction())
            {
                try
                {
                    contactObj.ContactStatus = status;
                    _session.Update(contactObj);
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}
