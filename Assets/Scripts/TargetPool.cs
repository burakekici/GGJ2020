using UnityEngine;


public class TargetPool : MonoBehaviour
{
    public GameObject targetPrefab;
    public int poolSize = 5;
    public float spawnRate = 4F;

    private GameObject[] targets;
    private float timeSinceLastSpawned;


    private void Start()
    {
        GameManager.Instance.NotifyOnNextGroundPositionedObservers += NextGroundPositioned;
    }


    private void OnDestroy()
    {
        GameManager.Instance.NotifyOnNextGroundPositionedObservers -= NextGroundPositioned;
    }


    private void Update()
    {
        
    }


    private void NextGroundPositioned(Vector3 groundPosition, float groundWidth)
    {
        Printer.PrintGreen("Next ground position: " + groundPosition + " - Width: " + groundWidth);

        var count = Random.Range(2, 5);
        
        for (int i = 0; i < count; i++)
        {
            var t = Instantiate(targetPrefab, transform).transform;
            float randomPositionX = Random.Range(groundPosition.x, groundPosition.x + groundWidth);
            t.position = new Vector3(randomPositionX, t.position.y);
        }
    }
}

