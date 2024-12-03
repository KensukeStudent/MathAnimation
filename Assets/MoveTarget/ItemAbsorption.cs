using UnityEngine;

public class ItemAbsorption : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField, Header("アニメーション速度")]
    private float moveSpeed = 5f;

    [SerializeField, Header("弧の高さ")]
    private float curveHeight = 2f;

    private Vector3 startPosition; // アイテムの初期位置
    private float t; // 経過時間

    [SerializeField, Range(0.0f, 1.0f)]
    private float scaleTime;

    private void OnEnable()
    {
        StartAbsorption();
    }

    void Update()
    {
        t += Time.deltaTime * moveSpeed;

        // 距離の拡大縮小
        float timer = scaleTime > t
            ? Mathf.InverseLerp(0, scaleTime, t) // 0からscaleTimeを0～1へ正規化
            : 1 - Mathf.InverseLerp(scaleTime, 1, t); // scaleTimeから1を1～0へ反転

        float newDistance = curveHeight * timer;
        var point = Vector3.Lerp(startPosition, player.position, t);

        Vector3 newPosition = point + new Vector3(
            Mathf.Cos(t * Mathf.PI * 2) * newDistance,
            Mathf.Sin(t * Mathf.PI * 2) * newDistance,
            0
        );

        // 位置の適用
        transform.position = newPosition;

        // プレイヤーに到達したら終了処理
        if (t >= 1)
        {
            AbsorbComplete();
        }
    }

    public void StartAbsorption()
    {
        t = 0f;
        startPosition = transform.position;
    }

    private void AbsorbComplete()
    {
        gameObject.SetActive(false);
        transform.position = startPosition;
        t = 0;
    }
}
