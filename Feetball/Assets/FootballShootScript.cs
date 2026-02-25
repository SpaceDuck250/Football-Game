using UnityEngine;
using System;
using System.Runtime.CompilerServices;

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
    public event Action<float> OnShoot;

    public float maxCharge;
    public float chargeAmount;

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
        chargeAmount += Time.deltaTime;
        if (chargeAmount >= maxCharge)
        {
            chargeAmount = maxCharge;
        }
    }

    private void ShootFootball(float power)
    {
        print("shot with " + power);
        currentShootMode = ShootMode.kickMode;

        OnShoot?.Invoke(power);

        currentShootMode = ShootMode.none;
    }

}
