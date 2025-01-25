using UnityEngine;
using UnityEngine.U2D; // Necesario para usar SpriteShape

public class SoftbodyShapeController : MonoBehaviour
{
    public SpriteShapeController spriteShapeController; // Referencia al SpriteShapeController
    public Transform[] nodes; // Nodos externos (bolas laterales)

    private Spline spline;

    void Start()
    {
        spriteShapeController = GetComponent<SpriteShapeController>();
        // Obtén la referencia al spline
        spline = spriteShapeController.spline;

        // Asegúrate de que el número de nodos coincida con los puntos del spline
        if (nodes.Length != spline.GetPointCount())
        {
            Debug.LogError("El número de nodos no coincide con los puntos del spline.");
        }
    }

    void Update()
    {
        // Actualiza las posiciones de los puntos del spline basándote en los nodos
        for (int i = 0; i < nodes.Length; i++)
        {
            // Obtén la posición del nodo en el espacio local del objeto principal
            Vector3 localNodePosition = transform.InverseTransformPoint(nodes[i].position);

            // Actualiza la posición del punto del spline
            spline.SetPosition(i, localNodePosition);
        }

        // (Opcional) Ajusta los ángulos de los manejadores de curvatura si quieres suavidad adicional
        for (int i = 0; i < spline.GetPointCount(); i++)
        {
            spline.SetTangentMode(i, ShapeTangentMode.Continuous);
        }
    }
}
