using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationBulletHub : MonoBehaviour
{
    public static List<GameObject> bullets = new List<GameObject>();//’e‚ğŠÇ—‚·‚éƒŠƒXƒg

    [HideInInspector] public float degBullet;//’e“¹‚ÌŠp“x

    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;//’e‚ÌƒXƒs[ƒh
    [SerializeField] private float startDeg = 0f;//’e‚Ìon‚ß‚éŠp“x
    [SerializeField] private int bulletNumber;//’e‚Ì”

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
            var b = Instantiate(bullet, transform.position, Quaternion.identity);//’e‚Ì¶¬
            bullets.Add(b);//¶¬‚µ‚½’e‚ğƒŠƒXƒg‚É’Ç‰Á
            Fire(b.GetComponent<RBullet>(),i);
        }
    }

    private void Fire(RBullet b,int i)//’e‚Éî•ñ‚ğ“n‚·
    {
        float bulletRad = 360 / bulletNumber;//’eŠÔ‚ÌŠp“x‚ğ‹‚ß‚é
        if (b == null) 
        {
            Debug.LogError("’e‚ª‚È‚¢");
            return;
        }
        b.deg = bulletRad * (i + 1) + startDeg;//Šp“x‚Ìó‚¯“n‚µ
        b.speed = speed;//‘¬“x‚Ìó‚¯“n‚µ
        b.Shot();//’e‚ÌŠÖ”Shot‚ğÀs
    }
}
