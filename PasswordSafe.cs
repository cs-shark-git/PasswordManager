using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasswordManager
{
    class PasswordSafe
    {
        public enum SafePower
        {
            Excelent = 3,
            Good = 2,
            Normal = 1,
            Bad = 0
        }

        private const int MIN_LETTERS_VALUE = 4;
        private const string SPECIAL_SYMBOLS = "~!@#$%^&*-+='|\\() {} []:;\"\' <>,.? /;";
        private const int RECOMENDED_MIN_LENGTH = 12;

        private string password;
        public PasswordSafe(string password)
        {
            this.password = password;
        }

        public SafePower LengthPasswordCheck()
        {
            if (password.Length >= RECOMENDED_MIN_LENGTH)
            {
                return SafePower.Excelent;
            }
            else if (password.Length >= RECOMENDED_MIN_LENGTH - 2)
            {
                return SafePower.Good;
            }
            else if (password.Length >= RECOMENDED_MIN_LENGTH - 6)
            {
                return SafePower.Normal;
            }
            else
            {
                return SafePower.Bad;
            }
        }

        public SafePower NumCountCheck()
        {
            int numCount = 0;
            foreach (char chr in password)
            {
                if (Char.IsNumber(chr))
                {
                    numCount += 1;
                }
            }

            if (numCount < 5)
            {
                return SafePower.Good;
            }
            else if (numCount >= 10)
            {
                return SafePower.Excelent;
            }
            else
            {
                return SafePower.Normal;
            }
        }

        public SafePower SpecialSymbolCheck()
        {
            foreach (char chr in password)
            {
                if (SPECIAL_SYMBOLS.Contains(chr))
                {
                    return SafePower.Excelent;
                }
            }
            return SafePower.Normal;
        }

        public SafePower LettersCheck()
        {
            int sum = 0;
            foreach (char chr in password)
            {
                if (Char.IsLetter(chr))
                {
                    sum += 1;
                }
            }

            if (sum >= MIN_LETTERS_VALUE)
            {
                return SafePower.Normal;
            }
            else
            {
                return SafePower.Bad;
            }

        }

        public SafePower CapitalizeCheck()
        {
            foreach (char chr in password)
            {
                if (Char.IsUpper(chr))
                {
                    return SafePower.Good;
                }
            }
            return SafePower.Normal;
        }

        public SafePower CheckAll()
        {
            List<SafePower> results = new List<SafePower>();
            results.Add(LengthPasswordCheck());
            results.Add(NumCountCheck());
            results.Add(SpecialSymbolCheck());
            results.Add(LettersCheck());
            results.Add(CapitalizeCheck());
            int sum = 0;
            foreach (int value in results)
            {
                if(value == 0)
                {
                    return SafePower.Bad;
                }
                sum += value;
            }


            if (sum == 12)
            {
                return SafePower.Excelent;
            }
            if (sum >= 10)
            {
                return SafePower.Good;
            }
            else if (sum >= 4)
            {
                return SafePower.Normal;
            }
            else
            {
                return SafePower.Bad;
            }

        }
    }
}
