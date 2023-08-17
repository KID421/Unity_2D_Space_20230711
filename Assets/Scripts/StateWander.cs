using UnityEngine;

namespace KID.TwoD
{

    public class StateWander : State
    {
        private string parWalk = "開關走路";
        private Rigidbody2D rig;

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }

        public override State RunCurrentState()
        {
            ani.SetBool(parWalk, true);

            return this;
        }
    }
}
