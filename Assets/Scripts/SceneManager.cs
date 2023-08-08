using UnityEngine;

namespace KID
{
    /// <summary>
    /// 場景管理器：切換場景與退出遊戲
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        [SerializeField, Range(0.3f, 3), Header("音效時間")]
        private float soundDuration = 2.2f;

        // 按鈕與程式溝通的方式
        // 1. 定義公開方法
        // 2. 此腳本掛在遊戲物件上
        // 3. 按鈕上設定 On Click 事件

        /// <summary>
        /// 透過字串切換場景
        /// </summary>
        /// <param name="nameScene">場景名稱</param>
        public void ChangeScene(string nameScene)
        {
            // print("切換場景");
            UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
        }

        /// <summary>
        /// 退出遊戲
        /// </summary>
        public void Quit()
        {
            Invoke("DelayQuit", soundDuration);
        }

        private void DelayQuit()
        {
            print("退出遊戲");
            Application.Quit();
        }
    }
}
