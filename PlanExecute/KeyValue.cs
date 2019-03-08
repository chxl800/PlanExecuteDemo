using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanExecute
{
    public class KeyValue<Tk, Tv>
    {
        public Tk Key { set; get; }

        public Tv Value { set; get; }
    }
}