using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio
{
    public enum ItemStatus
    {
        Borrowed,
        Returned
    }

    public interface ILoanItem
    {
        public string id { get; set; }
        public ItemStatus status { get; set; }

    }
}
