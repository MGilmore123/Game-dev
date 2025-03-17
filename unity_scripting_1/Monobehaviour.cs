using UnityEngine;

public class Example3DPhysics : MonoBehaviour
{
    private Rigidbody rb;
    public float forceStrength = 10f;  // Strength of the force applied to the object

    // Called when the script is initialized
    void Awake()
    {
        // Get the Rigidbody component attached to this object
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the object.");
        }
    }

    // FixedUpdate is called at fixed intervals (ideal for physics updates)
    void FixedUpdate()
    {
        // Check if Rigidbody is assigned
        if (rb != null)
        {
            // Apply a constant force on the object (e.g., pushing it in the positive Y direction)
            rb.AddForce(Vector3.up * forceStrength);  // Apply force upwards
        }
    }
}
