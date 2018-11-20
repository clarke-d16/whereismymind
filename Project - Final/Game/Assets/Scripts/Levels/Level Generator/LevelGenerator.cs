using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D levelMaps;

    public Colour2Prefabs[] colourMappings;

    // Use this for initialization
    void Start() {

        GenerateLevels();
    }

    void GenerateLevels()
    {
        for (int x = 0; x < levelMaps.width; x++)

        {
            for (int y = 0; y < levelMaps.height; y++)
            {
                GenerateTiles(x, y);
            }
        }
    }

    void GenerateTiles(int x, int y)
    {
        Color pixelColour = levelMaps.GetPixel(x, y);

        if (pixelColour.a == 0)
        {
            //pixel is transparent. Ignore it
            return;
        }

        foreach (Colour2Prefabs colourMapping in colourMappings)
        {
            if (colourMapping.colour.Equals(pixelColour))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colourMapping.prefabs, position, Quaternion.identity, transform);
            }
        }

    }
}
