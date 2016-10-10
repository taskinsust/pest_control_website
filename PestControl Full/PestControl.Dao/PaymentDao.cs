using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Dao.Base;
using PestControl.Model.Entity;

namespace PestControl.Dao
{
    public interface IPaymentDao : IBaseDao<Payment, long>
    {

    }

    public class PaymentDao : BaseDao<Payment, long>, IPaymentDao
    {

    }
}
