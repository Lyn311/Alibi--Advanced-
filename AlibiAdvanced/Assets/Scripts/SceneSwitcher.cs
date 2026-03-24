using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SceneSwitchToMain()
    {
        SceneManager.LoadScene("MainScene");
        PanelManager.Instance.triggerPanelOpen(false);
    }

    public void SceneSwitchToBeginning()
    {
        SceneManager.LoadScene("Beginning");
    }


}
