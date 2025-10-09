using UnityEngine;

public class Button_PressEffect : Effect
{
    [SerializeField] private Vector3 _targetPos;

    [SerializeField] private GameObject _buttonPressObj;

    public override void Play()
    {
        //Maybe turn this into a coroutine and lerp later but for now just set position then I'll make it better later
        
        _buttonPressObj.transform.localPosition = _targetPos;
    }
}
