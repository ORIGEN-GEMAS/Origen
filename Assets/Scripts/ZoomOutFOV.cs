using UnityEngine;
using Cinemachine;

public class ZoomOutFOV : MonoBehaviour
{
    public Transform target;
    public float zoomSpeed = 2f;
    public float maxZoom = 30f;
    public float minZoom = 60f;
    public float zoomThreshold = 5f;

    private CinemachineVirtualCamera virtualCamera;
    private float initialFov;
    private bool isZooming = false;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        initialFov = virtualCamera.m_Lens.FieldOfView;
    }

    private void Update()
    {
        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < zoomThreshold && !isZooming)
        {
            isZooming = true;
            StartCoroutine(ZoomOut());
        }
        else if (distance >= zoomThreshold && isZooming)
        {
            isZooming = false;
            StartCoroutine(ZoomIn());
        }
    }

    private System.Collections.IEnumerator ZoomIn()
    {
        float currentFov = virtualCamera.m_Lens.FieldOfView;

        while (currentFov > maxZoom)
        {
            currentFov -= zoomSpeed * Time.deltaTime;
            currentFov = Mathf.Clamp(currentFov, maxZoom, initialFov);
            virtualCamera.m_Lens.FieldOfView = currentFov;
            yield return null;
        }
    }

    private System.Collections.IEnumerator ZoomOut()
    {
        float currentFov = virtualCamera.m_Lens.FieldOfView;

        while (currentFov < minZoom)
        {
            currentFov += zoomSpeed * Time.deltaTime;
            currentFov = Mathf.Clamp(currentFov, initialFov, minZoom);
            virtualCamera.m_Lens.FieldOfView = currentFov;
            yield return null;
        }
    }
}

