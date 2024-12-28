using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothing = 3f;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 CamPos = Vector3.Lerp(transform.position, _targetPosition.position + _offset, Time.fixedDeltaTime * _smoothing);
        transform.position = CamPos;
    }
}
