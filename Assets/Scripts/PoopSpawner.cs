using UnityEngine;


public class PoopSpawner : MonoBehaviour
{
    public GameObject poopPrefab;


    public void ThrowPoop()
    {
        //FIXME: Animation.
        Instantiate(poopPrefab, transform.position, Quaternion.identity);
    }
}

