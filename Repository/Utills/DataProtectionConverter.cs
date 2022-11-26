using Contracts.Utils;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Utills
{
    public class DataProtectionConverter : ValueConverter<string, string>
    {
        
        public DataProtectionConverter()
            : base(_convertTo, _convertFrom, default)
        {
        }

        static Expression<Func<string, string>> _convertTo = x => LockView(x);
        static Expression<Func<string, string>> _convertFrom = x => UnLockView(x);

        static string LockView(string texto)
        {
            return Cript.EncryptString(texto);
        }

        static string UnLockView(string texto)
        {
            return Cript.DecryptString(texto);
        }

    }

}

