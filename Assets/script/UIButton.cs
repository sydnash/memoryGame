using UnityEngine;
using System.Collections;

public class UIButton : MonoBehaviour {
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private string targetMessage;
    public Color hightlightColor = Color.cyan;
    private SpriteRenderer _sprite;
	// Use this for initialization
	void Start () {
        _sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseOver()
    {
        _sprite.color = hightlightColor;
    }
    public void OnMouseExit()
    {
        _sprite.color = Color.white;
    }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if (targetObject != null )
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
