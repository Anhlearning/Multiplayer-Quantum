using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cameraFR;
    [SerializeField] private float turnSpeed;
    public float lerpSpeed = 10f;
    private float targetYaw = 0f;
    private Coroutine yawCoroutine = null;
    public static CameraController Instance {get ; private set;}

    private void Awake() {
        Instance = this;
    }
    public void AddYawInput(float amt){
        targetYaw += amt * Time.deltaTime * turnSpeed;
        if (yawCoroutine == null)
        {
            yawCoroutine = StartCoroutine(LerpYaw());
        }
    }
    private IEnumerator LerpYaw()
    {
        while (true)
        {
            // Lấy giá trị hiện tại
            float currentValue = cameraFR.m_XAxis.Value;

            // Nội suy tới targetYaw
            float newValue = Mathf.Lerp(currentValue, targetYaw, lerpSpeed * Time.deltaTime);

            // Gán giá trị mới
            cameraFR.m_XAxis.Value = newValue;

            // Nếu đã rất gần targetYaw, dừng coroutine
            if (Mathf.Abs(newValue - targetYaw) < 0.01f)
            {
                cameraFR.m_XAxis.Value = targetYaw; // Đảm bảo đạt chính xác mục tiêu
                yawCoroutine = null; // Đặt lại coroutine
                yield break; // Thoát coroutine
            }

            // Chờ frame tiếp theo
            yield return null;
        }
    }
}
