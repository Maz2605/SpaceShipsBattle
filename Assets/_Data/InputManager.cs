
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get => instance; 
    }
    [SerializeField] protected Vector3 mouseWorldPosition;
    [SerializeField] protected float onFiring;
    public float OnFiring
    {
        get => onFiring;
    }
    public Vector3 MouseWorldPosition
    {
        get => mouseWorldPosition;
    }

    private void Awake()
    {
        if(InputManager.instance!=null) Debug.LogError("Only 1 InputManager allow to exits");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
    }

    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMousePos()//lấy vị trí của con trỏ chuột 
    {
        if (Camera.main != null) 
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()//lấy thông tin bấm và giữ nút chuột trái
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
