using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneTransition : MonoBehaviour
{
    public void DebugPlayScene()
    {
        SceneTransitionManager.LoadScene("DebugPlayScene");
    }

    public void TitleScene()
    {
        SceneTransitionManager.LoadScene("TitleScene");
    }

    public void MainScene()
    {
        SceneTransitionManager.LoadScene("MainScene");
    }

    public void ResultScene()
    {
        SceneTransitionManager.LoadScene("ResultScene");
    }
}
