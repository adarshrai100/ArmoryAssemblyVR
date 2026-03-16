using UnityEngine;

public class TwoHandSupport : MonoBehaviour
{
    public Transform supportGrip;
    private Transform supportHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            supportHand = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == supportHand)
        {
            supportHand = null;
        }
    }

    void LateUpdate()
    {
        if (supportHand != null)
        {
            Vector3 direction = supportHand.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}