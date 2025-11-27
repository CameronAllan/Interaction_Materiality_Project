using UnityEngine;

public abstract class GameState 
{
    protected GameManager _manager;

    protected GameState(GameManager manager)
    {
        _manager = manager;
    }

    #region State Management

    public abstract void OnStateEnter();

    public abstract void OnStateExit();

    #endregion
}
