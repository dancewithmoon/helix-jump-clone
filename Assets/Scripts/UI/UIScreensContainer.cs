using UnityEngine;

[CreateAssetMenu(fileName = "UIScreensContainer", menuName = "UI Screens Container")]
public class UIScreensContainer : ScriptableObject
{
    [SerializeField] private UILoseScreenView _uiLoseScreen;
    public UILoseScreenView UILoseScreen => _uiLoseScreen;

    [SerializeField] private UIWinScreenView _uiWinScreen;
    public UIWinScreenView UIWinScreen => _uiWinScreen;
}
