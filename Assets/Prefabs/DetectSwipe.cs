using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;

    // 指を離したときだけ処理を行う
    public bool detectSwipeOnlyAfterRelease = false;

    // しきい値以上スワイプするとスワイプとして検知する
    public float SWIPE_THRESHOLD = 20f;
    private float time;
    void Update()
    {
        time += Time.deltaTime*3f;
        transform.rotation = Quaternion.Lerp(StartRot,targetRot,time);

        foreach (Touch touch in Input.touches)
        {
            // スワイプをし始めた位置を記録する
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        // しきい値以上縦方向にスワイプしたかどうか判定する
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            if (fingerDown.y - fingerUp.y > 0)
            {
                if(time >= 1f)
                {
                Debug.Log("up");
                OnSwipeUp();
                }
            }
            else if (fingerDown.y - fingerUp.y < 0)
            {
                if(time >= 1f)
                {
                Debug.Log("down");
                OnSwipeDown();
                }
            }
            fingerUp = fingerDown;
        }

        // しきい値以上横方向にスワイプしたかどうか判定する
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0)
            {
                if(time >= 1f)
                {
                Debug.Log("right");
                OnSwipeRight();
                }
            }
            else if (fingerDown.x - fingerUp.x < 0)
            {
                if(time >= 1f)
                {
                Debug.Log("left");
                OnSwipeLeft();
                }
            }
            fingerUp = fingerDown;
        }
    }
    void Start()
    {
        targetRot = transform.rotation;
        StartRot = targetRot;
    }
    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }
    private Quaternion StartRot;
    private Quaternion targetRot;
    void OnSwipeUp()
    {
        StartRot = transform.rotation;
        time = 0;
        targetRot = Quaternion.Euler(new Vector3(-90f, 0, 0f)) * transform.rotation;
        // transform.Rotate(new Vector3(-80,0,0));
    }

    void OnSwipeDown()
    {
        StartRot = transform.rotation;
        time = 0;
        targetRot = Quaternion.Euler(new Vector3(90f, 0, 0f)) * transform.rotation;
        // transform.Rotate(new Vector3(80,0,0));
    }

    void OnSwipeLeft()
    {
        StartRot = transform.rotation;
        time = 0;
        targetRot = Quaternion.Euler(new Vector3(0, 0, -90f)) * transform.rotation;
        // transform.Rotate(new Vector3(0,0,-80));
    }

    void OnSwipeRight()
    {
        StartRot = transform.rotation;
        time = 0;
        targetRot = Quaternion.Euler(new Vector3(0, 0, 90f)) * transform.rotation;
        transform.Rotate(new Vector3(0,0,80));
    }
}