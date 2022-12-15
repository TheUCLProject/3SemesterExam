using System.Data;

namespace UnikOpstart.Services.Booking.Crosscut.TransactionHandling
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void BeginTransaction(IsolationLevel isolationLevel);
    }
}
