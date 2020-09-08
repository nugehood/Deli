using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Transform originalPos;
    [HideInInspector]
    public float shakeAmount;
    public float seconds;
    public bool shake;

    [Tooltip("Only for EDITOR!")]
    public Color gizmosColor;
    Transform cameraPos;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GetComponent<Transform>();
    }

    private void Update()
    {
        if (shake)
        {
            cameraPos.localPosition = originalPos.localPosition + Random.insideUnitSphere * shakeAmount;
            Invoke("StopShake", seconds);
        }
    }

    public void StopShake()
    {
        shake = false;
        cameraPos.localPosition = originalPos.localPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, shakeAmount);
    }


}
