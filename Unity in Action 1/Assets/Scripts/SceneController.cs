using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enermyPrefab;
    private GameObject _enermy;

	void Update ()
    {
	    if(_enermy == null)
        {
            _enermy = Instantiate(enermyPrefab) as GameObject;
            _enermy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enermy.transform.Rotate(0, angle, 0);
        }	
	}
}
