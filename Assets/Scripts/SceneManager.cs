using UnityEngine;

namespace KID
{
    /// <summary>
    /// �����޲z���G���������P�h�X�C��
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        [SerializeField, Range(0.3f, 3), Header("���Įɶ�")]
        private float soundDuration = 2.2f;

        // ���s�P�{�����q���覡
        // 1. �w�q���}��k
        // 2. ���}�����b�C������W
        // 3. ���s�W�]�w On Click �ƥ�

        /// <summary>
        /// �z�L�r���������
        /// </summary>
        /// <param name="nameScene">�����W��</param>
        public void ChangeScene(string nameScene)
        {
            // print("��������");
            UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
        }

        /// <summary>
        /// �h�X�C��
        /// </summary>
        public void Quit()
        {
            Invoke("DelayQuit", soundDuration);
        }

        private void DelayQuit()
        {
            print("�h�X�C��");
            Application.Quit();
        }
    }
}
