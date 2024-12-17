using UnityEngine;
using UnityEngine.SceneManagement;

public class HPScript : MonoBehaviour
{
    [SerializeField] float HP;      //HPの変数
    public GameObject HPUIobj_1;
    public GameObject HPUIobj_2;
    public GameObject HPUIobj_3;

    [SerializeField]
    GameObject player;
    PlayerScript playersc;

    private void Start()
    {
        playersc = player.GetComponent<PlayerScript>();

    }


    private void Update()           //HPがゼロになったときにゲームオーバーシーンを呼び出す
    {

         float HP= playersc.GetHp();
        switch (HP) 
        {
            case  0:
                SceneManager.LoadScene("3_GameOverScene");
                break;

            case 1:
                HPUIobj_2.SetActive(false);
                break;

            case 2:
                HPUIobj_1.SetActive(false);
                break;
        
        
        
        
        }
    }

}
