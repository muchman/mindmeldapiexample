using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindMeldApi
{
    public class ControllerResult<T>
    {
        public T data { get; set; }
        public ControllerResult(T data)
        {
            this.data = data;
        }
    }
}
