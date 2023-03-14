using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour ,IPointerClickHandler ,IDragHandler,IPointerDownHandler,IPointerUpHandler,IDropHandler
{
    public static InputController instance; 


    Vector2 _firstClickPos, _lastClickPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        if (GameManager.instance.GameStart)
        {
            PlayerController.instance.ResetArrowSize();
            PlayerController.instance.ResetArrowDirection();

            _firstClickPos = eventData.position;
            PlayerController.instance._arrow.SetActive(true);

            if (PlayerController.instance.IsKnifeThrow)
            {
                SlowMotion.instance.StartSlowMotion();

                EventManager.Broadcast(GameEvent.OnSlowMotion);
            }
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (GameManager.instance.GameStart)
        {
            PlayerController.instance._arrow.SetActive(false);

            if (PlayerController.instance.IsKnifeThrow)
            {
                SlowMotion.instance.FinishSlowMotion();
                PlayerController.instance.IsKnifeThrow = false;
            }
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameManager.instance.GameStart)
        {
            GameManager.instance.StartTheGame();
            Debug.Log("Oyun Başladı");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.instance.GameStart)
        {
            _lastClickPos = eventData.position;
            PlayerController.instance.SetArrowAngle(_firstClickPos, _lastClickPos);
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (GameManager.instance.GameStart)
        {
            PlayerController.instance.ThrowKnife();

        }
    }

}
