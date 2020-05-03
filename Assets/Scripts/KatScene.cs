using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatScene : MonoBehaviour
{
	public GameObject closeVideo, startPanel, video;
	public float offsetVideo, offsetButton;

	private void Start()
	{
		startPanel.SetActive(true);
		video.SetActive(false);
		closeVideo.SetActive(false);
		StartCoroutine(OffsetVideo(offsetVideo));
		StartCoroutine(OffsetButton(offsetButton));
	}

	private void Update()
	{

	}


	private IEnumerator OffsetVideo(float offsett)
	{
		yield return new WaitForSeconds(offsett);
		video.SetActive(true);
		startPanel.SetActive(false);
		
	}

	private IEnumerator OffsetButton(float offsett)
	{
		offsett += offsetButton;
		yield return new WaitForSeconds(offsett);
		video.SetActive(false); 
		closeVideo.SetActive(true);
	}
}
