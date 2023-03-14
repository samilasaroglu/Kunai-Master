using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public static SlowMotion instance;

    [SerializeField] float _slowMotionTimeScale;

    float _startTimeScale, _startFixedDeltaTime;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _startTimeScale = Time.timeScale;
        _startFixedDeltaTime = Time.fixedDeltaTime;

    }

    public void StartSlowMotion()
    {
        Time.timeScale = _slowMotionTimeScale;
        Time.fixedDeltaTime = _startFixedDeltaTime * _slowMotionTimeScale;
    }

    public void FinishSlowMotion()
    {
        Time.timeScale = _startTimeScale;
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }
}
