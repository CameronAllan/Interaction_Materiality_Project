using UnityEngine;

public class RateButtonsState : GameState
{
    public RateButtonsState(GameManager manager) : base(manager)
    {

    }

    public override void OnStateEnter()
    {
        StageRatingManager.Instance.StartButtonRating();
        UIManager.Instance.ShowButtonRateView();
    }

    public override void OnStateExit()
    {
        
    }
}
