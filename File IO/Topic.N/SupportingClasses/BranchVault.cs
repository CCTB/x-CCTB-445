namespace Topic.N.SupportingClasses
{
    public class BranchVault
    {
        #region Properties
        private SafetyDepositBox[] DepositBoxes { get; set; }
        public int BoxCount { get { return DepositBoxes.Length; } }
        public int EmptyBoxCount
        {
            get
            {
                int count = 0;
                foreach (SafetyDepositBox b in DepositBoxes)
                    if (!b.IsLeased)
                        count++;
                return count;
            }
        }
        #endregion

        #region Indexer
        // this is an example of a read-only "indexer"
        public SafetyDepositBox this[int index] { get { return DepositBoxes[index]; } }
        #endregion

        #region Constructors
        public BranchVault(SafetyDepositBox[] depositBoxes)
        {
            if (depositBoxes == null)
                throw new System.Exception("DepositBoxes cannot be null");
            foreach (SafetyDepositBox b in depositBoxes)
                if (b == null)
                    throw new System.Exception(
                            "Null elements are not allowed in the array of safety deposit boxes");
            DepositBoxes = depositBoxes;
            System.Array.Sort<SafetyDepositBox>(DepositBoxes, CompareBoxNumber);
        }
        #endregion

        #region Private Methods (for Sorting)
        private static int CompareBoxNumber(SafetyDepositBox firstBox, SafetyDepositBox secondBox)
        {
            return firstBox.BoxNumber.CompareTo(secondBox.BoxNumber);
        }
        #endregion

        #region Public Methods
        public SafetyDepositBox Find(int boxNumber)
        {
            SafetyDepositBox foundBox = System.Array.Find<SafetyDepositBox>(DepositBoxes, box => box.BoxNumber == boxNumber);
            // --- The following block of code is how a "binary search" can be manually implemented ---
            // ---     (binary searches are only possible on sorted arrays)
            /* 
            int startPosition = 0;
            int endPosition = DepositBoxes.Length - 1;
            bool found = false;
            int midPosition = -1;
            while (startPosition <= endPosition && !found)
            {
                midPosition = (startPosition + endPosition) / 2;
                if (DepositBoxes[midPosition].BoxNumber < boxNumber)
                {
                    startPosition = midPosition + 1;
                }
                else
                {
                    if (DepositBoxes[midPosition].BoxNumber > boxNumber)
                    {
                        endPosition = midPosition - 1;
                    }
                    else
                    {
                        found = true;
                    }
                }
            }
            if (found)
                foundBox = DepositBoxes[midPosition];
            */
            // ---------------------------------------------------------------------------
            return foundBox;
        }
        #endregion
    }
}