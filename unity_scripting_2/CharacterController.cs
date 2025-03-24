using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign the prefab in the Inspector
    public Transform spawnPoint; // Optional: Define a specific spawn position

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to spawn an object
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
