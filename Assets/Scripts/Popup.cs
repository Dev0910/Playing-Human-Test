using UnityEngine;

public class Popup : MonoBehaviour
{
    public RectTransform rectTransform;
    public Vector2 startPos;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
        gameObject.SetActive(false);
    }
}
