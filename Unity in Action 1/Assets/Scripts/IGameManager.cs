using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IGameManager
    {
        ManagerStatus status { get; }
        void Startup(NetworkService service);
    }
}
