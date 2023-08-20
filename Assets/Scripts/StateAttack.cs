using UnityEngine;

namespace KID.TwoD
{

    public class StateAttack : State
    {
        [SerializeField, Header("攻擊間隔"), Range(0, 5)]
        private float attackInterval = 3;

        private string parAttack = "觸發攻擊";
        private float timer;

        private void Start()
        {
            timer = attackInterval;
        }

        public override State RunCurrentState()
        {
            if (timer >= attackInterval)
            {
                timer = 0;
                ani.SetTrigger(parAttack);
            }
            else
            {
                timer += Time.deltaTime;
            }

            return this;
        }
    }
}
