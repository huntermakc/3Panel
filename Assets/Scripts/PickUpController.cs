using UnityEngine;

public class PickUpController : MonoBehaviour {

    public float zPos;
    public int colorCode;

    Vector3 pos;

    Renderer rend;

    Color[] colors;

    Shader thishader;

    GameObject mainCubeController;

    void Start ()
    {
        Destroy(gameObject, 7f);
        
        pos = new Vector3(0f, 0f, zPos);
        colorCode = Random.Range(0, 4);

        colors = new Color[] { Color.green, Color.red, Color.blue, Color.white };

        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color",colors[colorCode]);

        switch (colorCode)
        {
            case 0:
                gameObject.tag = "0";
                break;
            case 1:
                gameObject.tag = "1";
                break;
            case 2:
                gameObject.tag = "2";
                break;
            case 3:
                gameObject.tag = "3";
                break;
            default:
                Debug.Log("Error. Tag null");
                break;
        }

    }
	
	
	void Update ()
    {
        transform.Translate(pos);
        if (!GameController.gameStart)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==gameObject.tag)
        {
            GameController.ScoreUp(1,0);
            Destroy(gameObject);
        }
        else
        {
            GameController.ScoreUp(0,-1);
            Destroy(gameObject);
        }

        
    }
}
