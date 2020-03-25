using System;
using System.Collections.Generic;
using System.Text;

namespace SI_CSP.Models
{
    interface ICache<TContent>
    {
        
        TContent this[int xKey, int yKey] { get; set; }

    }
}
