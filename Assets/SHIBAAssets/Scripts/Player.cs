using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int PlayerNo;
    bool[] Button = new bool[2];

    int InputInfo = -1;

	public float speed = 0.3f;
	public float RotSpeed = 3.0f;
	private int Dust	= 0;
	// Use this for initialization
	// Update is called once per frame
	void Update ()
	{
        InputInfo = -1;

        if (Manager.GetIsControll)
        {
            if (PlayerNo != 0)
            {
                Button[0] = Controller.GetButtonState(0);
                Button[1] = Controller.GetButtonState(1);
            }
            else
            {
                Button[0] = Controller.GetButtonState(2);
                Button[1] = Controller.GetButtonState(3);
            }
        }


        if (Button[0])
        {
            InputInfo = 0;
        }
        if (Button[1])
        {
            InputInfo = 1;
        }
        if (Button[0] && Button[1])
        {
            InputInfo = 2;
        }


        switch (InputInfo)
        {
            case 0:
                transform.Rotate(new Vector3(0, 0, 1) * RotSpeed);
                break;
            case 1:
                transform.Rotate(new Vector3(0, 0, 1) * -RotSpeed);
                break;
            case 2:
                float angleDir = transform.localEulerAngles.z * (Mathf.PI/180.0f);
			    Vector3 dir = new Vector3(Mathf.Cos(angleDir), Mathf.Sin(angleDir), 0.0f);
                if (PlayerNo != 0)
                {
                    transform.position += dir * speed * Time.deltaTime;
                }
                else
                {
                    transform.position -= dir * speed * Time.deltaTime;
                }

                break;
        }
        



        /*
		// Left, Right
		float x = Input.GetAxisRaw ("Horizontal");
		if (x == -1) {
			transform.Rotate (new Vector3 (0, 0, 1) * RotSpeed);
		} else if (x == 1) {
			transform.Rotate (new Vector3 (0, 0, 1) * -RotSpeed);
		}
		float y = Input.GetAxisRaw ("Vertical");
		if (y == 1) {
			float angleDir = transform.localEulerAngles.z * (Mathf.PI/180.0f);
			Vector3 dir = new Vector3(Mathf.Cos(angleDir), Mathf.Sin(angleDir), 0.0f);
			transform.position += dir * speed * Time.deltaTime;
		}*/
	}
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Dust")
		{
			Dust += 1;
			Destroy (c.gameObject);
		}
	}
}
