using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    private float progress;

    [SerializeField]
    private float speed;

    [SerializeField, Min(1)]
    private int p;

    [SerializeField]
    private Slider slider = null;

    [SerializeField]
    private LineRenderer lineRenderer = null;

    [SerializeField]
    private Vector3 offset;

    private void Start()
    {
        slider.onValueChanged.AddListener((value) =>
        {
            if (lineRenderer != null)
            {
                AddPoint(value);
            }
        });
    }

    private void Update()
    {
        progress += Time.deltaTime * speed;

        float ret = Mathf.Pow(progress, p);
        ret = Mathf.Clamp01(ret);
        Debug.Log(ret);

        slider.value = ret;
    }

    private void AddPoint(float value)
    {
        // x : time
        // y : value

        lineRenderer.positionCount += 1;
        var x = progress * 8;
        var y = value * 8;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(x, y, 0) + offset);
    }
}
