using UnityEngine;

public class MenuKontrol : MonoBehaviour
{
    public GameObject splashMenu;
    public GameObject ayarlarMenu;
    public OyunMotoru oyunMotoruKodu;

    public void OyunaBasla()
    {
        splashMenu.SetActive(false);
        oyunMotoruKodu.enabled = true;
    }

    public void AyarlariAc()
    {
        ayarlarMenu.SetActive(true);
    }

    public void AyarlariKapat()
    {
        ayarlarMenu.SetActive(false);
    }
}