using UnityEngine.Events;
using UnityEngine;

public class ColliderTriggetEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter = new ();

    private void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnter != null)
        {
            onTriggerEnter.Invoke();
        }
    }
}