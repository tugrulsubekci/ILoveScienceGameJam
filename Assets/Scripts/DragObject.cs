using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private Vector3 mousePoint;
    private float mZCoord;
    private Camera mainCam;
    private Transform goTransform;
    private Rigidbody goRigidbody;
    private MoveRight moveRight;
    private CapsuleCollider goCollider;
    private Vector3 mouseDownPos;
    private float mouseDownTime;
    public bool isPositionOkay;
    private void Start()
    {
        mainCam = Camera.main;
        goTransform = GetComponent<Transform>();
        goRigidbody = GetComponent<Rigidbody>();
        moveRight = GetComponent<MoveRight>();
        goCollider = GetComponent<CapsuleCollider>();
    }
    void OnMouseDown()
    {
        if(goCollider != null)
        {
            goCollider.enabled = false;
        }
        mouseDownTime = Time.time;
        mouseDownPos = goTransform.position;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return mainCam.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        goTransform.position = GetMouseAsWorldPoint() + mOffset;
    }
    private void OnMouseUp()
    {
        goRigidbody.useGravity = true;
        moveRight.enabled = false;
        goCollider.enabled = true;
        Invoke(nameof(Check), 0.5f);
    }
    void Check()
    {
        if(!isPositionOkay)
        {
            mouseDownPos += (Time.time - mouseDownTime) * 0.5f * Vector3.right;
            goTransform.position = mouseDownPos;
            moveRight.enabled = true;
        }
    }
}