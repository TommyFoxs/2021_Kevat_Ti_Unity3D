using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float juoksuNopeus = 3.5f;
    public float hiirenNopeus = 3f;
    public float hyppyNopeus = 100f;
    public float painovoima = 10f;

    private float vetikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;

    private Vector3 liikesuunta = Vector3.zero;


    //string sana = "moi";
    //string on sana tai kirjaimia
    //integer on numero mikä ei mene desimaaleihin
    //float on numero mikä menee desimaaleihin



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vetikaalinenPyorinta -= Input.GetAxis("Mouse Y") * hiirenNopeus;
        Camera.main.transform.localRotation = Quaternion.Euler(vetikaalinenPyorinta, horisontaalinenPyorinta, 0);
    }

    //Runs with the physics motor same as Update.
    void FixedUpdate()
    {


    }


}
