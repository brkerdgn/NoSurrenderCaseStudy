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
        //Sahnedeki biz dahil tüm oyuncularý tag ile buluyoruz
        characters = GameObject.FindGameObjectsWithTag("Character");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveTowardsClosestCharacter();
    }

    private void MoveTowardsClosestCharacter()
    {
        GameObject closestCharacter = null; // En yakýn karakter referansý
        float closestDistance = Mathf.Infinity; // En yakýn mesafe baþlangýçta sonsuz olarak ayarlanýr
        Vector3 currentPosition = transform.position; // Mevcut karakter pozisyonunu alýr

        // Sahnedeki aktif karakterleri kontrol et
        foreach (GameObject character in characters)
        {
            if (character != gameObject && character != null)
            {
                // Yok edilmemiþ karakterlerin pozisyonunu alarak en yakýný bulma
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

            // Karakterin hareket etmesi saðlanýyor
            transform.forward = direction;
            transform.position += transform.forward * speed * Time.deltaTime;
            animator.SetBool("isRunning", true); // Koþma animasyonu çalýþtýrýlýyor
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}

   

