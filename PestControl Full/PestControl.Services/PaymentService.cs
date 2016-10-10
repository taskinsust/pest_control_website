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
    public interface IPaymentService : IBaseService
    {
        IList<CardType> GetAllTypes();
        CardType GetCardType(long id);

        void Save(Payment payment);

        IPagedList<PaymentShortDetails> GetAllPayments(int pageIndex, int pageSize);
        IPagedList<ContactShortDetails> GetAllContacts(int pageIndex, int pageSize);
    }

    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IPaymentDao _paymentDao;
        private readonly ISubMenuDao _subMenuDao;

        public PaymentService(ISession session)
        {
            _session = session;
            _paymentDao = new PaymentDao() { Session = _session };
        }

        public IList<CardType> GetAllTypes()
        {
            return _session.QueryOver<CardType>().List();
        }
        public CardType GetCardType(long id)
        {
            return _session.QueryOver<CardType>().Where(x => x.Id == id).SingleOrDefault();
        }
        public void Save(Payment payment)
        {
            _paymentDao.Save(payment);
        }

        public IPagedList<PaymentShortDetails> GetAllPayments(int pageIndex, int pageSize)
        {
            var query = _session.QueryOver<Payment>();
            var total = query.RowCount();

            if (total <= pageSize)
                pageIndex = 0;

            var item = query.OrderBy(x => x.CreationDate).Desc.Skip(pageIndex * pageSize).Take(pageSize).List().Select(x => new PaymentShortDetails 
            {
                Id = x.Id,
                InvoiceNo = x.InvoiceNo.ToString(),
                Name = x.FirstName + " " + x.LastName,
                CardNo = x.CardNo,
                Date = x.CreationDate.ToString("dd-MMMM-yyyy"),
                Amount = x.Amount,
                Email = x.Email
            }).ToList();

            return new PagedList<PaymentShortDetails>(item, pageIndex, pageSize, total);
        }

        public IPagedList<ContactShortDetails> GetAllContacts(int pageIndex, int pageSize)
        {
            var query = _session.QueryOver<Contact>();
            var total = query.RowCount();

            if (total <= pageSize)
                pageIndex = 0;

            var item = query.OrderBy(x => x.CreationDate).Desc.Skip(pageIndex * pageSize).Take(pageSize).List().Select(x => new ContactShortDetails
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.FirstName + " " + x.LastName,
                Phone = x.Phone,
                Schedule = x.Schedual.ToString("yyyy-MM-dd"),
                Message = x.Message,
                IsPending = x.ContactStatus == 0,
                Status = x.ContactStatus
            }).ToList();

            return new PagedList<ContactShortDetails>(item, pageIndex, pageSize, total);
        }
    }
}
