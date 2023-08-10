using UnityEngine;

namespace KID.TwoD
{
    /// <summary>
    /// 2D 橫向卷軸的控制系統：移動、跳躍與動畫
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("移動速度"), Range(0, 50)]
        private float moveSpeed = 3.5f;
        [SerializeField, Header("檢查地板尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;
        [SerializeField, Header("檢查地板位移")]
        private Vector3 v3CheckGroundOffset = Vector3.zero;
        [SerializeField, Header("要偵測地板的圖層")]
        private LayerMask layerCheckGround;
        [SerializeField, Header("跳躍力道"), Range(0, 3000)]
        private float jumpPower = 1000;

        private Rigidbody2D rig;
        private Animator ani;
        private string parRun = "開關跑步";
        private string parJump = "開關跳躍";
        #endregion

        #region 事件
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
        }

        private void Awake()
        {
            rig = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        private void Start()
        {

        }

        private void Update()
        {
            MoveAndFlip();
            Jump();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 移動與翻面
        /// </summary>
        private void MoveAndFlip()
        {
            float h = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(h * moveSpeed, rig.velocity.y);

            // if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            if (h < 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            // else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            else if (h > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            ani.SetBool(parRun, h != 0);
        }

        /// <summary>
        /// 判定是否在地面 並且 按空白建跳躍
        /// </summary>
        private void Jump()
        {
            if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector2(0, jumpPower));
            }
        }

        /// <summary>
        /// 檢查角色是否在地板
        /// </summary>
        /// <returns>是否在地版上</returns>
        private bool CheckGround()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, layerCheckGround);

            ani.SetBool(parJump, !hit);
            return hit;
        } 
        #endregion
    }
}
