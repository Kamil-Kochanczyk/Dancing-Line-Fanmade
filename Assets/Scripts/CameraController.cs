using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _dancingHead;

    private Vector3 _offset;

    private void Start()
    {
        _offset = _dancingHead.position - transform.position;
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = _dancingHead.position - _offset;
    }
}
