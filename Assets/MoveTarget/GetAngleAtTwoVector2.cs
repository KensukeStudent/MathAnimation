using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAngleAtTwoVector2 : MonoBehaviour
{

    [SerializeField]
    GameObject _start;

    [SerializeField]
    GameObject _target;

    void Update()
    {
        float angle = GetAngle(_start.transform.position, _target.transform.position);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        Debug.Log(angle - 90);
    }

    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}