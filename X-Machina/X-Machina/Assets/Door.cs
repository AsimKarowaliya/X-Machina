using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject actionTips;
    private GameObject at;
    private Vector3 tipPos;

    // Start is called before the first frame update
    private void Start()
    {
        tipPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        at = Instantiate(actionTips, tipPos, transform.rotation);
        at.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            at.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            if (Input.GetKeyDown(KeyCode.O))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            at.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.0f);
        }
    }
}
