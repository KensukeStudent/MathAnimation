using UnityEngine;

public class SmoothLookAtPlayer2D : MonoBehaviour
{
    enum Direction
    {
        LEFT,
        RIGHT
    }

    public Transform player;          // プレイヤーのTransform

    public float lookDuration; // プレイヤー方向を向くまでの時間

    private float startAngle;

    private float timer = 0;

    [SerializeField]
    private float moveSpeed;

    private Direction direction;

    private void Start()
    {
        startAngle = transform.eulerAngles.z;

        if (transform.position.x > player.position.x)
        {
            direction = Direction.LEFT;
        }
        else
        {
            direction = Direction.RIGHT;
        }
    }

    private void OnEnable()
    {
        timer = 0;
    }

    void Update()
    {
        if (player == null) return;

        float targetAngle = 0;

        if (timer < 1)
        {
            // プレイヤーへの方向を計算
            Vector2 directionToPlayer = (player.position - transform.position).normalized;

            // 目標の角度を計算（ラジアン -> ディグリー変換）
            targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            targetAngle -= 90;

            if (targetAngle < 1)
            {
                targetAngle += 360;
            }

            if (targetAngle > 360)
            {
                targetAngle -= 360;
            }

            Vector3 newEulerAngles = transform.eulerAngles;

            timer += Time.deltaTime / lookDuration;
            newEulerAngles.z = startAngle + (targetAngle - startAngle) * timer;
            transform.eulerAngles = newEulerAngles;
        }

        Debug.Log($"ターゲット:{targetAngle}, 差 : {(targetAngle - startAngle) * timer}, 結果:{startAngle + (targetAngle - startAngle) * timer} ,経過時間: {timer}");

        if (Vector2.Distance(transform.position, player.position) > 0.1)
        {
            // 向き方向に移動
            float finalSpeed = moveSpeed * timer;
            transform.position += transform.up * finalSpeed * Time.deltaTime;
        }
    }
}
