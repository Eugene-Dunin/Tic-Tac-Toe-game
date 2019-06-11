using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game.UserInteraction.Factoties
{
    class UserInteractorFactory: AbstractUserInteractorFactory
    {
        public override IUserInteractor GetInstance()
        {
            return UserInteractor.GetInstance();
        }
    }
}
