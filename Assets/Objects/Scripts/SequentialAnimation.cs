using System.Collections;
using UnityEngine;

public class SequentialAnimation : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PlayAnimationsSequentially());
        }
    }

    IEnumerator PlayAnimationsSequentially()
    {
        foreach (Transform child in transform)
        {
            Animator animator = child.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("PlayAnimation");
                yield return new WaitForSeconds(0.7f);
            }
        }
    }
}