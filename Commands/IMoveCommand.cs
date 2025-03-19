using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSimulator.Commands
{
    public interface IMoveCommand
    {
        void Execute();
        void Undo();
        string GetDescription();
    }
}
