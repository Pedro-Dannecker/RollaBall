using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementvalue){

        Vector2 movementvector = movementvalue.Get<Vector2>();

        movementX = movementvector.x;
        movementY = movementvector.y;

    }

    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 13) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
                    Invoke("Initial",2);
		}
	}

    void Initial(){
        SceneManager.LoadScene(0);
    }

    void FixedUpdate(){
        Vector3 movement =  new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count = count + 1; 
            SetCountText();


        }
        
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
