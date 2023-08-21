using UnityEngine;

namespace KID.TwoD
{

    public class StateAttack : State
    {
        [SerializeField, Header("檢查是否擊中時間"), Range(0, 5)]
        private float attackCheckHitTime = 2.5f;
        [SerializeField, Header("攻擊結束時間"), Range(0, 5)]
        private float attackFinishTime = 4;
        [SerializeField, Header("追蹤狀態")]
        private StateTrack stateTrack;

        private string parAttack = "觸發攻擊";
        private float timer;

        public override State RunCurrentState()
        {
            if (timer == 0)
            {
                ani.SetTrigger(parAttack);
            }
            else
            {
                if (timer >= attackCheckHitTime && timer < attackCheckHitTime + Time.deltaTime)
                {
                    print("<color=#f69>檢查是否擊中</color>");
                    print(stateTrack.AttackTarget());
                }
                else if (timer >= attackFinishTime)
                {
                    print("<color=#f96>攻擊結束!</color>");
                    timer = 0;
                    return stateTrack;
                }
            }

            timer += Time.deltaTime;

            return this;
        }
    }
}
