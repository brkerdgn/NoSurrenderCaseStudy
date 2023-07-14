using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CreatePlayer playerInfo;
    Animator animator;
    public float pushForce = 10f;
    [SerializeField] bool isMainCharacter;
    
 
    private void Start()
    {
        playerInfo = GameObject.Find("Player Controller").GetComponent<CreatePlayer>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpýþma durumunda, karakterin üzerindeki Rigidbody'ye güç uygulanýyor
        if (collision.gameObject.CompareTag("Character"))
        {
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

            if (otherRb != null)
            {
                Vector3 pushDirection = collision.gameObject.transform.position - transform.position;
                pushDirection.Normalize();
                otherRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);

                animator.SetBool("isRunning", false);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Out"))
        {
            animator.SetBool("isFalling", true);
            Destroy(this.gameObject);
            playerInfo.totalPlayerCount--;
            if (isMainCharacter)
            {
                playerInfo.isMyDead = true;
            }
        }
    }
}
