

using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerRespawn player =
            other.GetComponentInParent<PlayerRespawn>();

        if (player != null && respawnPoint != null)
        {
            player.SetCheckpoint(respawnPoint);

            Debug.Log("Checkpoint Activated!");
        }
    }
}
