using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController:MonoBehaviour {
	float frameCount = 0;
	Command dealCards;
	Command playCards = new PlayCard();
	Command evaluateRules = new EvaluateRules();
	Player playerOne = new Player(Player.PlayerType.Human);
	Player playerTwo = new Player(Player.PlayerType.NPC);
	Dictionary<float,Command> commandsList = new Dictionary<float,Command> ();
	string playerOneCards = string.Empty;
	string playerTwoCards = string.Empty;
 	void Start()
	{
		dealCards = new DealCards(playerOne,5); 
		dealCards.Execute();
		dealCards = new DealCards(playerTwo,5);
		dealCards.Execute();
		
		foreach (var item in playerOne.GetCardsList())
		{
			playerOneCards += ((int)item.GetCardType()).ToString();
			if(playerOne.GetCardsList().FindIndex(x => x == item) <  (playerOne.GetCardsList().Count - 1)){
				playerOneCards += ",";
			}
		}
		PlayerPrefs.SetString("PLAYERONECARDS",playerOneCards);
		foreach (var item in playerTwo.GetCardsList())
		{
			playerTwoCards += ((int)item.GetCardType()).ToString();
			if(playerTwo.GetCardsList().FindIndex(x => x == item) <  (playerTwo.GetCardsList().Count - 1)){
				playerTwoCards += ",";
			}
		}
		PlayerPrefs.SetString("PLAYERTWOCARDS",playerTwoCards);

	}
	void Update()
	{
		frameCount++;//Number to Save the frame
	}
}
