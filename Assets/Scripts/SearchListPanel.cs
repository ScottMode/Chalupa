﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class SearchListPanel : MonoBehaviour
{
	public GameObject roomBtnPrefab;

	public MainMenu main;

	public List<string> matchNames = new List<string>();

	void OnDisable()
	{
		for(int i = 0; i < transform.childCount; ++i)
		{
			Destroy(transform.GetChild(i).gameObject, 0.1f);
		}
	}

	public void Setup(List<MatchInfoSnapshot> matches)
	{
		foreach(MatchInfoSnapshot match in matches)
		{
			if (!matchNames.Contains (match.name)) 
			{
				GameObject newMatch = (GameObject)Instantiate (roomBtnPrefab, transform);

				roomInfo room = newMatch.GetComponent<roomInfo> ();

				room.label.text = match.name;
				room.info = match;

				newMatch.transform.localScale = Vector3.one;
				newMatch.transform.localPosition = Vector3.zero;

				matchNames.Add (match.name);
			}
		}
	}

	public void JoinGame(MatchInfoSnapshot info)
	{
		main.JoinGame(info);

		gameObject.SetActive(false);
	}
}