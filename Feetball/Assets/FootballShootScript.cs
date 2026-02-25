using UnityEngine;
using System;

public class FootballShootScript : MonoBehaviour
{
    public enum ShootMode
    {
        aimMode,
        chargeMode,
        kickMode,
        none
    }

    public ShootMode currentShootMode;

    public event System.Action OnAim;
    public event System.Action OnEndAim;
    public event Action<float> OnCharge;
    public event Action<float> OnShoot;

    public float maxCharge;
    public float chargeAmount;

    public float chargeSpeed;

    public KeyCode shootKey;

    private void Update()
    {
        // Change later
        if (Input.GetKeyDown(shootKey) && currentShootMode == ShootMode.none)
        {
            currentShootMode = ShootMode.aimMode;

            OnAim?.Invoke();
        }
        else if (Input.GetKeyDown(shootKey) && currentShootMode == ShootMode.aimMode)
        {
            OnEndAim?.Invoke();
            BeginChargingUp();
        }
        else if (Input.GetKeyUp(shootKey) && currentShootMode == ShootMode.chargeMode)
        {
            float shootPower = chargeAmount;
            ShootFootball(chargeAmount);
        }


        if (currentShootMode == ShootMode.chargeMode)
        {
            ChargeUpShot();
        }
    }

    private void BeginChargingUp()
    {
        chargeAmount = 0;
        currentShootMode = ShootMode.chargeMode;

    }

    private void ChargeUpShot()
    {
        chargeAmount += Time.deltaTime * chargeSpeed;
        if (chargeAmount >= maxCharge)
        {
            chargeAmount = maxCharge;
        }

        OnCharge?.Invoke(chargeAmount);
    }

    private void ShootFootball(float power)
    {
        print("shot with " + power);
        currentShootMode = ShootMode.kickMode;

        OnShoot?.Invoke(power);

        currentShootMode = ShootMode.none;
    }

}
