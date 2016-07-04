using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
    [SerializeField]
    private MemoryCard originalCard;
    [SerializeField]
    private Sprite[] images;
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    private MemoryCard _firstCard;
    private MemoryCard _secondCard;
    private int _score;
    private bool _isCanClicked = true;
    private TextMesh _text;
    public bool isCanClicked
    {
        get { return _isCanClicked; }
    }
    public int score
    {
        get { return _score; }
    }
    public bool canReveal
    {
        get { return _secondCard == null; }
    }
    public void CardRevealed(MemoryCard card)
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        } else
        {
            _secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }
    private IEnumerator CheckMatch()
    {
        _isCanClicked = false;
        if (_firstCard.id == _secondCard.id)
        {
            _score++;
            _text.text = "score:" + _score;
        } else
        {
            yield return new WaitForSeconds(.5f);
            _firstCard.Unreveal();
            _secondCard.Unreveal();
        }
        _firstCard = null;
        _secondCard = null;
        _isCanClicked = true;
    }
	// Use this for initialization
    private void Restart()
    {
        //Application.LoadLevel("s1");
        UnityEngine.SceneManagement.SceneManager.LoadScene("s1");
    }
	void Start () {
        _text = GetComponent<TextMesh>();
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; ++i)
        {
            for (int j = 0; j < gridRows; ++j)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                } else {
                    card = Instantiate(originalCard) as MemoryCard;
                }
                int idx = j * gridCols + i;
                int id = numbers[idx];// Random.Range(0, images.Length);
                card.SetCard(id, images[id]);

                float posx = i * offsetX + startPos.x;
                float posy = -j * offsetY + startPos.y;
                card.transform.position = new Vector3(posx, posy, startPos.z);
            }
        } 
	}
	private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; ++i)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
