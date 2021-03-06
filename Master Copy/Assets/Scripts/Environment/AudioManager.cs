﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
	private List<AudioSource> sources = new List<AudioSource>();

	public static AudioManager instance;

	public static AudioManager Instance{
		get {
			return instance;
		}
	}
	public float volumeSnd;

	[SerializeField] private AudioClip BGMRest;
	[SerializeField] private AudioClip BGMMainMenu;
	[SerializeField] private AudioClip BGMDesert;
	[SerializeField] private AudioClip BGMSpaceShip;

	[SerializeField] private AudioClip BGMBoss;

	[SerializeField] private AudioClip BlasterShot;
	[SerializeField] private AudioClip DroneDeath;
	[SerializeField] private AudioClip DroneShot;
	[SerializeField] private AudioClip reloadBlaster;
	[SerializeField] private AudioClip reloadPistol;
	[SerializeField] private AudioClip reloadGLaunch;
	[SerializeField] private AudioClip GangsterLauncher;
	[SerializeField] private AudioClip PistolGripPump;
	[SerializeField] private AudioClip shell;
	[SerializeField] private AudioClip PlayerWalking;
	[SerializeField] private AudioClip BossWalking;
	[SerializeField] private AudioClip BossStomp;
	[SerializeField] private AudioClip BossLaser;
	[SerializeField] private AudioClip TurretTransform;
	[SerializeField] private AudioClip TurretShoot;
	[SerializeField] private AudioClip chainsaw;

	private AudioSource bgm;

	public void PlayBGM (AudioClip clip){
		Debug.Log ("playing new bgm");
		bgm.clip = clip;
		bgm.Play ();
	}

	public void PlayBossBGM(){
		bgm.clip = BGMBoss;
		bgm.Play ();
	}

	public void PlayBlasterShot(){
		PlaySound (BlasterShot);
	}
	public void PlayDroneDeath(){
		PlaySound (DroneDeath);
	}
	public void PlayDroneShot(){
		PlaySound (DroneShot);
	}
	public void PlayReloadBlaster(){
		PlaySound (reloadBlaster);
	}
	public void PlayReloadPistol(){
		PlaySound (reloadPistol);
	}
	public void PlayReloadGLaunch(){
		PlaySound (reloadGLaunch);
	}
	public void PlayGangsterLauncher(){
		PlaySound (GangsterLauncher);
	}
	public void PlayPistolGripPump(){
		PlaySound (PistolGripPump);
	}
	public void PlayShell(){
		PlaySound (shell);
	}
	public void PlayPlayerWalking(){
		PlaySound (PlayerWalking);
	}
	public void PlayBossWalking(){
		PlaySound (BossWalking);
	}
	public void PlayBossStomp(){
		PlaySound(BossStomp);
	}
	public void PlayBossLaser(){
		PlaySound (BossLaser);
	}
	public void PlayTurretTransform(){
		PlaySound (TurretTransform);
	}
	public void PlayTurretShoot(){
		PlaySound (TurretShoot);
	}
	public void PlayChainsaw(){
		PlaySound (chainsaw);
	}


	void Awake()
	{
		if (instance !=null)
		{
			if (instance != this)
			{
				Destroy (this.gameObject);
			}
		}
		else
		{
			instance= this;
			DontDestroyOnLoad(this);
		}
		bgm = transform.FindChild ("AudioBGM").GetComponent<AudioSource> ();
		bgm.loop = true;
	}
		
	void OnLevelWasLoaded(int l){
		
		if (l == 0 || l == 1 || l == 5)//main menu
			PlayBGM (BGMMainMenu);
		if (l == 3)
		{
			PlayBGM (BGMSpaceShip);
		}
		if (l == 2) //rest
		{
			PlayBGM (BGMRest);
		}
		if (l == 4)
		{
			PlayBGM (BGMDesert);
		}
	}

	public void PlaySound(AudioClip clip)
	{
		AudioSource source = GetAudioSource ();
		source.clip = clip;
		source.volume = volumeSnd;
		source.Play ();
	}

	private AudioSource GetAudioSource(){
		AudioSource source = this.gameObject.GetComponent<AudioSource> ();
		if (source == null)
		{
			source = this.gameObject.AddComponent<AudioSource> ();
			this.sources.Add(source);
		}
		return source;
	}

	[SerializeField] private int maxAudioSourceCount = 20;

	private AudioSource GetAvailableSource(){
		if (this.sources == null) {
			this.sources = new List<AudioSource> ();
		}

		if (this.sources.Count == 0) {
			AudioSource firstSource = this.gameObject.AddComponent<AudioSource> ();
			this.sources.Add (firstSource);
		}

		for (int i = 0; i < this.sources.Count; i++) {
			AudioSource source = this.sources [i];
			if (source.isPlaying == false) {
				return source;
			}
		}
		if (this.sources.Count < this.maxAudioSourceCount) {
			AudioSource newSource = this.gameObject.AddComponent<AudioSource> ();
			this.sources.Add (newSource);
			return newSource;
		}
		return null;
	}
				
}