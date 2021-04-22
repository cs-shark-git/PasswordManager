using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.ErrorsMessages;

namespace PasswordManager
{
    class Password
    {
        public const int MAX_PASSWORD_LENGTH = 100;
        public const int MIN_PASSWORD_LENGTH = 4;

        private string name = "None";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length > MAX_PASSWORD_LENGTH && value.Length < MIN_PASSWORD_LENGTH)
                {
                    name = value;
                }
                else
                {
                    throw new Exception(PasswordErrorsMessages.PASSWORD_LENGTH_FORMRAT_ERROR);
                }

            }
        }
    }
}
