using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusView : MonoBehaviour
{
    
    [SerializeField] Text scoreText;
    
	public void UpdateText(PlayerModel playerModel)
	{
		
		scoreText.text = string.Format("得点：{0}", playerModel.Score);

    }
    
}
