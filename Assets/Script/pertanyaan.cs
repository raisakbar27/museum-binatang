using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pertanyaan : MonoBehaviour
{
    public GameObject canvas; // Tarik Panel UI ke sini melalui Inspector

    void OnMouseDown()
    {
        // Menampilkan canvasPanel ketika objek diklik
        canvas.SetActive(true);
    }
}
