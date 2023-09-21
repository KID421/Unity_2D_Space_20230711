using Cinemachine;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 玩家碰撞管理器
    /// </summary>
    public class PlayerHitManager : MonoBehaviour
    {
        [SerializeField, Header("教學物件")]
        private GameObject goTeach;

        private CinemachineImpulseSource impulseSource;

        private bool firstHitGround;

        private void Awake()
        {
            impulseSource = FindObjectOfType<CinemachineImpulseSource>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!firstHitGround)
            {
                goTeach.SetActive(true);
                firstHitGround = true;
                impulseSource.GenerateImpulse();
            }
        }
    }
}
