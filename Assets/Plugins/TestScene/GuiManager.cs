using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {

	AndroidJavaObject jo;
	AndroidJavaClass jc2;

	
	/// <summary>
	/// Set AchievementId from the Editor to use the specific Achievement
	/// </summary>/
	
	// Use this for initialization
	void Start () {
	}

	void OnGUI (){
		int xPos = 0;
		int yPos = 10;
		
		/*
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"getPlayerName"))
		{
			string abc = jo.Call<string>("getPlayerName");
			guiText.text = abc;
		}
		
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"signOut"))
		{
			jo.Call("signOut");
		}
		*/
		
		if(GUI.Button(new Rect(xPos,yPos,150,150),"incrementAch"))
		{
			GooglePlayServicesBinding.instance.incrementAchievement("CgkI6qOE1uUQEAIQBg",1);	// Achievement ID on first argument and achievement increment count on second argument
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"signIn"))
		{
			GooglePlayServicesBinding.instance.signIn();
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"signOut"))
		{
			GooglePlayServicesBinding.instance.signOut();
		}
		
		
		yPos += 200;
		xPos = 0;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestAchievementStateForId"))
		{
			GooglePlayServicesBinding.instance.requestAchievementStateForId("CgkI6qOE1uUQEAIQBg");
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"submitScore"))
		{
			GooglePlayServicesBinding.instance.submitScore("CgkI6qOE1uUQEAIQBw",1402);
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestAchievementTotalStepsForId"))
		{
			GooglePlayServicesBinding.instance.requestAchievementTotalStepsForId("CgkI6qOE1uUQEAIQBg");
		}
		
		
		yPos += 200;
		xPos = 0;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestAchievementCurrentStepsForId"))
		{
			GooglePlayServicesBinding.instance.requestAchievementCurrentStepsForId("CgkI6qOE1uUQEAIQBg");
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestAchievementTypeForId"))
		{
			GooglePlayServicesBinding.instance.requestAchievementTypeForId("CgkI6qOE1uUQEAIQBg");
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestAchievementDescriptionForId"))
		{
			GooglePlayServicesBinding.instance.requestAchievementDescriptionForId("CgkI6qOE1uUQEAIQBg");
		}
		
		
		yPos += 200;
		xPos = 0;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"diaplayAllLeaderborads"))
		{
			GooglePlayServicesBinding.instance.diaplayAllLeaderborads();
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestLeaderboardRawScoreForId"))
		{
			GooglePlayServicesBinding.instance.requestLeaderboardRawScoreForId("CgkI6qOE1uUQEAIQBw", GooglePlayServicesBinding.LeaderboardTimeSpan.TIME_SPAN_ALL_TIME , GooglePlayServicesBinding.LeaderboardCollection.COLLECTION_SOCIAL);
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestLeaderboardScoreOrderForId"))
		{
			GooglePlayServicesBinding.instance.requestLeaderboardScoreOrderForId("CgkI6qOE1uUQEAIQBw");
		}
		
		
		yPos += 200;
		xPos = 0;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestLeaderboardRankForId"))
		{
			GooglePlayServicesBinding.instance.requestLeaderboardRankForId("CgkI6qOE1uUQEAIQBw", GooglePlayServicesBinding.LeaderboardTimeSpan.TIME_SPAN_ALL_TIME , GooglePlayServicesBinding.LeaderboardCollection.COLLECTION_SOCIAL);
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"requestLeaderboardTimestampMillisForId"))
		{
			GooglePlayServicesBinding.instance.requestLeaderboardTimestampMillisForId("CgkI6qOE1uUQEAIQBw",GooglePlayServicesBinding.LeaderboardTimeSpan.TIME_SPAN_ALL_TIME , GooglePlayServicesBinding.LeaderboardCollection.COLLECTION_SOCIAL); // LeaderBoard ID on first argument and Request LeaderBoard Type on second argument
		}
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"getPlayerName"))
		{
			GooglePlayServicesBinding.instance.getPlayerName();
		}
		
		/*
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"unlockAch"))
		{
			GooglePlayServicesBinding.instance.unlockAchievement("");	// Put Achievement ID in the argument
		}
		
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"incrementAch"))
		{
			GooglePlayServicesBinding.instance.incrementAchievement("CgkI6qOE1uUQEAIQBg",1);	// Achievement ID on first argument and achievement increment count on second argument
		}
		xPos = 0;
		yPos = 200;
		
		if(GUI.Button(new Rect(xPos,yPos,150,150),"viewAllAchs"))
		{
			GooglePlayServicesBinding.instance.displayAllAchievements();
		}
		
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"viewLeaderBoard"))
		{
			GooglePlayServicesBinding.instance.displayLeaderboard("CgkI6qOE1uUQEAIQBw",1); // LeaderBoard ID on first argument and Request LeaderBoard Type on second argument
		}
		
		xPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"submit score"))
		{
			GooglePlayServicesBinding.instance.submitScore("CgkI6qOE1uUQEAIQBw",1400); // LeaderBoard ID on first argument and score on second argument
		}
		*/
		
		/*
		xPos = 0;
		yPos += 200;
		if(GUI.Button(new Rect(xPos,yPos,150,150),"revealAch"))
		{
			if(AchievementId != null)
				jo.Call("revealAchievement", AchievementId);
		}
		*/
	}
}
