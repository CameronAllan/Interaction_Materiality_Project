using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("UI Holder Vars")]
    [SerializeField] private TitleUI _titleMenuHolder;
    [SerializeField] private RatingUI _buttonRateHolder;
    [SerializeField] private EffectTimelineUI _buttonBuildHolder;

    [Header("GameObject Holder Vars")]
    [SerializeField] private Transform _buttonRateGOHolder;
    [SerializeField] private Transform _buttonBuildGOHolder;


    #region UI View Setting

    public void ShowTitleView()
    {
        _titleMenuHolder.gameObject.SetActive(true);
        _buttonRateHolder.gameObject.SetActive(false);
        _buttonBuildHolder.gameObject.SetActive(false);

        _buttonRateGOHolder.gameObject.SetActive(false);
        _buttonBuildGOHolder.gameObject.SetActive(false);

        _titleMenuHolder.DisplayUI();
    }

    public void ShowButtonRateView()
    {
        _titleMenuHolder.gameObject.SetActive(false);
        _buttonRateHolder.gameObject.SetActive(true);
        _buttonBuildHolder.gameObject.SetActive(false);

        _buttonRateGOHolder.gameObject.SetActive(true);
        _buttonBuildGOHolder.gameObject.SetActive(false);

        _buttonRateHolder.DisplayUI();
    }

    public void ShowButtonBuildView()
    {
        _titleMenuHolder.gameObject.SetActive(false);
        _buttonRateHolder.gameObject.SetActive(false);
        _buttonBuildHolder.gameObject.SetActive(true);

        _buttonRateGOHolder.gameObject.SetActive(false);
        _buttonBuildGOHolder.gameObject.SetActive(true);

    }

    #endregion
}
