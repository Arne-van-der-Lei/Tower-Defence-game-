using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {
    public GameObject display;

    public int Display { set { _Text.text = value + ""; } }
    public int Penalty = 1;
    public Vector3 pos;

    [SerializeField]
    private Text _Text;

    public void OnUpgrade()
    {
        GameEntity entity = gameObject.GetEntityLink().entity as GameEntity;

        entity.isTowerUpgrade = true;
    }

    public void OnDelete()
    {
        GameEntity entity = gameObject.GetEntityLink().entity as GameEntity;

        entity.isTowerDelete = true;
    }
}
