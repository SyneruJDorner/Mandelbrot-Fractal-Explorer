using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explorer : MonoBehaviour
{
    public Material mat;
    public Vector2 pos;
    public float scale;
    public float angle;

    private void UpdateShader()
    {
        float aspect = (float)Screen.width / (float)Screen.height;
        float scaleY = (aspect > 1f) ? scale / aspect : scale;
        float scaleX = (aspect <= 1f) ? scale * aspect : scale;

        mat.SetVector("_Area", new Vector4(pos.x, pos.y, scaleX, scaleY));
        mat.SetFloat("_Angle", angle);
    }

    private void HandleInputs()
    {
        //Scale
        if (Input.GetKey(KeyCode.C))
            scale += 0.01f * scale;
        if (Input.GetKey(KeyCode.Space))
            scale -= 0.01f * scale;

        //Rotation
        if (Input.GetKey(KeyCode.Q))
            angle += 0.01f;
        if (Input.GetKey(KeyCode.E))
            angle -= 0.01f;

        //Position
        Vector2 dir = new Vector2(0.01f * scale, 0);
        float s = Mathf.Sin(angle);
        float c = Mathf.Cos(angle);
        dir = new Vector2(dir.x * c, dir.x * s);

        if (Input.GetKey(KeyCode.A))
            pos -= dir;
        if (Input.GetKey(KeyCode.D))
            pos += dir;

        dir = new Vector2(-dir.y, dir.x);
        if (Input.GetKey(KeyCode.W))
            pos += dir;
        if (Input.GetKey(KeyCode.S))
            pos -= dir;
    }

    void FixedUpdate()
    {
        HandleInputs();
        UpdateShader();
    }
}
