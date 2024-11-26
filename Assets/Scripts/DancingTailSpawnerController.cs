using UnityEngine;

public class DancingTailSpawnerController : MonoBehaviour
{
    [SerializeField] private DancingHeadController _dancingHead;
    [SerializeField] private GameObject _dancingTail;

    private Vector3 _turnStartPosition;
    private Vector3 _offset;
    private GameObject _currentTail;

    private void OnEnable()
    {
        _dancingHead.OnChangeDirection += SpawnTail;
    }

    private void OnDisable()
    {
        _dancingHead.OnChangeDirection -= SpawnTail;
    }

    private void Start()
    {
        _turnStartPosition = _dancingHead.transform.position;
        _offset = _dancingHead.transform.position - _turnStartPosition;
        _currentTail = Instantiate(_dancingTail, _turnStartPosition, _dancingHead.transform.rotation);
        _currentTail.transform.localScale = _dancingHead.transform.localScale;
    }

    private void Update()
    {
        MoveAndScale();
    }

    private void SpawnTail()
    {
        _turnStartPosition = _dancingHead.transform.position;
        _currentTail = Instantiate(_dancingTail, _turnStartPosition, _dancingHead.transform.rotation);
        _currentTail.transform.localScale = _dancingHead.transform.localScale;
    }

    private void MoveAndScale()
    {
        _offset = _dancingHead.transform.position - _turnStartPosition;
        _currentTail.transform.position = _turnStartPosition + (_offset / 2.0f);
        _currentTail.transform.localScale = _dancingHead.transform.localScale + _offset;
    }
}
