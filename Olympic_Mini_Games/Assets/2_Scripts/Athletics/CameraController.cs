using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
#pragma warning disable 0649
	[SerializeField]
	Vector3 _offSet = Vector3.zero;
	[SerializeField]
	float _followSpeed = 2.5f;
#pragma warning restore

	GameObject _playerObj;

	private void Start()
	{
		_playerObj = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
        Vector3 target = _playerObj.transform.position + _offSet;
        transform.position = Vector3.Lerp(transform.position, target, _followSpeed * Time.deltaTime);
    }
}
