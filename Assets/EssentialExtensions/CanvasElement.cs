using UnityEngine;

public abstract class CanvasElement : MonoBehaviour
{
    private RectTransform _rectTransform;

    public RectTransform rectTransform
    {
        get { return (_rectTransform != null) ? _rectTransform : (_rectTransform = this.GetComponent<RectTransform>()); }
    }
}
