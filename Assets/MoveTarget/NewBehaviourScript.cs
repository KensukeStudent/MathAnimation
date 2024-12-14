using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;          // プレイヤーのTransform

    public float lookDuration = 1.0f; // プレイヤー方向を向くまでの時間
    public float lookTimer = 0f;     // 回転の進行度を管理するタイマー

    float currentAngle;

    private void Start()
    {
        currentAngle = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーへの方向を計算
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // 目標の角度を計算（ラジアン -> ディグリー変換）
        float targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Unityの回転基準を調整（上方向を基準にする）
        targetAngle -= 90f;

        // 回転タイマーを更新
        lookTimer += Time.deltaTime / lookDuration; // 指定した時間で1になる
        lookTimer = Mathf.Clamp01(lookTimer);       // 0～1に制限

        // 現在の角度と目標角度を補間
        float smoothAngle = Mathf.LerpAngle(currentAngle, targetAngle, lookTimer);

        // 新しい角度を設定
        Vector3 newEulerAngles = transform.eulerAngles;
        newEulerAngles.z = smoothAngle;
        transform.eulerAngles = newEulerAngles;
    }
}
