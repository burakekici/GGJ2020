using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject obstaclePrefab;

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

    
    private void NextGroundPositioned(Vector3 groundPosition, float groundWidth)
    {
        var count = 3;//Random.Range(2, 5);
        
        for (int i = 0; i < count; i++)
        {
            //var randomPositionX = GetRandomPositionX(groundPosition, groundWidth, (i + 1) / count);
            var randomPositionX = groundPosition.x + groundWidth / count * (i + 1);
            
            var number = Random.Range(0, 2);
            if (number == 0)
            {
                Printer.PrintGreen("TARGET - " +  "GroundPos: " + groundPosition + " - RandomPosX: " + randomPositionX);

                GenerateTarget(randomPositionX);
            }
            else
            {
                Printer.PrintRed("OBSTACLE - " +  "GroundPos: " + groundPosition + " - RandomPosX: " + randomPositionX);
                
                GenerateObstacle(randomPositionX);
            }
        }
    }


    private static float GetRandomPositionX(Vector3 groundPosition, float groundWidth, int widthMultiplier)
    {
        var lowerLimit = groundPosition.x;
        var upperLimit = groundPosition.x + groundWidth * widthMultiplier;
        var randomPositionX = Random.Range(lowerLimit, upperLimit);
        
        Printer.PrintGreen("Lower: " + lowerLimit + " - Upper: "+ upperLimit + " - RandomPosX: " + randomPositionX);
        
        return randomPositionX;
    }


    private void GenerateTarget(float randomPositionX)
    {
        var t = Instantiate(targetPrefab, transform).transform;
        t.position = new Vector3(randomPositionX, t.position.y);
    }


    private void GenerateObstacle(float randomPositionX)
    {
        var t = Instantiate(obstaclePrefab, transform).transform;
        var randomPositionY = Random.Range(-3.5F, 0.5F);
        t.position = new Vector3(randomPositionX, randomPositionY);
    }
}

