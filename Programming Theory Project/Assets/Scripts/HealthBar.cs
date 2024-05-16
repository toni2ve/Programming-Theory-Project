using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Healthbar;

    public void UpdateHealth(float fraction)
    {
        Healthbar.fillAmount = fraction;
    }
}
