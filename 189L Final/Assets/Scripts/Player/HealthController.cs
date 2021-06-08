using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Animator animator;

    
    // 3 Hearts for main form, and 1 heart for Slime Form.
    private int Hearts;
    public Image[] UIHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private PlayerController PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        this.Hearts = 4;
        this.animator = this.gameObject.GetComponent<Animator>();
        this.PlayerController = this.gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        for (int i = 0; i < UIHearts.Length; i++)
        {
            if (i < Hearts)
            {
                UIHearts[i].sprite = fullHeart;
            }
            else
            {
                UIHearts[i].sprite = emptyHeart;
            }
        }
    }
    ///<Summary>
    /// Removes a heart from the player. Will also set layers for the animator
    /// to switch from player to slime form and vice versa.
    ///</Summary>
    public void TakeDamage()
    {
        if (this.Hearts > 0)
        {
            this.Hearts--;
        }

        // Set layer weight to change from full form to slime form sprites.
        if (this.Hearts == 1)
        {
            this.animator.SetLayerWeight(0, 0);
            this.animator.SetLayerWeight(1, 1);
        }

        if (this.Hearts == 0)
        {
            animator.SetBool("IsDead", true);
            Destroy(GameObject.Find("IsAlive"));
        }
    }

    /// <Summary>
    /// Resets the player to full hearts. 
    /// </Summary>
    public void ResetForm() {
        this.Hearts = 4;
        // Revert from Slime to Full Form layer.
        this.animator.SetLayerWeight(1, 0);
        this.animator.SetLayerWeight(0, 1);
     }
     public int GetHearts() {
         return this.Hearts;
     }

}
