using UnityEngine;

namespace KID.TwoD
{
    /// <summary>
    /// 開槍系統
    /// </summary>
    public class FireSystem : MonoBehaviour
    {
        [SerializeField, Header("子彈預製物")]
        private GameObject prefabBullet;
        [SerializeField, Header("生成子彈位置")]
        private Transform pointBullet;
        [SerializeField, Header("發射子彈力道"), Range(0, 5000)]
        private float powerBullet = 1000;

        private Animator ani;
        private string parFire = "觸發開槍";

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            Fire();
        }

        /// <summary>
        /// 開槍
        /// </summary>
        private void Fire()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ani.SetTrigger(parFire);
                GameObject tempBullet = Instantiate(prefabBullet, pointBullet.position, transform.rotation);
                tempBullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * powerBullet);

                AudioClip sound = SoundManager.instance.soundFire;
                SoundManager.instance.PlaySound(sound, 0.7f, 1.7f);
            }
        }
    }
}
