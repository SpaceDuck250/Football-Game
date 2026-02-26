using UnityEngine;

public class AntiRotaterScript : MonoBehaviour
{
    public FootballShootScript shootScript;
    public Rigidbody2D rb;

    private void Start()
    {
        shootScript.OnAim += OnAim;
        shootScript.OnEndAim += OnEndAim;
    }



    private void OnDestroy()
    {
        shootScript.OnAim -= OnAim;
        shootScript.OnEndAim -= OnEndAim;

    }

    private void OnAim()
    {
        rb.freezeRotation = true;
    }

    private void OnEndAim()
    {
        rb.freezeRotation = false;

    }


}
