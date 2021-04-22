using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Import
{
    class PasswordImport
    {
        private IPasswordImport serialize;
        PasswordImport(IPasswordImport serialize)
        {
            this.serialize = serialize;
        }

        void Import()
        {
            //  serialize.Foo()
        }
    }
}
