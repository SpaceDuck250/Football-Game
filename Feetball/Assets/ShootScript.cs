using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public FootballShootScript shootScript;

    public Rigidbody2D playerRb;
    public float kickIntensifier;

    public bool canShoot;

    private void Start()
    {
        shootScript.OnShoot += OnShoot;
    }

    private void OnDestroy()
    {
        shootScript.OnShoot -= OnShoot;

    }

    private void OnShoot(float power)
    {
        //if (!canShoot)
        //{
        //    return;
        //}
        ResetVelocity();
        Shoot(transform.up, power);
    }

    private void ResetVelocity()
    {
        playerRb.linearVelocity = Vector3.zero;
    }

    private void Shoot(Vector2 direction, float power)
    {
        Vector2 shootForce = direction * power * kickIntensifier;
        playerRb.AddForce(shootForce, ForceMode2D.Impulse);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision != null && collision.gameObject.tag == "GameBall")
    //    {
    //        canShoot = true;
    //    }
    //}
}
