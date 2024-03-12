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
    private Color[] availableColors = { Color.blue, Color.yellow, Color.red, Color.green }; // Kullanýlabilir renkler

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

        // Her yüzeye farklý bir renk atamak için kullanýlmamýþ renklerin bir listesini oluþtur
        List<Color> availableColorsList = new List<Color>(availableColors);

        for (int i = 0; i < surfaceMaterials.Length; i++)
        {
            // Kullanýlmamýþ renklerin içinden rastgele bir renk seç
            int randomIndex = Random.Range(0, availableColorsList.Count);
            selectedColors[i] = availableColorsList[randomIndex];
            // Seçilen renk, artýk kullanýlmamýþ olduðundan listeden kaldýr
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
