using System;
using System.Collections.Generic;
using System.Text;

namespace Demos
{
    class ListResult<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<T> results { get; set; }
    }

}
