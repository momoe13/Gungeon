using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationBulletHub : MonoBehaviour
{
    public static List<GameObject> bullets = new List<GameObject>();//’e‚ğŠÇ—‚·‚éƒŠƒXƒg

    [HideInInspector] public float degBullet;//’e“¹‚ÌŠp“x

    public int bNum;//’e”

    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;//’e‚Ì‘¬“x
    [SerializeField] private float startDeg = 0f;//’e‚Ìon‚ß‚éŠp“x
    [SerializeField] private int bulletNumber;//’e‚Ì”
    [SerializeField] private string attackTag;//’e‚ÌTag

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Generate();
    }

    private void Generate()//’e‚Ì¶¬
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Debug.Log("a");
            var b = Instantiate(bullet, transform.position, Quaternion.identity);//’e‚Ì¶¬
            bullets.Add(b);//¶¬‚µ‚½’e‚ğƒŠƒXƒg‚É’Ç‰Á
            Fire(b.GetComponent<RBullet>(),i);
        }
        Destroy(this.gameObject);//ˆê•bŒã‚ÉHub‚ğíœ
    }

    private void  Fire(RBullet b,int i)//’e‚Éî•ñ‚ğ“n‚·
    {
        float bulletRad = 360 / bulletNumber;//’eŠÔ‚ÌŠp“x‚ğ‹‚ß‚é
        if (b == null) 
        {
            Debug.LogError("’e‚ª‚È‚¢");
            return;
        }
        b.deg = bulletRad * (i + 1) + startDeg;//Šp“x‚Ìó‚¯“n‚µ
        b.speed = speed;//‘¬“x‚Ìó‚¯“n‚µ
        b.aTag = attackTag;//ƒ^ƒO‚Ìó‚¯“n‚µ
        b.Shot();//’e‚ÌŠÖ”Shot‚ğÀs
    }
}
