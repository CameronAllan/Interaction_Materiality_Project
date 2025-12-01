using UnityEngine;

public class MoveEffect : Effect
{
    [SerializeField] private Vector3 _targetLocalPos;

    public override void Play()
    {
        Transform target = InteractionManager.Instance.GetInteractionTarget().GetAnimRoot();

        if (target != null)
            target.localPosition = _targetLocalPos;
    }
}
