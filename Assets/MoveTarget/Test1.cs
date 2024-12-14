using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private void Update()
    {
        var playerPos = player.position;
        var pos = transform.position;

        var diff = playerPos - pos;
        var rad = Mathf.Atan2(diff.y, diff.x);
        float degree = rad * Mathf.Rad2Deg;

        if (degree < 0)
        {
            degree += 360;
        }
        degree -= 90;

        transform.eulerAngles = new Vector3(0, 0, degree);
    }
}
