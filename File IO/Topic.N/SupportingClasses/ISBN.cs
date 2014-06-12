using System.Text.RegularExpressions;
using System;
namespace Topic.N.SupportingClasses
{
    public class ISBN
    {
        #region Properties
        private string _BarCode;
        public string BarCode
        {
            get { return _BarCode; }
            set
            {
                ValidateBarCode(value);
                _BarCode = value;
            }
        }
        #endregion

        #region Constructors
        public ISBN(string barCode)
        {
            BarCode = barCode;
        }

        public ISBN()
        {
        }
        #endregion

        #region Private helper methods
        private static void ValidateBarCode(string barCode)
        {
            // check for whitespace or null
            if (string.IsNullOrEmpty(barCode))
                throw new Exception("ISBN barcodes must be 10 or 13 digits");
            if (Regex.IsMatch(barCode, @"\s"))
                throw new Exception("ISBN barcodes cannot contain whitespace");

            // allow dash or a single 'X', but reject all other non-digit characters
            barCode = barCode.ToUpper();
            if (barCode.IndexOf('X') != barCode.LastIndexOf('X'))
                throw new Exception("ISBN barcodes cannot have more than one 'X' character");
            string strippedCharacters = barCode.Replace("-", "").Replace("X", "0");
            if (Regex.IsMatch(strippedCharacters, @"\D"))
                throw new Exception("ISBN barcodes only accept numbers, dashes, and the character X");

            // check for length
            int length = strippedCharacters.Length;
            if (length != 10 && length != 13)
                throw new Exception("ISBN barcodes must be 10 or 13 digits");
        }
        #endregion

        #region Special Overrides for using ISBN in Dictionary<T1,T2> and comparisons
        public override int GetHashCode()
        {
            return BarCode.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ISBN)) return false;
            ISBN other = obj as ISBN;
            return string.Equals(this.BarCode, other.BarCode);
        }

        public static bool operator ==(ISBN a, ISBN b)
        {
            // If both are null, or both are same instance, return true.
            if (object.ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            // Return true if the barcodes match:
            return string.Equals(a.BarCode, b.BarCode);
        }

        public static bool operator !=(ISBN a, ISBN b)
        {
            return !(a == b);
        }
        #endregion
    }
}