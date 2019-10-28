using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CatalogoVendas.Core.Helpers
{
    public static class StringHelper
    {
        public static string RemoveMask(string value)
        {
            return Regex.Replace(value, @"[^\d]", "");
        }

        public static string RemoveRGMask(string rg)
        {
            return Regex.Replace(rg, @"[^\d\w]", "");
        }
    }
}
