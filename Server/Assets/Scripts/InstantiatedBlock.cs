﻿using UnityEngine;
using System.Collections;

public class InstantiatedBlock : Block {

	NetworkViewID _NetworkViewID;
<<<<<<< HEAD
	//Vector3 _Location;
    private GameObject _Block;

	public InstantiatedBlock(NetworkViewID networkViewID) : base(){
		_NetworkViewID = networkViewID;
        _Block = NetworkView.Find(_NetworkViewID).gameObject;
	}

    public InstantiatedBlock(GameObject block) :base() {
        _Block = block;
    }



	public void SetLocation(Vector3 location) {
		_Block.transform.position = location;
	}

	public Vector3 GetLocation() {
		return _Block.transform.position;
=======
	Vector3 _Location;


	public InstantiatedBlock(NetworkViewID networkViewID) : base(){
		_NetworkViewID = networkViewID;
	}

	public void SetLocation(Vector3 location) {
		_Location = location;
	}

	public Vector3 GetLocation() {
		return _Location;
>>>>>>> 505cab0c1b03405b9bb5caa0a05db20c3762f808
	}

	public NetworkViewID GetNetworkViewID() {
		return _NetworkViewID;
	}

}
