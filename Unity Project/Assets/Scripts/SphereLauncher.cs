using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SphereLauncher : MonoBehaviour
{
    public Rigidbody spherePrefab; // Fırlatılacak sphere prefabı
    public int poolSize = 10; // Sphere havuzunun boyutu
    public float launchForce = 10f; // Fırlatma kuvveti
    public Color[] colors; // Sphere renkleri

    private List<Rigidbody> spherePool; // Sphere havuzu
    private int currentSphereIndex = 0; // Havuzdaki geçerli sphere indeksi

    private void Start()
    {
        // Sphere havuzunu oluştur
        CreateSpherePool();

        // İlk sphere'ı havuzdan alarak fırlat
        StartCoroutine(LaunchSpheres());
    }





    private void CreateSpherePool()
    {
        spherePool = new List<Rigidbody>();

        // Belirtilen boyutta sphere havuzunu oluştur
        for (int i = 0; i < poolSize; i++)
        {
            Rigidbody sphereInstance = Instantiate(spherePrefab, transform.position, Quaternion.identity);
            sphereInstance.gameObject.SetActive(false); // Sphere'ı etkisiz hale getiriyoruz
            spherePool.Add(sphereInstance);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LaunchSpheres());
        }
    }

    private IEnumerator LaunchSpheres()
    {
        // Geçerli sphere'ı havuzdan alıyoruz
        Rigidbody currentSphere = GetNextAvailableObject();

        // Rastgele bir renk seçiyoruz
        Color randomColor = colors[UnityEngine.Random.Range(0, colors.Length)];

        // Sphere'ın malzemesini oluşturulan rastgele renk ile değiştiriyoruz
        Renderer sphereRenderer = currentSphere.GetComponent<Renderer>();
        if (sphereRenderer != null)
        {
            sphereRenderer.material.color = randomColor;
        }

        // Sphere'ı etkinleştiriyoruz ve ileri doğru bir kuvvet uyguluyoruz
        currentSphere.gameObject.SetActive(true);
        currentSphere.transform.position = transform.position + Vector3.up * 3f; // Yerden 3 birim yukarıda başlatılıyor
        currentSphere.AddForce(transform.forward * launchForce, ForceMode.VelocityChange);

        yield return null;
    }

    private Rigidbody GetNextAvailableObject()
    {
        Rigidbody nextSphere = spherePool[currentSphereIndex];
        currentSphereIndex = (currentSphereIndex + 1) % spherePool.Count; // Bir sonraki sphere'ın indeksini güncelle
        return nextSphere;
    }

    public void ColorPlaneAtPosition(Vector3 position, float radius, Color color)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius);
        foreach (Collider collider in colliders)
        {
            Renderer renderer = collider.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = color;
            }
        }
    }



}