using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface ITask
    {
        string Name { get; }

        string Description { get; }

        void RunTask();

    }
}
