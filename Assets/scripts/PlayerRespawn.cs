
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    private float fallHeight = -5.0f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Vector3 checkpointPosition;
    private Quaternion checkpointRotation;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        checkpointPosition = startPosition;
        checkpointRotation = startRotation;
    }

    private void FixedUpdate()
    {
        if (rigidBody.position.y < fallHeight)
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Transform newCheckpoint)
    {
        checkpointPosition = newCheckpoint.position;
        checkpointRotation = newCheckpoint.rotation;

        Debug.Log("Checkpoint Saved!");
    }

    public void Respawn()
    {
        rigidBody.linearVelocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

        rigidBody.position = checkpointPosition;
        rigidBody.rotation = checkpointRotation;
    }
}
