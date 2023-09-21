using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 金幣管理器
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        private TextMeshProUGUI textCoin;
        private int coinCurrent;
        private int coinTotal = 10;

        private void Awake()
        {
            textCoin= GameObject.Find("金幣數量").GetComponent<TextMeshProUGUI>();
            textCoin.text = $"金幣數量：{coinCurrent} / {coinTotal}";
        }
    }
}
