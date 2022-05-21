using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface ILesson
    {
        int Id { get; }

        string Name { get; }

        void RunLesson();
    }
}
