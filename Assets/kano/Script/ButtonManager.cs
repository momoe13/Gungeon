using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void GetButton(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
