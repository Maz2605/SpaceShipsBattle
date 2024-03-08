using UnityEngine;

public class BulletSpawner : Spawner
{
    private new static BulletSpawner instance;

    public static BulletSpawner Instance
    {
        get => instance;
    }

    public static string bulletOne = "Bullet";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exits");
        BulletSpawner.instance = this;
    }
}