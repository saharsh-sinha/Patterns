using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saharsh.Exercises.DesignPatterns.FactoryMethod
{
    public interface ISavingsAccount
    {
        decimal Balance { get; set; }
    }

    // Concrete Product
    public class CitiSavingsAcct : ISavingsAccount
    {
        public CitiSavingsAcct()
        {
            Console.WriteLine("Instantiating Citi Account");
            Balance = 5000;
        }

        public decimal Balance
        {
            get;
            set;
        }
    }

    // Concrete Product
    public class NationalSavingsAcct : ISavingsAccount
    {
        public NationalSavingsAcct()
        {
            Console.WriteLine("Instantiating National Account");
            Balance = 2000;
        }

        public decimal Balance
        {
            get;
            set;
        }
    }

    //this is the factory that returns an actual savings object after analyzing the account number and deciding which class to instantiate
    //if not for this, the caller could have made this decision by looking at the account number itself and deciding which class to instantiate
    //that would of course need to be a type of ISavings account since the actions on the concrete object would need to be defined by the interface
    //the only problem with letting the caller make the decision is that if there's more than one caller, the same decision will need to be made in multiple places
    //and if there are new SavingsAccount types getting added, all the calling locations will need to be updated to make the change. Would be a big time DRY failure. BAD!
    public class AccountsFactory
    {
        public ISavingsAccount GetAccount(string accountNumber)
        {
            Console.WriteLine("Analyzing account number to see which object to instantiate....");

            if (accountNumber.Contains("CITI"))
                return new CitiSavingsAcct();
            else if (accountNumber.Contains("NATIONAL"))
                return new NationalSavingsAcct();
            else
            {
                Console.WriteLine("Account number does not match any account instantiors");
                return null;
            }
        }
    }

}
