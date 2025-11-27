using UnityEngine;

public class StageAssetManager : Singleton<StageAssetManager>
{

    //Movement Vars
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private Vector3 _customizePosition;

    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _isMoving;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _closeEnough = 0.05f;


    private void Update()
    {
        if (_isMoving)
        {
            if(Vector3.Distance(transform.position, _targetPosition) < _closeEnough)
            {
                transform.position = _targetPosition;
                _isMoving = false;

            } else
            {
                float step = _moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
            }
        }
    }

    public void CenterElementInView()
    {
        _targetPosition = _defaultPosition;
        _isMoving = true;
    }

    public void MoveElementToEditPosition()
    {
        _targetPosition = _customizePosition;
        _isMoving = true;
    }
}
