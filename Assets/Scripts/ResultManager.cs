using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ResultManager : MonoBehaviour
{
	

	[SerializeField] GameObject nodePrefab;
	[SerializeField] GameObject node;
	[SerializeField] GameObject canvas;
    public GameObject rankingButton;
    public GameObject backButton;

    
    public static string nowTime;
    public string stringRankingList;
   

    [SerializeField] Text NodeCloneText;

    public List<Text> rankingList = new List<Text>();

    // Start is called before the first frame update
    public void Start()
    {
  
        var timesList = PlayerPrefsX.GetStringArray("NOW2");
        Debug.Log(timesList);
        var scoreList = PlayerPrefsX.GetIntArray("SCORE2");

        foreach (int A in scoreList)
        {
            Debug.Log(A);
        }

        //得点を新しい順に表示するコード
        var zip = scoreList.Zip(timesList, (scores, times) => new { scores, times })
                    .OrderByDescending(pair => pair.times)
                    .Select((pair, index) => $"No.{index + 1} {pair.times} 得点：{pair.scores}");

        foreach (string A in zip)
        {
          

            node = Instantiate(nodePrefab);
            node.transform.SetParent(canvas.transform, false);
            var txtComp = node.GetComponentInChildren<Text>();
            txtComp.text = A;
           
            Debug.Log(A);

          
            rankingList.Add(txtComp);
            Debug.Log(rankingList[0]);
        }


    }
    public void OnToTitleButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void SwitchRankingButton()
    {
        var scoreList = PlayerPrefsX.GetIntArray("SCORE2");
        var timesList = PlayerPrefsX.GetStringArray("NOW2");
        var zip2 = scoreList.Zip(timesList, (scores, times) => new { scores, times })
            .OrderByDescending(pair => pair.scores)
                            .Select((pair, index) => $" No.{index + 1} {pair.times} 得点：{pair.scores}")
                            .ToArray();
        for (int i = 0; i < zip2.Length; i++)
        {
            rankingList[i].text = zip2[i];
        }
        rankingButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void BackButton()
    {
        rankingButton.SetActive(true);
        backButton.SetActive(false);
        var scoreList = PlayerPrefsX.GetIntArray("SCORE2");
        var timesList = PlayerPrefsX.GetStringArray("NOW2");
        var zip2 = scoreList.Zip(timesList, (scores, times) => new { scores, times })
            .OrderByDescending(pair => pair.times)
                            .Select((pair, index) => $" No.{index + 1} {pair.times} 得点：{pair.scores}")
                            .ToArray();
        for (int i = 0; i < zip2.Length; i++)
        {
            rankingList[i].text = zip2[i];
        }
    }
       
}
