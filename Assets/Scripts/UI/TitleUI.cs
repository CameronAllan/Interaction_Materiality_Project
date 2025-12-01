using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private UIEffect _titleEffect;
    [SerializeField] private UIEffect _buttonHolderEffect;

    public void DisplayUI()
    {
        _titleEffect.isActive = true;
        _buttonHolderEffect.isActive = true;
    }

    public void StartNewGameEnglish()
    {
        GameManager.Instance.StartNewGame(false);
    }

    public void StartNewGameFrench()
    {
        GameManager.Instance.StartNewGame(true);
    }

    public void PackupUI()
    {
        _titleEffect.isActive = false;
        _buttonHolderEffect.isActive = false;
    }
}
