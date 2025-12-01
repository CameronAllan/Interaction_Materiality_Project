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

    public bool French;

    public void Awake()
    {
        GameState = new TitleState(this);
    }

    public void StartNewGame(bool inFrench)
    {
        French = inFrench;

        GameState = new RateButtonsState(this);
    }

    public void EnterEditMode()
    {
        GameState = new BuildButtonsState(this);
    }

    public void TitleScreen()
    {
        GameState = new TitleState(this);
    }

}
