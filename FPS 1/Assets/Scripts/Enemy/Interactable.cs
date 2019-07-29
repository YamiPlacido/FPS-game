using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    private Animator _anim => GetComponent<Animator>();

    public void HitReaction()
    {
        StartCoroutine(Dying());
        _anim.SetTrigger("die");
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
