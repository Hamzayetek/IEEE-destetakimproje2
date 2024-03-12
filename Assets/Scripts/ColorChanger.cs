using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text timetext;

    public Material[] surfaceMaterials;
    public float changeInterval = 15f;
    private float timer = 0f;
    private Color[] selectedColors;
    private Color[] availableColors = { Color.blue, Color.yellow, Color.red, Color.green }; // Kullan�labilir renkler

    void Start()
    {
        SelectRandomColors();
        ApplyColorsToSurfaces();
        float inttext = Mathf.Floor(timer);
    }

    void Update()
    {
        timer += Time.deltaTime;
        float inttext = Mathf.Floor(timer);
        timetext.SetText("Zaman :" + inttext);

        if (timer >= changeInterval)
        {
            SelectRandomColors();
            ApplyColorsToSurfaces();
            timer = 0f;
        }
    }

    void SelectRandomColors()
    {
        selectedColors = new Color[surfaceMaterials.Length];

        // Her y�zeye farkl� bir renk atamak i�in kullan�lmam�� renklerin bir listesini olu�tur
        List<Color> availableColorsList = new List<Color>(availableColors);

        for (int i = 0; i < surfaceMaterials.Length; i++)
        {
            // Kullan�lmam�� renklerin i�inden rastgele bir renk se�
            int randomIndex = Random.Range(0, availableColorsList.Count);
            selectedColors[i] = availableColorsList[randomIndex];
            // Se�ilen renk, art�k kullan�lmam�� oldu�undan listeden kald�r
            availableColorsList.RemoveAt(randomIndex);
        }
    }

    void ApplyColorsToSurfaces()
    {
        for (int i = 0; i < surfaceMaterials.Length; i++)
        {
            surfaceMaterials[i].color = selectedColors[i];
        }
    }
}
