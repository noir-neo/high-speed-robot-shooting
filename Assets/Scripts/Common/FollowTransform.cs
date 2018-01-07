using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float smooth;

    void Update()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, smooth * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, smooth * Time.deltaTime);
    }
}