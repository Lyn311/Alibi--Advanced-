using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SceneSwitchToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SceneSwitchToBeginning()
    {
        SceneManager.LoadScene("Beginning");
    }


}
