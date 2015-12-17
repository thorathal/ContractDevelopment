using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace contractbycode
{
    [ContractClass(typeof(IAccountContract))]
    public interface IAccount
    {
        // The accounts balance.
        // The balance is expected to be positive in the end of all methods.
        double Balance
        {
            get;
        }

        // Method to withdraw money from the account.
        // the parameter amount has to be positive.
        void withdraw(double amount);

        // Method to deposit money to the account.
        // the parameter amount has to be positive.
        void deposit(double amount);
    }


    [ContractClassFor(typeof(IAccount))]
    internal class IAccountContract : IAccount
    {

        // Required variable
        double IAccount.Balance
        {
            get
            {
                Contract.Requires(((IAccount)this).Balance >= 0.0);
                return default(double);
            }
        }

        // Required method to deposit money into the account
        // Parameter amount is the money deposited to the account. Amount should be positive.
        void IAccount.deposit(double amount)
        {
            Contract.Requires<ArgumentException>(amount >= 0.0);
            //this.balance += amount;
            Contract.Ensures(
                Contract.Result<double>() - amount == ((IAccount)this).Balance
                );
        }

        // Required method to withdraw money from the account
        // It shouldn't be posible to overdraw the account.
        // Parameter amount is the money withdrawn from the account. Amount should be positive.
        void IAccount.withdraw(double amount)
        {
            Contract.Requires<ArgumentException>(amount >= 0.0);
            Contract.Assert(((IAccount)this).Balance - amount >= 0.0);
            //this.balance -= amount;
            Contract.Ensures(
                Contract.Result<double>() + amount == ((IAccount)this).Balance
                );
        }

        // Invariance is checked in every method.
        [ContractInvariantMethod]
        protected void ObjectInvariant()
        {
            Contract.Invariant(((IAccount)this).Balance >= 0.0);
        }
    }

}
