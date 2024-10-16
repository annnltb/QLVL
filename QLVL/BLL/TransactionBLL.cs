using QLVL.DAL;
using QLVL.Entity;
using System.Collections.Generic;

namespace QLVL.BLL
{
    public class TransactionBLL
    {
        private readonly TransactionDAL transactionDAL;

        public TransactionBLL(string connectionString)
        {
            transactionDAL = new TransactionDAL(connectionString);
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactionDAL.GetAllTransactions();
        }

        public void AddTransaction(Transaction transaction)
        {
            transactionDAL.AddTransaction(transaction);
        }

        // Các phương thức khác như Update và Delete có thể thêm vào tương tự
    }
}
