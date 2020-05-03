using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject pickUpPanel;
    public GameObject[] itemList;
    public bool[] full;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
    }
    public void Pickup()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            if (hit.transform.tag == "Item")
            {
                pickUpPanel.SetActive(true);

                if (Input.GetButtonDown("Pickup"))
                {
                    hit.collider.gameObject.SetActive(false);
                    print(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<EngergyboxScript>().image.SetActive(true);
                    hit.collider.gameObject.GetComponent<PhoneScript>().image.SetActive(true);
                }
            }
        }

        else
        {
            pickUpPanel.SetActive(false);
        }
    }
}
