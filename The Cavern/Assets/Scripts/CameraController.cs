using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public CameraHelper cameraHelper;
	public float movespeed ;
    public GameObject target;
    public Vector3 offset;



    void Update()
	{

		Vector3 moveDir = (new Vector3 (target.transform.position.x + offset.x, target.transform.position.y + offset.y, target.transform.position.z) - cameraHelper.getCameraPos()).normalized;
		cameraHelper.Move(moveDir * movespeed * Time.deltaTime);
	}
		
	}



