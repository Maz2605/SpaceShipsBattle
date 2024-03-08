
using UnityEngine;
public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;
    void FixedUpdate()
    {
        this.GetTargetPosByMouse();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosByMouse()//Di chuyển theo con trỏ chuột
    {
        this.targetPosition = InputManager.Instance.MouseWorldPosition;
        this.targetPosition.z = 0;
    }

    protected virtual void LookAtTarget()//hướng về con trỏ chuột
    {
        var parent = transform.parent;
        Vector3 diff = this.targetPosition - parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    protected virtual void Moving()
    {
        var parent = transform.parent;
        Vector3 newPosition = Vector3.Lerp(parent.position, targetPosition, this.speed);
        parent.position = newPosition;  
    }
}
