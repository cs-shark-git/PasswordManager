using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Serialize
{
    class PasswordSerialize
    {
        private IPasswordSerialize serialize;
        PasswordSerialize(IPasswordSerialize serialize)
        {
            this.serialize = serialize;
        }

        void Serialize()
        {
            //  serialize.Foo()
        }
    }
}
