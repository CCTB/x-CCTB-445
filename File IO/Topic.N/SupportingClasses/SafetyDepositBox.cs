using System;
namespace Topic.N.SupportingClasses
{
    public class SafetyDepositBox
    {
        private int _BoxNumber;
        public int BoxNumber
        {
            get { return _BoxNumber; }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid box number - box numbers must be positive");
                _BoxNumber = value;
            }
        }
        private int _AccountNumber;
        public int AccountNumber
        {
            get { return _AccountNumber; }
            set
            {
                if (value == 0 || value < NO_ACCOUNT_NUMBER)
                    throw new Exception("Account numbers must be positive");
                _AccountNumber = value;
            }
        }
        public bool IsLeased
        { get { return AccountNumber != NO_ACCOUNT_NUMBER; } }
        public const int NO_ACCOUNT_NUMBER = -1;

        // TODO: Add enumeration for box size

        public SafetyDepositBox(int boxNumber, int accountNumber)
        {
            this.BoxNumber = boxNumber;
            this.AccountNumber = accountNumber;
        }

        public SafetyDepositBox(int boxNumber)
            : this(boxNumber, NO_ACCOUNT_NUMBER)
        {
        }

        public SafetyDepositBox()
            : this(0)
        {
        }

        public void LeaseTo(int accountNumber)
        {
            if (IsLeased)
                throw new Exception("This box is already leased to an account");
            if (accountNumber <= 0)
                throw new Exception("Account numbers must be positive");
            AccountNumber = accountNumber;
        }

        public void RemoveLease(int accountNumber)
        {
            if (accountNumber <= 0)
                throw new Exception("Account numbers must be positive");
            if (accountNumber != this.AccountNumber)
                throw new Exception("Account numbers do not match - lease removal aborted");
            AccountNumber = NO_ACCOUNT_NUMBER;
        }

        public override string ToString()
        {
            return "[" + BoxNumber + "] : " + AccountNumber;
        }
    }
}