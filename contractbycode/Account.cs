using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace contractbycode
{
    class Account
    {
        private double balance;

        public Account(int balance)
        {
            this.balance = balance;
        }

        // Required variable
        public double Balance
        {
            get
            {
                Contract.Requires(Balance >= 0.0);
                return this.balance; ;
            }
        }
        
        // Required method to deposit money into the account
        // Parameter amount is the money deposited to the account. Amount should be positive.
        public void deposit(double amount)
        {
            Contract.Requires<ArgumentException>(amount >= 0.0);
            this.balance += amount;
            Contract.Ensures(
                Contract.Result<double>() - amount == this.balance
                );
        }

        // Required method to withdraw money from the account
        // It shouldn't be posible to overdraw the account.
        // Parameter amount is the money withdrawn from the account. Amount should be positive.
        public void withdraw(double amount)
        {
            Contract.Requires<ArgumentException>(amount >= 0.0);
            Contract.Assert(this.balance - amount >= 0.0);
            this.balance -= amount;
            Contract.Ensures(
                Contract.Result<double>() + amount == this.balance
                );
        }

        // Invariance is checked in every method.
        [ContractInvariantMethod]
        protected void ObjectInvariant()
        {
            Contract.Invariant(this.balance >= 0.0);
        }
    }
}