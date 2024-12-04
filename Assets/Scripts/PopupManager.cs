using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] float tweenDuration;
    [SerializeField] List<Popup> popupList;
    private Popup currentPopup;
    private bool closingPanel;
    private bool openingPanel;

    void Start()
    {
        currentPopup = null;
        popupList = GetComponentsInChildren<Popup>().ToList();
        closingPanel = false;
        openingPanel = false;
    }

    public async void OpenPopup(Popup popup)
    {
        if (openingPanel)
        {
            return;
        }
        if (currentPopup != null)
        {
            ClosePopup();
            if (popup == currentPopup)
            {
                return;
            }
            await Task.Delay((int)(tweenDuration * 1100));
        }
        openingPanel = true;
        popup.gameObject.SetActive(true);
        popup.rectTransform.DOAnchorPos(Vector2.zero, tweenDuration).SetEase(Ease.InOutSine).OnComplete(() => { openingPanel = false; });
        currentPopup = popup;
    }

    public void ClosePopup()
    {
        if (currentPopup == null || closingPanel)
        {
            return;
        }
        closingPanel = true;
        currentPopup.rectTransform.DOAnchorPos(currentPopup.startPos, tweenDuration).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            currentPopup.gameObject.SetActive(false);
            closingPanel = false;
            currentPopup = null;
        });
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;

            if (!IsPointerOverUIElement(inputPosition))
            {
                ClosePopup();
            }
        }
    }

    private bool IsPointerOverUIElement(Vector2 inputPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = inputPosition
        };

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (RaycastResult result in raycastResults)
        {
            if (result.gameObject.GetComponentInParent<Popup>() == currentPopup)
            {
                return true;
            }
        }
        return false;
    }
}
