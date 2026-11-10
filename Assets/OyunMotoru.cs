using UnityEngine;
using UnityEngine.InputSystem;

public class OyunMotoru : MonoBehaviour
{
    // Yönergedeki 3 adet [SerializeField] şartı
    [SerializeField] GameObject topPrefab;
    [SerializeField] int toplamTopSayisi = 10;
    [SerializeField] int hedefPuan = 10;

    int puan = 0;
    bool oyunBitti = false;

    void Start()
    {
        // Yönergedeki DÖNGÜ (For) şartı - Topları sahneye çıkarır
        for (int i = 0; i < toplamTopSayisi; i++)
        {
            // Balonu yarat ve 'yeniBalon' adında bir değişkende tut
            GameObject yeniBalon = Instantiate(topPrefab, Vector3.zero, Quaternion.identity);

            // Balonun Sekme koduna ulaşıp hızını ve yönünü tamamen rastgele ayarla
            yeniBalon.GetComponent<Sekme>().hiz = Random.insideUnitCircle.normalized * Random.Range(2f, 5f);
        }
        Debug.Log("Oyun Başladı! Vurman gereken top sayısı: " + hedefPuan);
    }

    void Update()
    {
        if (oyunBitti) return;

        // Yönergedeki DOKUNMA (Pointer) şartı
        var isaret = Pointer.current;
        if (isaret == null || !isaret.press.wasPressedThisFrame) return;

        Vector2 ekran = isaret.position.ReadValue();
        Vector2 dunya = Camera.main.ScreenToWorldPoint(ekran);

        // Dokunulan yerde bir nesne var mı?
        Collider2D vurulan = Physics2D.OverlapPoint(dunya);

        if (vurulan != null)
        {
            Destroy(vurulan.gameObject); // Vurulan topu patlat (sil)
            puan = puan + 1;
            Debug.Log("Tebrikler! Puan: " + puan);

            // Yönergedeki KAZANMA KOŞULU (if kuralı)
            if (puan >= hedefPuan)
            {
                Debug.Log("KAZANDIN! Bütün topları temizledin.");
                oyunBitti = true;
            }
        }
    }
}