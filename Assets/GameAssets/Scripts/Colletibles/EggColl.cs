using UnityEngine;

public class EggColl : MonoBehaviour, IColletible
{
    public void CollectWheat()
    {
        GameManager.Instance.OnEggCollected();
        Destroy(gameObject);
    }
}
