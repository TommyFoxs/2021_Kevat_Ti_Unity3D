using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hiirenNopeus = 3f;
    public float juoksuNopeus = 10f;
    public float hyppyNopeus = 100f;
    public float painovoima = 10f;

    public CursorLockMode haluttuMoodi;

    private float vetikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    public float maxKaannosAsteet = 60;
    public float minKaannosAsteet = -80;

    private Vector3 liikesuunta = Vector3.zero;
    private CharacterController controllere;


    //string sana = "moi";
    //string on sana tai kirjaimia
    //integer on numero mikä ei mene desimaaleihin
    //float on numero mikä menee desimaaleihin



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = haluttuMoodi;
        Cursor.visible = (CursorLockMode.Locked != haluttuMoodi);


        controllere = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vetikaalinenPyorinta -= Input.GetAxis("Mouse Y") * hiirenNopeus;
        vetikaalinenPyorinta = Mathf.Clamp(vetikaalinenPyorinta, minKaannosAsteet, maxKaannosAsteet);
        Camera.main.transform.localRotation = Quaternion.Euler(vetikaalinenPyorinta, horisontaalinenPyorinta, 0);

        float nopeusEteen = Input.GetAxis("Vertical");
        float nopeusSivulle = Input.GetAxis("Horizontal");
        Vector3 nopeus = new Vector3(nopeusSivulle * juoksuNopeus, 0, nopeusEteen * juoksuNopeus);

        nopeus = transform.rotation * nopeus;

        controllere.SimpleMove(nopeus);

        liikesuunta.y -= painovoima * Time.deltaTime;
        controllere.Move(liikesuunta * Time.deltaTime);

        if (controllere.isGrounded && Input.GetButtonDown("Jump"))
        {
            liikesuunta.y += hyppyNopeus;
        }
        // time.deltatime on ihan kuin fixed time
    }

    //Runs with the physics motor same as Update.
    void FixedUpdate()
    {


    }


}
