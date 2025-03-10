using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float respawnTime = 2f; // Time before respawn after death
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position; // Store the initial spawn position
    }

    // Method to simulate the player's death and respawn
    public void Respawn()
    {
        // Wait for the respawn time before teleporting the player to the last checkpoint
        Invoke("TeleportToCheckpoint", respawnTime);
    }

    private void TeleportToCheckpoint()
    {
        // If a checkpoint has been reached, move the player to the checkpoint position
        if (Checkpoint.lastCheckpointPosition != Vector3.zero)
        {
            transform.position = Checkpoint.lastCheckpointPosition;
            Debug.Log("Player respawned at last checkpoint!");
        }
        else
        {
            // If no checkpoint is set, respawn at the initial position
            transform.position = initialPosition;
            Debug.Log("Player respawned at initial position!");
        }
    }
}
