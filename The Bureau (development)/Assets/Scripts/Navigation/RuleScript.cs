using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RuleScript : MonoBehaviour 
{
	public Button NextButton;
	public Button PreviousButton;
	public Button BackToMenuButton;
	public Text RuleText;
	public Image RuleImage;
	public int RulePage;

	void Start () 
	{
		NextButton = GameObject.Find ("NextButton").GetComponent<Button> ();
		PreviousButton = GameObject.Find ("PreviousButton").GetComponent<Button> ();
		BackToMenuButton = GameObject.Find ("BackToMenuButton").GetComponent<Button> ();
		RuleText = GameObject.Find ("ruletext").GetComponent<Text> ();
		RuleImage = GameObject.Find ("RuleImage").GetComponent<Image> ();
		RuleImage.enabled = false;
		RulePage = 0;
		//NextButton.onClick.AddListener (NextButtonClick);
		//PreviousButton.onClick.AddListener (PreviousButtonClick);
		//BackToMenuButton.onClick.AddListener (BackToMenuClick);
		//SetText ();
	}

	/*void NextButtonClick () 
	{
		if (RulePage < 5)
			RulePage++;
		SetText ();
	}

	void PreviousButtonClick ()
	{
		if (RulePage > 0)
			RulePage--;
		SetText ();
	}

	void BackToMenuClick ()
	{
		Initiate.Fade ("mainmenu", Color.black, 2);
	}*/

	void Update ()
	{
		switch (RulePage)
		{
		case 0:
			RuleImage.enabled = false;
			RuleText.enabled = true;
			RuleText.text = "A new president and his cabinet have been elected to run the country, and you have been tasked\nwith staffing the Bureau of Information. Your job collectively as a team is to see that the correct\ndocuments (coloured cards designated Military, Government and Media) get to the correct\norganisations within the time allowed by the game. Players may have to negotiate between them to\nensure the correct number of reports are able to be submitted within each round. If all of the correct\nreports are submitted before the phones timer runs out the team wins – failure to submit all of the\nrequired reports (the cards) on time means the team loses and the phone wins.";
			break;
		case 1:
			RuleImage.enabled = false;
			RuleText.enabled = true;
			RuleText.text = "Setup: \n1. One person should shuffle the pack of cards and deal out 5 to each player and place the\nremaining deck face down anywhere in reach of all players. Leave space for a discard pile\nnearby.\n2. Place the phone with the app running, in the centre of the table where it can be seen by all\nplayers. Leave space near it to place the ‘submitted’ report cards\n3. Press play on the app when you are ready to play.";
			break;
		case 2:
			RuleImage.enabled = false;
			RuleText.enabled = true;
			RuleText.text = "During play, your phone will ask for you as a team to provide an amount of a certain colour report\n(red for Military, yellow for Government or blue representing the Media) into the middle of the table\n(the discard pile). Only one player per round can submit these reports by placing them face up in the\ndiscard pile. Each round as dictated by the phone is played collaboratively by all players\nsimultaneously.";
			break;
		case 3:
			RuleImage.enabled = true;
			RuleText.enabled = false;
			break;
		case 4:
			RuleImage.enabled = false;
			RuleText.enabled = true;
			RuleText.text = "Only one player may submit the reports. Once these correct number and type of reports are placed\nin the centre any player should touch the centre of the phone to progress onto the next round.\nIf however no players can satisfy the report demand, one of two things can then happen:\n Players may trade reports in batches of 3 with another player – any combination of colours\ncan be traded per trade. Players whom have already traded cannot trade with the same\nperson until the next round. Trades between 2 players must happen simultaneously i.e.\nboth sets of 3 cards are exchanged at the same time from your existing 5 card deck – the 3\nexchanged cards cannot be added to a players deck and then they decide which 3 cards to\noffer back in exchange.\n Alternatively, players may press the “skip” button on the phone, discard all 5 of their cards\nand draw 5 fresh cards from the deck at the cost of a time penalty. The impact of “skipping”\nis to reduce the total game play time by 20 seconds. This makes it harder to complete all 20\nrounds.";
			break;
		case 5:
			RuleImage.enabled = false;
			RuleText.enabled = true;
			RuleText.text = "After the correct number of the required coloured reports have been submitted the player who\nsubmitted them draws up fresh cards to bring their total back to five. If the draw pile is not large\nenough to draw back up, shuffle the discard pile back into the draw pile, and draw as normal.\nPlay continues until all requirements have been satisfied in which case the team wins, or the timer\nruns out and the phone wins (i.e. the team loses).";
			break;
		}
	}
}
