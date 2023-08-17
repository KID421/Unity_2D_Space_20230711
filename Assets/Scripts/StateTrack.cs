using UnityEngine;

namespace KID.TwoD
{

    public class StateTrack : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}
