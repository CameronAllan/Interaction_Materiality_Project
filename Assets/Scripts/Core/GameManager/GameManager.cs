using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState _gameState;
    public GameState GameState
    {
        get
        {
            return _gameState;
        }
        set
        {
            if (_gameState != null)
                _gameState.OnStateExit();
            _gameState = value;
            _gameState.OnStateEnter();
        }
    }


}
