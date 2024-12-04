using DG.Tweening;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    [SerializeField] bool animateOnStart;
    [SerializeField] ETweenType tweenType;
    [SerializeField] Vector2 targetPos;
    [SerializeField] Vector3 targetScale;
    [SerializeField] float tweenDuration;
    RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (animateOnStart)
        {
            switch (tweenType)
            {
                case ETweenType.Scale:
                    {
                        TweenScale();
                        break;
                    }
                case ETweenType.Move:
                    {
                        TweenMove();
                        break;
                    }
                case ETweenType.Both:
                    {
                        TweenScale();
                        TweenMove();
                        break;
                    }
            }
        }
    }
    public void TweenMove()
    {
        rectTransform.DOAnchorPos(targetPos, tweenDuration).SetEase(Ease.OutBounce);
    }
    public void TweenScale()
    {
        rectTransform.DOScale(targetScale, tweenDuration).SetEase(Ease.OutBounce);
    }
}
public enum ETweenType
{
    none,
    Scale,
    Move,
    Both

}

