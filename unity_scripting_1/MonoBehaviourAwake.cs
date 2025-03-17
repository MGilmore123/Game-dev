using UnityEngine;

public class Example3DObject : MonoBehaviour
{
    private Rigidbody rb;

    // Called when the script is initialized
    void Awake()
    {
        // Initialize the Rigidbody component (if it exists on the same object)
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody found on the object.");
        }

        // Set the initial position of the object in 3D space
        transform.position = new Vector3(0, 5, 0);  // Set initial position at (0, 5, 0)

        // You can initialize other things here, like other components or variables
        Debug.Log("Awake called: Object position initialized to " + transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        // You can use Start() for other initialization or setup tasks.
        Debug.Log("Start called: Object is ready.");
    }

    // Update is called once per frame
    void Update()
    {
        // If the Rigidbody was initialized in Awake, you can apply forces or other changes here
        if (rb != null)
        {
            // Example of applying a force to the Rigidbody to move the object
            rb.AddForce(Vector3.up * 10f);  // Apply force upwards
        }
    }
}
