using UnityEngine;

namespace KID.TwoD
{

    public class StateAttack : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}
