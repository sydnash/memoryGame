using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {
    [SerializeField]
    private GameObject cardBack;
    [SerializeField]
    private SceneController controller;
    private int _id;
    public int id
    {
        get { return _id; }
    }
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseDown()
    {
        Debug.Log("testing 1 2 3");
        if (!controller.isCanClicked)
        {
            return;
        }
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }
    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}
