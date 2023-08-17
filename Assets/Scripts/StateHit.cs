using UnityEngine;

namespace KID.TwoD
{

    public class StateHit : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}
