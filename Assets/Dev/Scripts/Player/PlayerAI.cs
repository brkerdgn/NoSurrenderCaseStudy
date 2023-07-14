using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{

    [SerializeField] float speed; 
    public GameObject[] characters;
    Animator animator;

    private void Start()
    {
        //Sahnedeki biz dahil t�m oyuncular� tag ile buluyoruz
        characters = GameObject.FindGameObjectsWithTag("Character");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveTowardsClosestCharacter();
    }

    private void MoveTowardsClosestCharacter()
    {
        GameObject closestCharacter = null; // En yak�n karakter referans�
        float closestDistance = Mathf.Infinity; // En yak�n mesafe ba�lang��ta sonsuz olarak ayarlan�r
        Vector3 currentPosition = transform.position; // Mevcut karakter pozisyonunu al�r

        // Sahnedeki aktif karakterleri kontrol et
        foreach (GameObject character in characters)
        {
            if (character != gameObject && character != null)
            {
                // Yok edilmemi� karakterlerin pozisyonunu alarak en yak�n� bulma
                float distance = Vector3.Distance(currentPosition, character.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCharacter = character;
                }
            }
        }

        if (closestCharacter != null)
        {
            Vector3 direction = closestCharacter.transform.position - currentPosition;
            direction.Normalize();

            // Karakterin hareket etmesi sa�lan�yor
            transform.forward = direction;
            transform.position += transform.forward * speed * Time.deltaTime;
            animator.SetBool("isRunning", true); // Ko�ma animasyonu �al��t�r�l�yor
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}

   

