using UnityEngine;

public class Saltoburbuja : MonoBehaviour
{
    [Header("MOVIMIENTO")]

    private SpriteRenderer p1;
    private Rigidbody2D r2d;
    private float posZ;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float incGiro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 50);
        r2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Salto();
        }

    }

    void FixedUpdate()
    {
        Girar();
    }

    //MOVIMIENTO JUGADOR
    private void Salto()
    {
        //r2d.velocity = Vector2.SmoothDamp(r2d.velocity, velocidadObjetivo, ref v, suavizado);   //suavizador de movimiento

        Vector2 direccion = transform.up;

        r2d.AddForce(direccion * fuerzaSalto, ForceMode2D.Impulse);
        //r2d.AddForce(new Vector2(posZ, fuerzaSalto));
    }

    //GIRO JUGADOR
    private void Girar()
    {
        posZ = posZ + incGiro;
        if (posZ >= 360) { posZ = posZ - 360; }
        r2d.transform.rotation = Quaternion.Euler(Vector3.forward * -posZ);
    }
}
