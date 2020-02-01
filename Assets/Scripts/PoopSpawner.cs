using UnityEngine;


public class PoopSpawner : MonoBehaviour
{
    public GameObject poopPrefab;


    public void ThrowPoop()
    {
        Instantiate(poopPrefab, transform.position, Quaternion.identity);
    }
}

