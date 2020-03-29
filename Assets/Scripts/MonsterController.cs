using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    private GameObject gameManager;
    Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
       
        gameManager = GameObject.Find("GameManager");
        animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HAMMER")
        {
           
            Debug.Log("Monsterに当たる");
            gameManager.GetComponent<MainPresenter>().GetMole();
            MoguraDead();
        }  
    }

    void MoguraDead()
    {
        
        animator.Play("Damage@Mogura");
    }

    public void OnCompleteAnimation()
    {
        Destroy(this.gameObject);
    }
}
