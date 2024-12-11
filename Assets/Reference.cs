using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reference : MonoBehaviour
{
    public GameObject Panel;

    public void ShowPanel()
    {
        if (Panel !=  null)
        {
            Animator animator = GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("ShowPanel");

                animator.SetBool("ShowPanel", !isOpen);   
            }
        }
    }
}
