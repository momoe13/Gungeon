using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitleButton : MonoBehaviour
{
    public void GetButton()
    {
        SceneManager.LoadScene("0_TitleScene");
    }
}
