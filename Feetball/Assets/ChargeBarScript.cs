using UnityEngine;
using UnityEngine.UI;

public class ChargeBarScript : MonoBehaviour
{
    public GameObject chargeBarObj;
    public Image greenBar;

    public FootballShootScript shootScript;

    private void Start()
    {
        shootScript.OnCharge += OnCharge;
        shootScript.OnShoot += OnShoot;
    }

    private void OnDestroy()
    {
        shootScript.OnCharge -= OnCharge;
        shootScript.OnShoot -= OnShoot;
    }

    private void OnCharge(float chargeAmount)
    {
        chargeBarObj.SetActive(true);
        greenBar.fillAmount = chargeAmount / shootScript.maxCharge;
    }

    private void OnShoot(float power)
    {
        chargeBarObj.SetActive(false);
    }
}
