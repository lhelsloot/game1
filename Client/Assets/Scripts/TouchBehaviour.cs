﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TouchBehaviour : MonoBehaviour 
{
	
	//public GameObject parentObject;
	public GameObject cubePrefab;
	public GameObject cubeFinger;
	private float maxPickingDistance = 200000;// increase if needed, depending on your scene size
	private readonly double lowerBoundary = 0.4999;
	private readonly double upperBoundary = 0.5001;
	
	private Transform pickedObject = null;

	//move object to vector distance from localObject in the localObjects own space
	Vector3 CalculateSide(Transform localObject, RaycastHit hit){
		Vector3 res = localObject.position;

		//bring the vector into the movedObjects own localspace
		Vector3 localizedVector = localObject.InverseTransformPoint (hit.point);
		
		Debug.Log (localizedVector);

		//the localizedvector ranges represent the sides of a square (if x=0.5, it half the distance of a square from the center of the square to the x dimension. so it hits the x side of the square)
		if (localizedVector.x >lowerBoundary && localizedVector.x<upperBoundary) {
			res = localObject.TransformPoint(new Vector3(1,0,0));
			Debug.Log("Right");
		}
		if (localizedVector.y >lowerBoundary && localizedVector.y<upperBoundary) {
			res = localObject.TransformPoint(new Vector3(0,1,0));
			Debug.Log("Above");
		}
		if (localizedVector.z >lowerBoundary && localizedVector.z<upperBoundary) {
			res = localObject.TransformPoint(new Vector3(0,0,1));
			Debug.Log("In Front");
		}
		if (localizedVector.x <-lowerBoundary && localizedVector.x>-upperBoundary) {
			res = localObject.TransformPoint(new Vector3(-1,0,0));
			Debug.Log("Left");
		}
		if (localizedVector.y <-lowerBoundary && localizedVector.y>-upperBoundary) {
			res = localObject.TransformPoint(new Vector3(0,-1,0));
			Debug.Log("Below");
		}
		if (localizedVector.z <-lowerBoundary && localizedVector.z>-upperBoundary) {
			res = localObject.TransformPoint(new Vector3(0,0,-1));
			Debug.Log("Behind");
		}
		
		return res;
	}

	//places a square at the exact coordinates of the cubefinger
	void PlaceSquareAtFinger(){
		this.networkView.RPC ("PlaceBlock", RPCMode.Server, cubeFinger.transform.position);
	}

	// Update is called once per frame
	void Update () 
	{
		//send a ray from the center of the screen to the object
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hit = new RaycastHit();
		//if the ray hits the object, then do stuff
		if (Physics.Raycast(ray, out hit, maxPickingDistance)) 
		{ 
			//retrieve the object that was hit
			pickedObject = hit.transform;
			cubeFinger.transform.position = CalculateSide(pickedObject, hit);
			cubeFinger.transform.localScale = pickedObject.localScale;
			cubeFinger.SetActive(true);
			//if a build action is given, place the block at the cubefinger location
			if (Input.GetMouseButtonDown (0) && cubeFinger.activeInHierarchy) {
				PlaceSquareAtFinger();
				//disable cubefinger, so it is placed in it s shiny new good position on next update
				cubeFinger.SetActive(false);
			}

		} 
		else
		{
			//if the trace did not hit anything, there is no sense in having a cubefinger enabled
			cubeFinger.SetActive(false);
			pickedObject = null;
		}
	}
	[RPC]
	BlockError PlaceBlock(Vector3 location){
		return null;
	}

}