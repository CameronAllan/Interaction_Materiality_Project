using UnityEngine;

public class ScaleEffect : Effect
{
    [SerializeField] private Vector3 _targetScale;

    public override void Play()
    {
        Transform target = InteractionManager.Instance.GetInteractionTarget().GetAnimRoot();

        if(target != null )
            target.localScale = new Vector3(_targetScale.x, _targetScale.y, _targetScale.z);
    }
}
