using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour ,IPointerClickHandler ,IDragHandler,IPointerDownHandler,IPointerUpHandler
{

    Vector2 _firstClickPos, _lastClickPos;


    public void OnPointerDown(PointerEventData eventData)
    {
        _firstClickPos = eventData.position;
        PlayerController.instance._arrow.SetActive(true);
        // Arrowu aktif yap ve parmağın başlandıç pozisyonunu al
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerController.instance.GetDirection();
        PlayerController.instance.ResetArrowSize();
        PlayerController.instance._arrow.SetActive(false);
        PlayerController.instance.ResetArrowDirection();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

        _lastClickPos = eventData.position;
        PlayerController.instance.SetArrowAngle(_firstClickPos, _lastClickPos);
        // Parmağın pozisyonunu al sürekli ve parmağın ilk pozisyona göre okun yönünü belirle.
        // Okun scaleY'sini deltaya göre ayarla
    }

}
