using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay =1f;
    [SerializeField] protected float shootTimer =1f;
    
    private void Update()
    {
        this.Shooting();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    protected virtual void Shooting()
    {
        if(!IsShooting()) return;
        //Delay đạn
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        //Đồng bộ hướng đạn với hướng bay
        Vector3 swanPos = transform.position ;
        Quaternion rolation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,swanPos, rolation);
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shooting");//xuất ra số lượng đạn 
    }

    protected bool IsShooting()//check xem có giữ chuột trái hay không 
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return isShooting;
    }
}
