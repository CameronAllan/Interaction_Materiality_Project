using UnityEngine;
using UnityEngine.UIElements;

public class SimpleMover : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _isMoving;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _closeEnough;


    void Update()
    {
        if (_isMoving)
        {
            if (Vector3.Distance(transform.position, _targetPosition) < _closeEnough)
            {
                transform.position = _targetPosition;
                _isMoving = false;

            }
            else
            {
                float step = _moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
            }
        }
    }

    public void SnapToPosition(Vector3 position)
    {
        _targetPosition = position;
        transform.position = position;
        _isMoving = false;
    }

    public void SetTargetPosition(Vector3 position)
    {
        _targetPosition = position;

        _isMoving = true;
    }
}
