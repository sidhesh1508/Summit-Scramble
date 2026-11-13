using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int count = 0;
    public bool IsGrounded { get { return count > 0; }}
    private void OnTriggerEnter(Collider other)
    {
        if(other!=null && other.gameObject!=null)
        {
            ++count;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other!=null && other.gameObject !=null)
        {
            --count;
        }
    }
}
