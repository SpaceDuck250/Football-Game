using UnityEngine;

public class RotateArrowScript : MonoBehaviour
{
    public FootballShootScript shootScript;

    public float maxRotationValue;
    public float rotateTimer;

    public float rotateSpeed;

    public bool canAim;

    public GameObject arrow;

    private void Start()
    {
        shootScript.OnAim += OnAim;
        shootScript.OnShoot += OnShoot;
        shootScript.OnEndAim += OnEndAim;
    }

    private void OnDestroy()
    {
        shootScript.OnAim -= OnAim;
        shootScript.OnShoot -= OnShoot;
        shootScript.OnEndAim -= OnEndAim;

    }

    private void Update()
    {
        if (!canAim)
        {
            return;
        }

        Rotate();
    }

    private void OnAim()
    {
        BeginAiming();
    }

    private void BeginAiming()
    {
        canAim = true;
        arrow.SetActive(true);
        rotateTimer = 0;
    }

    private void Rotate()
    {
        rotateTimer += Time.deltaTime * rotateSpeed;
        if (rotateTimer >= maxRotationValue)
        {
            rotateTimer = 0;
        }

        Quaternion rotateAmount = Quaternion.Euler(0, 0, rotateTimer);
        transform.rotation = rotateAmount;
    }

    private void OnEndAim()
    {
        canAim = false;
    }

    private void OnShoot(float power)
    {
        arrow.SetActive(false);

    }
}
