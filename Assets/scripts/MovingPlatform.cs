using UnityEngine;

[DefaultExecutionOrder(-100)]
[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool startMovingRight = true;
    public Vector3 Velocity { get; private set; }
    private Rigidbody rigidBody;
    private Vector3 startPosition;
    private float travelled;
    private int direction;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;

        startPosition = rigidBody.position;
        direction = startMovingRight ? 1 : -1;
    }

    private void FixedUpdate()
    {
        travelled += direction * speed * Time.fixedDeltaTime;

        if (travelled >= distance)
        {
            travelled = distance;
            direction = -1;
        }
        else if (travelled <= -distance)
        {
            travelled = -distance;
            direction = 1;
        }

        Vector3 nextPosition =
            startPosition + Vector3.right * travelled;

        Velocity = (nextPosition - rigidBody.position)
           / Time.fixedDeltaTime;

        rigidBody.MovePosition(nextPosition);
    }
}
