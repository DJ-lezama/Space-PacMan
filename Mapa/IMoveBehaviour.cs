using PacMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    public interface IMoveBehaviour
    {
        void Move(Ghost ghost, Map map);
    }
}
