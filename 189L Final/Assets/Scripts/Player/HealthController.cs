using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // 3 Hearts for main form, and 1 heart for Slime Form.
    private int Hearts;

    private Animator Animator;

    private PlayerController PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        this.Hearts = 4;
        this.Animator = this.gameObject.GetComponent<Animator>();
        this.PlayerController = this.gameObject.GetComponent<PlayerController>();
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
            this.Animator.SetLayerWeight(0, 0);
            this.Animator.SetLayerWeight(1, 1);
        }

        // if (this.Hearts == 0) 
        // {
        //     this.PlayerController.
        // }
    }

    /// <Summary>
    /// Resets the player to full hearts. 
    /// </Summary>
    public void ResetForm() {
        this.Hearts = 4;
        // Revert from Slime to Full Form layer.
        this.Animator.SetLayerWeight(1, 0);
        this.Animator.SetLayerWeight(0, 1);
     }
     public int GetHearts() {
         return this.Hearts;
     }

}
