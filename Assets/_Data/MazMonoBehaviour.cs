
using UnityEngine;

public class MazMonobehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.loadCompoments();
    }

    protected virtual void Reset()
    {
        this.loadCompoments();
    }

    protected virtual void loadCompoments()
    {
        //for ovrride
    }
    protected virtual void Start()
    {
        //for override
    }
}
