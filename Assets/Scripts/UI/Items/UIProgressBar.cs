using UnityEngine;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform _backgroundBar;
    [SerializeField] private RectTransform _bar;

    private float _maxWidth;

    private void Awake()
    {
        _maxWidth = _backgroundBar.rect.width;
        _bar.anchorMin = Vector2.zero;
        _bar.anchorMax = Vector2.up;
        _bar.pivot = Vector2.up/2;
    }

    public void UpdateProgress(float percent)
    {
        _bar.sizeDelta = new Vector2(_maxWidth * percent, _bar.sizeDelta.y);
    }
}
