using System.Data;

namespace UnikOpstart.Services.MedarbejderKompetencer.Crosscut.TransactionHandling
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void BeginTransaction(IsolationLevel isolationLevel);
    }
}
