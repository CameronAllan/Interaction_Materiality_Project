using UnityEngine;

public class Button_ResetEffect : Effect
{
    [SerializeField] private Vector3 _resetPos;

    [SerializeField] private GameObject _buttonPressObj;

    public override void Play()
    {
        //TODO: also cleanup any other stuff that might be happening here?

        _buttonPressObj.transform.localPosition = _resetPos;
    }
}
