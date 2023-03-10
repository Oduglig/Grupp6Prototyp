using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
   public static MusicManager Instance;

   //Bankladdare
   private void Awake()
   {
      /*if (Instance == null)
         Instance = this;
      else
      {
         Destroy(gameObject);
         return;
      }*/
      
      BankLoader();
      if (Instance != null && Instance != this)
      {
         Destroy(this);
      }
      else
      {
         Instance = this;
      }
      DontDestroyOnLoad(gameObject);
   }
   
   

   [Header("BankRef")] 
   [BankRef] public string masterBank;

   public bool loadSampleData;

   private void BankLoader()
   {
      //Debug.Log("Has the bank loaded? " + RuntimeManager.HasBankLoaded(masterBank));
      RuntimeManager.LoadBank(masterBank, loadSampleData);
   }

   
   //Emitters för bakgrundsmusik
   private StudioEventEmitter sEmitter;
   private float number = 1;
   
   [Header("BGM")] 
   public Emitters eventEmitters;
   
   [System.Serializable]
   
   public struct Emitters
   {
      public StudioEventEmitter bgm1Music;
      public StudioEventEmitter mainMenuMusic;
      public StudioEventEmitter safeRoomMusic;
   }

  /* [Header("Puzzle")] 
   [SerializeField] private EventReference puzzleStinger;

   [SerializeField] private EventReference puzzleComplete;*/

  /* [SerializeField] private string puzzleParamName;
   [SerializeField] private float puzzleParamValue;

   public void PlayPuzzleProgress()
   {
      RuntimeManager.PlayOneShot(puzzleStinger);
   }

   public void PlayPuzzleComplete()
   {
      RuntimeManager.PlayOneShot(puzzleComplete);
   }
*/

  /*  //Styr stinger för när man dör
    [Header("GameOver")] 
    [SerializeField] private EventReference gameOverStinger;
    
    public void PlayGameOver()
    {
       RuntimeManager.PlayOneShot(gameOverStinger);
    }
    //Koppla till "Game Over" */

  /*
   //Styr Combatmusiken
   private bool inCombat = false;
   [Header("Combat")] 
   public float combatWaitTime = 3f;

   [SerializeField] private string combatParamName;
   [SerializeField] private float combatParamValue = 0f;

   public void Combat()
   {
      if (!inCombat)
      {
         Debug.Log("Fight MothaFocka!");
         RuntimeManager.StudioSystem.setParameterByName("Combat", 1);
      }
   }*/
  
 
   //Play, Stop, Parameter

   private PARAMETER_ID parameterID;
   public void Play(StudioEventEmitter emitter)
   {
      if (emitter.IsActive == false)
      {
         emitter.Play();
      }
      else
      {
         Debug.Log("Already playing!");
      }
   }

   public void Stop(StudioEventEmitter emitter)
   {
      emitter.Stop();
      Debug.Log("Shut up!");
   }

   public void SetParameter(StudioEventEmitter emitter, string paramName, float paramValue, bool ignorSeek)
   {
      RuntimeManager.StudioSystem.setParameterByName(paramName, paramValue, ignorSeek);
      Debug.Log("Setting parameter.");
   }
}
