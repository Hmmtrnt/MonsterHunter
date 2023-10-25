/*シーンマネージャー*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // タイトルシーン遷移
    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }


}
