using UnityEngine;

[CreateAssetMenu(fileName = "UIScreensContainer", menuName = "UI Screens Container")]
public class UIScreensContainer : ScriptableObject
{
    [SerializeField] private UILoseScreenView _uiLoseScreen;
    public UILoseScreenView UILoseScreen => _uiLoseScreen;
}
