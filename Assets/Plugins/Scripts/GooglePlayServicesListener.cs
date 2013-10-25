using UnityEngine;
using System.Collections;
using System;

public class GooglePlayServicesListener : MonoBehaviour {
	
	GooglePlayServicesListener instance;
	
	public enum AppStateClient: int { 
		STATUS_CLIENT_RECONNECT_REQUIRED = 2, 
		STATUS_DEVELOPER_ERROR = 7, 
		STATUS_INTERNAL_ERROR = 1, 
		STATUS_NETWORK_ERROR_NO_DATA = 4,
		STATUS_NETWORK_ERROR_OPERATION_DEFERRED = 5, 
		STATUS_NETWORK_ERROR_OPERATION_FAILED = 6, 
		STATUS_NETWORK_ERROR_STALE_DATA = 3,
		STATUS_OK = 0, 
		STATUS_STATE_KEY_LIMIT_EXCEEDED = 2003, 
		STATUS_STATE_KEY_NOT_FOUND = 2002, 
		STATUS_WRITE_OUT_OF_DATE_VERSION = 2000,
		STATUS_WRITE_SIZE_EXCEEDED = 2001	
	};
	
	public enum AchievementType: int {
		TYPE_INCREMENTAL = 1,
		TYPE_STANDARD = 0,
		TYPE_ERROR = -1
	};
	
	public enum AchievementState: int {
		STATE_HIDDEN = 2,
		STATE_REVEALED = 1,
		STATE_UNLOCKED = 0,
		STATE_ERROR = -1
	};
	
	
	
	public enum gamesClientStatus: int {
		STATUS_OK = 0,
		STATUS_NETWORK_ERROR_OPERATION_DEFERRED = 5,
		STATUS_CLIENT_RECONNECT_REQUIRED = 2,
		STATUS_LICENSE_CHECK_FAILED = 7,
		STATUS_INTERNAL_ERROR = 1
	};
	
	
	#if UNITY_ANDROID
	
	public static event Action < int, string > OnAchievementIncrementEvent;	
	public static event Action < int, string > OnAchievementUnlockEvent;
	public static event Action onSignInFailedEvent;	
	public static event Action onSignInSucceededEvent;	
	public static event Action < string > receiveAchievementNameForIdEvent;
	public static event Action < int > receiveAchievementTotalStepsForIdEvent;
	public static event Action < int > receiveAchievementCurrentStepsForIdEvent;
	public static event Action < int > receiveAchievementTypeForIdEvent;
	public static event Action < string > receiveAchievementDescriptionForIdEvent;
	public static event Action < int > receiveAchievementStateForIdEvent;
	public static event Action < int, string > OnScoreSubmittedEvent;
	public static event Action < string > receiveLeaderboardNameEvent;
	public static event Action < int > receiveLeaderboardScoreOrderForIdEvent;
	public static event Action < long >receiveLeaderboardRawScoreForIdEvent;
	public static event Action < long >receiveLeaderboardRankForIdEvent;
	public static event Action < long >receiveLeaderboardTimestampMillisForIdEvent;
	
	
	
	// Use this for initialization
	void Start () {
		instance = this;
	
	}
	
	
	public void OnAchievementIncrement( string val ) //done
	{
		string[] s = val.Split('^');
		
		
		int statusCode = int.Parse(s[0]);
		string achievementId = s[1];
		
		if( OnAchievementIncrementEvent != null )
		{
			OnAchievementIncrementEvent( statusCode, achievementId );
		}

		Debug.Log( "OnAchievementIncrementListener " + statusCode.ToString() + achievementId );
	}
	
	
	public void OnAchievementUnlock( string val )	//done
	{
		string[] s = val.Split('^');
		
		
		int statusCode = int.Parse(s[0]);
		string achievementId = s[1];
		
		//if(statusCode == AppStateClient.STATUS_OK)
		//{}
		
		if( OnAchievementUnlockEvent != null )
		{
			OnAchievementUnlockEvent( statusCode, achievementId );
		}

		Debug.Log( "OnAchievementUnlock " + statusCode.ToString() + achievementId );
	}
	
	public void onSignInFailed(string empty)	//
	{
		
		if( onSignInFailedEvent != null )
		{
			onSignInFailedEvent( );
		}

		Debug.Log( "onSignInFailed");
	}
	
	public void onSignInSucceeded(string empty)	//done
	{
		
		if( onSignInSucceededEvent != null )
		{
			onSignInSucceededEvent();
		}
		
		Debug.Log( "onSignInSucceeded" );
	}
	
	public string receiveAchievementNameForId (string name) //done
	{

		if(name != "")
		{
			if( receiveAchievementNameForIdEvent != null )
			{
				receiveAchievementNameForIdEvent(name);
			}
			Debug.Log( "receiveAchievementNameForId " + name );
			return name;
		}
		
		Debug.Log("Error");
		return "";
		
	}
	public int receiveAchievementTotalStepsForId (string val) //done
	{
		int totalSteps = int.Parse(val);

		if(totalSteps != -1)
		{
			if( receiveAchievementTotalStepsForIdEvent != null )
			{
				receiveAchievementTotalStepsForIdEvent(totalSteps);
			}
			Debug.Log( "receiveAchievementTotalStepsForId " + totalSteps.ToString() );
			return totalSteps;
		}
		
		Debug.Log("Error");
		return -1;
		
	}
	public int receiveAchievementCurrentStepsForId (string val) //done
	{
		int currentSteps = int.Parse(val);

		if(currentSteps != -1)
		{
			if( receiveAchievementCurrentStepsForIdEvent != null )
			{
				receiveAchievementCurrentStepsForIdEvent(currentSteps);
			}
			Debug.Log( "receiveAchievementCurrentStepsForId " + currentSteps.ToString() );
			return currentSteps;
		}
		
		Debug.Log("Error");
		return -1;

		
	}
	public int receiveAchievementTypeForId (string val) //done
	{
		int type = int.Parse(val);
		
		if(type != (int) AchievementType.TYPE_ERROR)
		{
			if( receiveAchievementTypeForIdEvent != null )
			{
				receiveAchievementTypeForIdEvent(type);
			}
			Debug.Log( "receiveAchievementTypeForId " + type.ToString() );
			return type;
		}
		
		Debug.Log("Error");
		return -1;
	}
	public string receiveAchievementDescriptionForId (string description) //done
	{
		if(description != "")
		{
			if( receiveAchievementDescriptionForIdEvent != null )
			{
				receiveAchievementDescriptionForIdEvent(description);
			}
			Debug.Log( "receiveAchievementDescriptionForId " + description);
			return description;
		}
		
		Debug.Log("Error");
		return "";
		
	}
	public int receiveAchievementStateForId (string val) //done
	{
		int state = int.Parse(val);
		
		if(state != (int) AchievementState.STATE_ERROR )
		{
			if( receiveAchievementStateForIdEvent != null )
			{
				receiveAchievementStateForIdEvent(state);
			}
			Debug.Log( "receiveAchievementStateForId " + state.ToString() );
			return state;
		}
		
		Debug.Log("Error");
		return -1;
		
	}
	
	
	/// <summary>
	/// Raises the score submitted event.
	/// </summary>
	/// <param name='val'>
	/// Value.
	/// </param>
	/// 
	/// 
	public void OnScoreSubmitted( string val ) //done
	{
		string[] s = val.Split('^');
		
		
		int statusCode = int.Parse(s[0]);
		string leaderboardId = s[1];
		
		if( OnScoreSubmittedEvent != null )
		{
			OnScoreSubmittedEvent( statusCode, leaderboardId );
		}

		Debug.Log( "leaderboardId " + val );
	}
	
	public void receiveLeaderboardNameForId( string name ) //done
	{
		if(name != "")
		{
			if(receiveLeaderboardNameEvent != null )
			{
				receiveLeaderboardNameEvent( name);
			}
			Debug.Log( "receiveLeaderboardName " + name );
		}
		else
			Debug.Log( "Error");
	}
	
	public void receiveLeaderboardScoreOrderForId( string val ) //done
	{
		int scoreOrder = int.Parse(val);
		if(scoreOrder != -1)
		{
			if(receiveLeaderboardScoreOrderForIdEvent != null )
			{
				receiveLeaderboardScoreOrderForIdEvent( scoreOrder);
			}
			Debug.Log( "receiveLeaderboardScoreOrderForId " + scoreOrder.ToString() );
		}
		else
			Debug.Log( "Error");
	}
	
	public void receiveLeaderboardRawScoreForId( string val ) //done
	{
		long rawScore = long.Parse(val);
		if(rawScore != -1)
		{
			if(receiveLeaderboardRawScoreForIdEvent != null )
			{
				receiveLeaderboardRawScoreForIdEvent( rawScore);
			}
			Debug.Log( "receiveLeaderboardRawScoreForId " + rawScore.ToString() );
		}
		else
			Debug.Log( "Error");
	}
	
	public void receiveLeaderboardRankForId( string val )	//done
	{
		long rank = long.Parse(val);
		if(rank != -1)
		{
			if(receiveLeaderboardRankForIdEvent != null )
			{
				receiveLeaderboardRankForIdEvent(rank);
			}
			Debug.Log( "receiveLeaderboardRankForId " + rank.ToString() );
		}
		else
			Debug.Log( "Error");
	}
	
	public void receiveLeaderboardTimestampMillisForId( string val )	//done
	{
		long timestampMillis = long.Parse(val);
		if(timestampMillis != -1)
		{
			if(receiveLeaderboardTimestampMillisForIdEvent != null )
			{
				receiveLeaderboardTimestampMillisForIdEvent(timestampMillis);
			}
			Debug.Log( "receiveLeaderboardRankForId " + timestampMillis.ToString() );
		}
		else
			Debug.Log( "Error");
	}
	#endif
	
}
