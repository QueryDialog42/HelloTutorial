using UnityEngine;

public class MyScript : MonoBehaviour
{
    // Genellikle başlamadan önce çalışır, 1 kere çalışır
    void Awake()
    {

    }
    // Oyun başlarken çalışır, 1 kere çalışır
    void Start()
    {
        Debug.Log("Start");
        Debug.LogWarning("This is warning");
        Debug.LogError("allah ne oldu?");
    }

    // Frame bazında oyun boyunca çalışır, oyun kapanana kadar çalışır
    void Update()
    {

    }

    // Update fonksiyonunun daha optimize halidir, her bilgisayarda aynı çalışması içindir.
    void FixedUpdate()
    {

    }

    // Update ve fixedupdate gibi çalışır ama daha sonra çalışır. Neredeyse kullanılmıyor.
    void LateUpdate()
    {
        
    }

    void TestFunction()
    {
        Debug.Log("Function is working");
    }
}
