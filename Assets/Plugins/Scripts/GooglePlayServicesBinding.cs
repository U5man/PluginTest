using UnityEngine;
using System.Collections;

public class GooglePlayServicesBinding : MonoBehaviour {
	
	public static GooglePlayServicesBinding instance;
	AndroidJavaObject jo;
	AndroidJavaClass jc2;
	
	public enum LeaderboardTimeSpan: int {
		TIME_SPAN_ALL_TIME = 2,
		TIME_SPAN_DAILY = 0,
		TIME_SPAN_ALL_WEEKLY = 1,
		TIME_SPAN_ERROR = -1
	};
	
	public enum LeaderboardCollection: int {
	 COLLECTION_PUBLIC = 0,
	 COLLECTION_SOCIAL = 1
	};
		
	//public static event Action< string > getAchievementNameEvent;
	
	void Start () {
		instance = this;
		jc2 = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
		jo = jc2.GetStatic<AndroidJavaObject> ("currentActivity"); 
		jo.Call("setObjectName", gameObject.name);
		
	}
	
	public void init(){
		jo.Call("init");
	}
	
	public void signIn(){
		jo.Call("signIn");
	}
	
	public void signOut(){ 
		jo.Call("_signOut");
	}
	
	public bool isConnected(){
		bool b = false;
		b = jo.Call<bool>("isConnected");
		return b;
	}
	
	public bool isConnecting(){
		bool b = false;
		b = jo.Call<bool>("isConnecting");
		return b;
	}
	
	public bool isSignedIn(){
		bool b = false;
		b = jo.Call<bool>("isSignedIn");
		return b;
	}
	
	//////////////////////////////////--------------------------////////////////////////////////////////////
	//////////////////////////////////-------Achievements-------////////////////////////////////////////////
	//////////////////////////////////--------------------------////////////////////////////////////////////
	
	public void unlockAchievement(string AchievementId){ //fires OnAchievementUnlock 
		
		if(AchievementId != null)
				jo.Call("unlockAchievement",AchievementId);
	}
	 
	public void incrementAchievement(string AchievementId,int numberOfIncrementSteps){ //fires OnAchievementIncrement
		
			if(AchievementId != null && numberOfIncrementSteps != null && numberOfIncrementSteps > 0)
				jo.Call("incrementAchievement", AchievementId, numberOfIncrementSteps);
			else if(AchievementId != null)
				jo.Call("incrementAchievement", AchievementId, 1);
	}
	
	public void displayAllAchievements(){
		jo.Call("displayAllAchievements");
	}
	
	public void revealAchievement(string AchievementId){
		jo.Call("revealAchievement", AchievementId);
	}
	
	//////////////////////////////////-----------------------------/////////////////////////////////////////
	//////////////////////////////////----Achievement Requests-----/////////////////////////////////////////
	//////////////////////////////////-----------------------------/////////////////////////////////////////
	
	
	//Fires receiveAchievementNameForId
	public void requestAchievementNameForId(string AchievementId){
		if(AchievementId != null && AchievementId != "")
			jo.Call("requestAchievementNameForId", AchievementId);
		else
			Debug.Log("Error: ID is empty");
			
	}
	//Fires receiveAchievementTotalStepsForId
	public void requestAchievementTotalStepsForId(string AchievementId){
		if(AchievementId != null && AchievementId != "")
			jo.Call("requestAchievementTotalStepsForId", AchievementId);
		else
			Debug.Log("Error: ID is empty");
			
	}
	//Fires receiveAchievementCurrentStepsForId
	public void requestAchievementCurrentStepsForId(string AchievementId){
		if(AchievementId != null && AchievementId != "")
			jo.Call("requestAchievementCurrentStepsForId", AchievementId);
		else
			Debug.Log("Error: ID is empty");
			
	}
	//Fires receiveAchievementTypeForId
	public void requestAchievementTypeForId(string AchievementId){
		if(AchievementId != null && AchievementId != "")
			jo.Call("requestAchievementTypeForId", AchievementId);
		else
			Debug.Log("Error: ID is empty");
			
	}
	//Fires receiveAchievementDescriptionForId
	public void requestAchievementDescriptionForId(string AchievementId){
		if(AchievementId != null && AchievementId != "")
			jo.Call("requestAchievementDescriptionForId", AchievementId);
		else
			Debug.Log("Error: ID is empty");
			
	}
	//Fires receiveAchievementStateForId
	public void requestAchievementStateForId(string AchievementId){
		if(AchievementId != null && AchievementId != "")
			jo.Call("requestAchievementStateForId", AchievementId);
		else
			Debug.Log("Error: ID is empty");
			
	}
			
			
	//////////////////////////////////--------------------------////////////////////////////////////////////
	//////////////////////////////////---------LeaderBoard------////////////////////////////////////////////
	//////////////////////////////////--------------------------////////////////////////////////////////////
	
	
	public void submitScore(string LEADERBOARD_ID, int score){		//Fires Action OnScoreSubmitted
		
		if(LEADERBOARD_ID != null && LEADERBOARD_ID != "")
			jo.Call("submitScore",LEADERBOARD_ID,score);
		else
			Debug.Log("Error: ID is empty");
	}
	
	public void displayLeaderboardForId(string LEADERBOARD_ID){
		if(LEADERBOARD_ID != null && LEADERBOARD_ID != "")
			jo.Call("displayLeaderboardForId",LEADERBOARD_ID);
		else
			Debug.Log("Error: ID is empty");
	}
	
	public void diaplayAllLeaderborads(){
		
			jo.Call("diaplayAllLeaderborads");
	}
	
	
	//////////////////////////////////-----------------------------/////////////////////////////////////////
	//////////////////////////////////----LeaderBoard Listeners----/////////////////////////////////////////
	//////////////////////////////////-----------------------------/////////////////////////////////////////
	
	/////////////////////////----LeaderBoard Metadata Loaded Listener ----//////////////////////////////////
	
	//fires receiveLeaderboardNameForId
	public void requestLeaderboardNameForId(string LeaderboardId) {
	
		if(LeaderboardId != null && LeaderboardId != "")
			jo.Call("requestLeaderboardNameForId", LeaderboardId);
		else
			Debug.Log("Error: ID is empty");
	}
	
	//fires receiveLeaderboardScoreOrderForId
	public void requestLeaderboardScoreOrderForId(string LeaderboardId) {
	
		if(LeaderboardId != null && LeaderboardId != "")
			jo.Call("requestLeaderboardScoreOrderForId", LeaderboardId);
		else
			Debug.Log("Error: ID is empty");
	}
	
	
	/////////////////////////----LeaderBoard Scores Loaded Listener ----/////////////////////////////////////
	
	
	 
	//fires receiveLeaderboardRawScoreForId
	public void requestLeaderboardRawScoreForId (string LeaderboardId, LeaderboardTimeSpan timeSpan , LeaderboardCollection collection ){
		if(LeaderboardId != null && LeaderboardId != "")
		{
			int ts = (int) timeSpan;
			int c = (int) collection;
			print(ts);
			print(c);
			
			jo.Call("requestLeaderboardRawScoreForId", LeaderboardId, ts, c);
		}
		else
			Debug.Log("Error: ID is empty");
	}
	
	//fires requestLeaderboardRankForId
	public void requestLeaderboardRankForId (string LeaderboardId, LeaderboardTimeSpan timeSpan , LeaderboardCollection collection ){
		
		if(LeaderboardId != null && LeaderboardId != "")
		{
			jo.Call("requestLeaderboardRankForId",LeaderboardId,  (int) timeSpan,  (int) collection);
		}
		else
			Debug.Log("Error: ID is empty");
	}
	
	//fires requestLeaderboardTimestampMillisForId
	public void requestLeaderboardTimestampMillisForId (string LeaderboardId, LeaderboardTimeSpan timeSpan , LeaderboardCollection collection ){
		if(LeaderboardId != null && LeaderboardId != "")
		{
			jo.Call("requestLeaderboardTimestampMillisForId", LeaderboardId, (int)timeSpan, (int)collection);
		}
		else
			Debug.Log("Error: ID is empty");
	}
	
	/////////////////////////////////////-----------------------////////////////////////////////////////////
	/////////////////////////////////////--------Getters--------////////////////////////////////////////////
	/////////////////////////////////////-----------------------////////////////////////////////////////////	
		
	public string getPlayerName(){
		string s = "";
		s = jo.Call<string>("getPlayerName");
		Debug.Log(s);
		return s;
	}
	
	public string getPlayerId(){
		string s = "";
		s = jo.Call<string>("getPlayerId");
		return s;
	}
	
	public int getAchievementTotalCount(){
		int i = 0;
		i = jo.Call<int>("getAchievementTotalCount");
		return i;
	}
	
	public string getGameApplicationId(){
		string s = "";
		s = jo.Call<string>("getGameApplicationId");
		return s;
	}
	
	public string getGameDescription(){
		string s = "";
		s = jo.Call<string>("getGameDescription");
		return s;
	}
	
	public string getGameDeveloperName(){
		string s = "";
		s = jo.Call<string>("getGameDeveloperName");
		return s;
	}
	
	public string getGameDisplayName(){
		string s = "";
		s = jo.Call<string>("getGameDisplayName");
		return s;
	}
	
	public string getGameInstancePackageName(){
		string s = "";
		s = jo.Call<string>("getGameInstancePackageName");
		return s;
	}
	
	public int getLeaderboardCount(){
		int i = 0;
		i = jo.Call<int>("getLeaderboardCount");
		return i;
	}
	
	public string getGamePrimaryCategory(){
		string s = "";
		s = jo.Call<string>("getGamePrimaryCategory");
		return s;
	}
	
	public string getGameSecondaryCategory(){
		string s = "";
		s = jo.Call<string>("getGameSecondaryCategory");
		return s;
	}	
	
	
	
	
	
	
	/*
	public void getAchievementName(string val) 
	{
		if( getAchievementNameEvent != null )
		{
			getAchievementNameEvent( val );
		}
		Log.d( "getAchievementName " + val );
	}
	*/
	
}
