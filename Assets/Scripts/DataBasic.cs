using UnityEngine;

namespace KID
{
    /// <summary>
    /// 基本資料：血量
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Baisc", fileName = "Data Basic")]
    public class DataBasic : ScriptableObject
    {
        [Header("血量"), Range(0, 1500)]
        public float hp = 100;
        [Header("攻擊力"), Range(0, 1000)]
        public float attack = 30;
    }
}
