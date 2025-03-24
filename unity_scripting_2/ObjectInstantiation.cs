using UnityEngine;

public class AdvancedObjectManager : MonoBehaviour
{
    public GameObject prefab; // Assign in Inspector
    public Transform spawnPoint; // Optional, assign a specific spawn location

    private void Start()
    {
        // Example: Accessing a component on the same GameObject
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Rigidbody found on this object!");
            rb.mass = 2.0f; // Modify property
        }

        // Example: Accessing a component in a child object
        Collider childCollider = GetComponentInChildren<Collider>();
        if (childCollider != null)
        {
            Debug.Log("Collider found in a child object: " + childCollider.name);
            childCollider.enabled = false; // Disable collider for demonstration
        }

        // Example: Accessing a component in a parent object
        Animator parentAnimator = GetComponentInParent<Animator>();
        if (parentAnimator != null)
        {
            Debug.Log("Animator found in a parent object!");
            parentAnimator.speed = 1.5f; // Adjust animation speed
        }

        // Instantiate an object and manipulate its components
        GameObject newObject = InstantiateObject();
        if (newObject != null)
        {
            ModifySpawnedObject(newObject);
        }
    }

    private GameObject InstantiateObject()
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is not assigned!");
            return null;
        }

        // Instantiate the prefab at the specified spawn point or default position
        GameObject instance = Instantiate(prefab, spawnPoint != null ? spawnPoint.position : Vector3.zero, Quaternion.identity);
        Debug.Log("Spawned a new object: " + instance.name);
        
        return instance;
    }

    private void ModifySpawnedObject(GameObject instance)
    {
        // Retrieve and modify a component on the newly spawned object
        Renderer renderer = instance.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.red; // Change color dynamically
        }

        // Add a Rigidbody dynamically if it doesn’t exist
        Rigidbody rb = instance.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = instance.AddComponent<Rigidbody>();
            rb.mass = 5.0f;
            rb.useGravity = true;
        }

        Debug.Log("Modified spawned object: " + instance.name);
    }
}
