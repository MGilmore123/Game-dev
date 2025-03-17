using UnityEngine;

public class Sprite3D : MonoBehaviour
{
    public Texture spriteTexture; // Assign the sprite texture in the inspector

    private Renderer objectRenderer;

    void Start()
    {
        // Get the renderer component of the object this script is attached to
        objectRenderer = GetComponent<Renderer>();
        
        // Check if sprite texture is assigned
        if (spriteTexture != null)
        {
            // Apply the sprite texture to the material
            objectRenderer.material.mainTexture = spriteTexture;
        }
        else
        {
            Debug.LogError("No sprite texture assigned to " + gameObject.name);
        }
    }

    void Update()
    {
        // Optionally, you can rotate the sprite to face the camera or add other behaviors
        // For example, make the sprite always face the camera
        Vector3 directionToCamera = Camera.main.transform.position - transform.position;
        transform.forward = directionToCamera.normalized;
    }
}
