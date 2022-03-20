using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourToggle : MonoBehaviour
{
    private Color[] colors;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[] { Color.green, Color.red, Color.blue, Color.yellow, Color.black, Color.clear, Color.cyan, Color.magenta, Color.grey };
    }

    public void ToggleColour()
    {
        MeshRenderer[] renderers = this.GetComponentsInChildren<MeshRenderer>();
        foreach (Renderer renderer in renderers)
        {
            foreach (Material m in renderer.materials)
            {
                m.color = colors[i];
                i++;
                if (i >= colors.Length) i = 0;
            }
        }
    }
}




