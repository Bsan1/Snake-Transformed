using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public GameObject head;
    Snake headScript; 

    void Start()
    {
        if(head.TryGetComponent<Snake>(out Snake snakeScript))
        {
            headScript = snakeScript;
        }
        else
        {
            Debug.LogError($"{gameObject.name} has no head!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            headScript.ResetState();
        }
        
    }
}
