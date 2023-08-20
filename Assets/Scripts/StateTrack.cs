using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace KID.TwoD
{

    public class StateTrack : State
    {
        [SerializeField, Header("遊走狀態")]
        private StateWander stateWander;
        [SerializeField, Header("追蹤速度"), Range(0, 5)]
        private float speed = 3.5f;

        [Header("追蹤大小與位移")]
        [SerializeField]
        private Vector3 attackSize = Vector3.one;
        [SerializeField]
        private Vector3 attackOffset;
        [SerializeField]
        private LayerMask attackLayer;
        [SerializeField, Header("攻擊狀態")]
        private StateAttack stateAttack;

        private Rigidbody2D rig;
        private Transform target;
        private string nameTarget = "太空員";
        private string parWalk = "開關走路";

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(transform.position + transform.TransformDirection(attackOffset), attackSize);
        }

        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            target = GameObject.Find(nameTarget).transform;
        }

        public override State RunCurrentState()
        {
            if (stateWander.TrackTarget())
            {
                if (!AttackTarget())
                {
                    ani.SetBool(parWalk, true);
                    rig.velocity = new Vector2(speed * stateWander.direction, rig.velocity.y);
                    return this;
                }
                else
                {
                    ani.SetBool(parWalk, false);
                    rig.velocity = Vector3.zero;
                    return stateAttack;
                }
            }
            else
            {
                return stateWander;
            }
        }

        public bool AttackTarget()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(attackOffset), attackSize, 0, attackLayer);
            return hit;
        }
    }
}
