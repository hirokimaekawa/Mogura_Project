using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateHammer : MonoBehaviour
{

    [SerializeField] MainPresenter mainPresenter;

    public GameObject hammerObj;

    GameObject[] tagObjects;

    private float mLength;
    private float mCur;

    // Start is called before the first frame update
    void Start()
    {
        Animator animOne = GetComponent<Animator>();
        AnimatorStateInfo infAnim = animOne.GetCurrentAnimatorStateInfo(0);
        mLength = infAnim.length;
        mCur = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

       
        mCur += Time.deltaTime;
        if (mCur > mLength)
        {
            StartCoroutine("DestroyClone");
          
            Check("HAMMER");
        }
      
    }

    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        
        if (tagObjects.Length == 0)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
                var canvas = this.GetComponent<Canvas>();
                var canvasRect = canvas.GetComponent<RectTransform>();

                Vector2 localpoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out localpoint);
                if (mainPresenter.leftTime > 0)
                {
                    var item = Instantiate(hammerObj);
                    item.transform.SetParent(this.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = localpoint;
                }
                
            }
            
        }
        
    }

    IEnumerator DestroyClone()
    {
       
        GameObject obj = GameObject.Find("Hammer(Clone)");
        // 指定したオブジェクトを削除
        yield return new WaitForSeconds(0.5f);
        Destroy(obj);
        
    }
}
