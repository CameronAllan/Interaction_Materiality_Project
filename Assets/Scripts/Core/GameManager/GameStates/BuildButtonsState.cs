using UnityEngine;

public class BuildButtonsState : GameState
{
    public BuildButtonsState(GameManager manager) : base(manager)
    {

    }

    public override void OnStateEnter()
    {
        UIManager.Instance.ShowButtonBuildView();
        InteractionManager.Instance.StartButtonCustomization();

    }

    public override void OnStateExit()
    {
        InteractionManager.Instance.EndButtonCustomization();
    }
}
