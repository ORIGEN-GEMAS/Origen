using UnityEngine;
using Cinemachine;

public class AutoZoomIn : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float targetOrthographicSize = 2f;
    public float zoomDuration = 1f;

    private float initialOrthographicSize;
    private float zoomTimer;

    private void Start()
    {
        initialOrthographicSize = virtualCamera.m_Lens.OrthographicSize;
        zoomTimer = 0f;
        StartZoomIn();
    }

    private void Update()
    {
        if (zoomTimer > 0f)
        {
            zoomTimer -= Time.deltaTime;
            float t = 1f - Mathf.Clamp01(zoomTimer / zoomDuration);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(initialOrthographicSize, targetOrthographicSize, t);

            if (zoomTimer <= 0f)
            {
                zoomTimer = 0f;
                virtualCamera.m_Lens.OrthographicSize = targetOrthographicSize;
            }
        }
    }

    private void StartZoomIn()
    {
        zoomTimer = zoomDuration;
    }
}