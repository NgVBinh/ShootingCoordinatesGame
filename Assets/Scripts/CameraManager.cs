using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float transitionSpeed;
    [SerializeField] private GameObject[] listWall;

    private Camera mainCamera;
    private Transform oldCameraTransform;
    private float minX, maxX, minY, maxY;

    public static CameraManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera=Camera.main;
        oldCameraTransform=mainCamera.transform;
        minX = -25f;
        maxX = 25f;
        minY = -10f;
        maxY = 50f;
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    public void TargetObj(GameObject obj)
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, obj.transform.position, Time.deltaTime * transitionSpeed);
    }
    public void CancelTargetObj(GameObject obj)
    {
        mainCamera.gameObject.transform.position = oldCameraTransform.position;
    }

    public void MoveCamera()
    {

        if(Input.GetMouseButton(0)) {
            Vector3 temp= mainCamera.transform.position;

            temp = Vector3.Lerp(mainCamera.transform.position, mainCamera.ScreenToWorldPoint(Input.mousePosition), transitionSpeed*Time.deltaTime);

            Mathf.Clamp(temp.x,minX,maxX);
            Mathf.Clamp(temp.y, minY, maxY);

            mainCamera.transform.position = temp;
            //Debug.Log(mainCamera.transform.position);
        }

    }
}
