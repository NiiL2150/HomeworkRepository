using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SampleClasses1.Interfaces
{
    public interface IManaging
    {
        List<IWorking> Workers { get; set; }
        void Manage();
        void Organise();
        void Control();
    }
}
