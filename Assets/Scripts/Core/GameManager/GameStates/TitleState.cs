using UnityEngine;

public class TitleState : GameState
{
    public TitleState(GameManager manager) : base(manager)
    {

    }

    public override void OnStateEnter()
    {
        UIManager.Instance.ShowTitleView();
    }

    public override void OnStateExit()
    {
        
    }
}
