﻿using UnityEngine;

namespace KID.TwoD
{
    /// <summary>
    /// 攻擊狀態：攻擊完成後回到追蹤狀態
    /// </summary>
    public class StateAttack : State
    {
        [SerializeField, Header("送出攻擊檢測的時間點"), Range(0, 5)]
        private float timeSendAttackCheck = 0.5f;
        [SerializeField, Header("攻擊結束的時間點"), Range(0, 5)]
        private float timeAttackEnd = 1.5f;
        [SerializeField, Header("追蹤狀態")]
        private StateTrack stateTrack;

        private string parAttack = "觸發攻擊";
        private float timer;
        private bool canSendAttack = true;
        private DamageSystem damageSystem;

        private void Start()
        {
            damageSystem = GameObject.Find("太空員").GetComponent<DamageSystem>();
        }

        public override State RunCurrentState()
        {
            if (timer == 0)
            {
                ani.SetTrigger(parAttack);
            }
            else
            {
                if (timer >= timeSendAttackCheck && canSendAttack)
                {
                    canSendAttack = false;
                    if (stateTrack.AttackTarget())
                    {
                        print("<color=#69f>擊中玩家!</color>");
                        damageSystem.Damage(30);
                    }
                }
                else if (timer >= timeAttackEnd)
                {
                    canSendAttack = true;
                    timer = 0;
                    return stateTrack;
                }
            }

            timer += Time.deltaTime;

            return this;
        }
    }
}
