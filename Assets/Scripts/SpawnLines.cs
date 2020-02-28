using UnityEngine;

public class SpawnLines : MonoBehaviour
{
    public static int scoreChanger = 10;
    public static float spawnRate = 1f;
    public static float spawnSpeedUp;
    public static int numberOfWalls = 3;

    public float[] angles;
    public GameObject wallSprite;
    public GameObject wallCollider;
    public GameObject coin;
    public float spawnMaxRate;

    private float nextTimeToSpawn = 0f;
    private bool[] angleSpawn;
    private string[] sortingLayersNames;
    
    void Start()
    {
        angles = new float[6]{60f, 120f, 180f, 240f, 300f, 360f};
        angleSpawn = new bool[6]{true, true, true, true, true, true};
        sortingLayersNames = new string[6] {"60", "120", "180", "240", "300", "360"};
        spawnMaxRate = spawnRate + 2f;
    }

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {   
            SpawnObject(wallSprite, wallCollider, numberOfWalls);
            Spawncoins(coin, 1);
            UpdateAngles();
            nextTimeToSpawn = Time.time + 1f /spawnRate;
            if (spawnRate <= spawnMaxRate - 0.5f)
            {
                 spawnRate += spawnSpeedUp;
            }
        }


    } 
    void SpawnObject(GameObject gameObject, GameObject collider, int number)
    {
        int count = 0;
        int index = Random.Range(0,6);

        while (count < number)
        {
            if (angleSpawn[index])
            {   
                gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayersNames[index];
                Vector2 wallSpawnVector = Quaternion.AngleAxis(angles[index], Vector3.forward) * new Vector2(6f,0f);
                Instantiate(gameObject, wallSpawnVector, Quaternion.AngleAxis(angles[index], Vector3.forward));
                Vector2 edgeSpawnVector = Quaternion.AngleAxis(angles[index], Vector3.forward) * new Vector2(5.85f,0f);
                Instantiate(collider, edgeSpawnVector, Quaternion.AngleAxis(angles[index], Vector3.forward));
                angleSpawn[index] = false;
                count++;
            } else
            {
                index = Random.Range(0,6);
            }
        }
        
    }
    void Spawncoins(GameObject coin, int number)
    {
        int count = 0;
        int index = Random.Range(0,6);
        while (count < number)
        {
            if (angleSpawn[index])
            {   
            Vector2 wallSpawnVector = Quaternion.AngleAxis(angles[index], Vector3.forward) * new Vector2(6f,0f);
            Instantiate(coin, wallSpawnVector, Quaternion.AngleAxis(angles[index], Vector3.forward));
            angleSpawn[index] = false;
            count++;
            } else
            {
                index = Random.Range(0,6);
            }
        }
    }

    void UpdateAngles()
    {
        for (int i = 0; i < angleSpawn.Length; i++)
        {
            angleSpawn[i] = true;      
        }
    }

    void SpawnSpeedUp()
    {
        if (GameControll.instance.score >= GameControll.instance.score + scoreChanger && numberOfWalls < 5)
        {
            scoreChanger += 5;
            numberOfWalls++;
        }
    }

}
