using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float startHeight = 0.15f;
    [SerializeField] private float checkDistance = 0.25f;
    [SerializeField] private float maxGroundAngle = 50f;

    private Rigidbody playerBody;

    private void Awake()
    {
        playerBody = GetComponentInParent<Rigidbody>();
    }

    public bool IsGrounded
    {
        get
        {
            Vector3 origin = transform.position
                + Vector3.up * startHeight;

            RaycastHit[] hits = Physics.RaycastAll(
                origin,
                Vector3.down,
                checkDistance,
                Physics.DefaultRaycastLayers,
                QueryTriggerInteraction.Ignore
            );

            float nearestDistance = float.PositiveInfinity;
            Vector3 groundNormal = Vector3.zero;

            foreach (RaycastHit hit in hits)
            {
                // Ignore the player's own colliders.
                if (playerBody != null &&
                    hit.collider.attachedRigidbody == playerBody)
                {
                    continue;
                }

                if (hit.distance < nearestDistance)
                {
                    nearestDistance = hit.distance;
                    groundNormal = hit.normal;
                }
            }

            return nearestDistance < float.PositiveInfinity &&
                Vector3.Angle(groundNormal, Vector3.up)
                <= maxGroundAngle;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 origin = transform.position
            + Vector3.up * startHeight;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(
            origin,
            origin + Vector3.down * checkDistance
        );
    }
}