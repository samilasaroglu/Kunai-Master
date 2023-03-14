using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject _arrow;
    public bool IsKnifeThrow;

    [SerializeField] GameData _gameData;
    [SerializeField] GameObject _arrowAnchor,_knife;
    [SerializeField] Rigidbody _knifeRb;
    [SerializeField] float _value;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _arrow = _arrowAnchor.transform.GetChild(0).gameObject;

    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnSlowMotion, OnSlowMotion);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnSlowMotion, OnSlowMotion);
    }


    public void ThrowKnife()
    {
        _knife.transform.position = _arrowAnchor.transform.position;
        _knife.transform.rotation = _arrow.transform.rotation;

        _knifeRb.velocity = Vector3.zero;
        _knifeRb.angularVelocity = Vector3.zero;

        _knifeRb.AddForce(_knife.transform.up * _gameData.ThrowForceValue, ForceMode.Impulse);

        IsKnifeThrow = true;
    }

    public void SetArrowAngle(Vector2 firstPos,Vector2 lastPos)
    {

        float angle = Mathf.Atan2(firstPos.y - lastPos.y, firstPos.x - lastPos.x)*Mathf.Rad2Deg;

        _arrowAnchor.transform.rotation = Quaternion.Euler(0, 0, 180+angle);

        SetArrowSize(Vector2.Distance(firstPos, lastPos));
    }

    public void ResetArrowDirection()
    {
        _arrowAnchor.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90f));
    }

    public void ResetArrowSize()
    {
        _arrow.transform.localScale = new Vector3(.4f, .4f, 1);
    }

    public void SetPlayerPosition()
    {
        transform.position = _knife.transform.position;
    }

    void SetArrowSize(float dist)
    {

        if (dist < 200)
        {
            _arrow.transform.localScale = new Vector3(.4f, .4f, 1);
        }
        else if(dist > 300)
        {
            _arrow.transform.localScale = new Vector3(.4f, .6f, 1);
        }
        else
        {
            _arrow.transform.localScale = new Vector3(.4f, dist * _value, 1);
        }

    }

    void OnSlowMotion()
    {
        SetPlayerPosition();
    }

}
