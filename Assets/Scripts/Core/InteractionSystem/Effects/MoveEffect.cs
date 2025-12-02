using UnityEngine;

public class MoveEffect : Effect
{
    [SerializeField] private Vector3 _targetLocalPos;

    public override void Play()
    {

        Transform target = InteractionManager.Instance.GetInteractionTarget().GetAnimRoot();
        if(!StageAssetManager.Instance.gameObject.activeSelf)
            target = StageRatingManager.Instance.CurrentRatingTarget.GetAnimRoot();

        if (target != null)
            target.localPosition = _targetLocalPos;
    }
}
