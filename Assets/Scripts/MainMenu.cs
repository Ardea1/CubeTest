using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public enum ButtonType
    {
        Start,
        Stop,
        Exit
    }

    public event System.Action<ButtonType> OnClick;

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private MenuButtons buttonStart;

    [SerializeField]
    private MenuButtons buttonStop;

    [SerializeField]
    private MenuButtons buttonExit;

    void Start()
    {
        buttonStart.OnClick += ButtonStart_OnClick;
        buttonStop.OnClick += ButtonStop_OnClick;
        buttonExit.OnClick += ButtonExit_OnClick;
    }
    private void ButtonStart_OnClick(MenuButtons button)
    {
        OnClick?.Invoke(ButtonType.Start);
    }

    private void ButtonStop_OnClick(MenuButtons button)
    {
        OnClick?.Invoke(ButtonType.Stop);
    }

    private void ButtonExit_OnClick(MenuButtons button)
    {
        OnClick?.Invoke(ButtonType.Exit);
    }
}
