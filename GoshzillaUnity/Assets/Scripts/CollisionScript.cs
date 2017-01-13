using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour {

    //add this script to goshzilla, put some code for movement.

    private Rigidbody rb;
    private int buildingCount;
    private int peopleCount;
    private int carCount;
    private int casualtyCount;
    private Vector3 distance;
    private Vector3 originalDistance;

    public int speed;
    public Text buildingsDestroyed;
    public Text peopleKilled;
    public Text carsDestroyed;
    public Text casualty;
    public Text distanceTravelled;
    public Text winText;
    
    void Start()
    {
        buildingCount = 0;
        peopleCount = 0;
        carCount = 0;
        originalDistance = transform.position;
    
        rb = GetComponent<Rigidbody>();

        buildingsDestroyed.text = "Buildings Destroyed: 0";
        peopleKilled.text = "Innocent People Trampled: 0";
        carsDestroyed.text = "Cars Destroyed: 0";
        casualty.text = "Casualties: 0";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            Destroy(other.gameObject);
            buildingCount += 1;
            updateScores(1);
        }
        else if (other.gameObject.CompareTag("People"))
        {
            Destroy(other.gameObject);
            peopleCount += 1;
            updateScores(2);
        }
        else if (other.gameObject.CompareTag("Car"))
        {
            Destroy(other.gameObject);
            carCount += 1;
            updateScores(3);
        }
        else if (other.gameObject.CompareTag("City Element"))
        {

        }
        else if (other.gameObject.CompareTag("Tree")) //TEMP TAG FOR END POINT
        {
            if (casualtyCount <= 500)
            {
                winText.text = "You win!";
            }
            else
            {
                winText.text = "Goshzilla, you lose!";
            }
        }
    }
    void Update()
    {
        distance = transform.position - originalDistance;
        distanceTravelled.text = "Distance Travelled: " + Mathf.Round(distance.sqrMagnitude).ToString();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    void updateScores(int type)
    {
        switch (type)
        {
            case 1:
                buildingsDestroyed.text = "Buildings Destroyed: " + buildingCount.ToString();
                break;
            case 2:
                peopleKilled.text = "Innocent People Trampled: " + peopleCount.ToString();
                break;
            case 3:
                carsDestroyed.text = "Cars Destroyed: " + carCount.ToString();
                break;
            
        }
        casualtyCount = buildingCount * 100 + peopleCount + carCount * 4;
        casualty.text = "Casualties: " + casualtyCount.ToString();

    }
}
