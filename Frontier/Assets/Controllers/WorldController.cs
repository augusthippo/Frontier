using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
    World world;

    public Sprite floorSprite;

	// Use this for initialization
	void Start ()
    {
        //Create a world with empty tiles
        world = new World();
        
        //Create a GameObject for each of our tiles, so they show visually
        for (int x = 0; x < world.Height; x++)
        {
            for (int y = 0; y < world.Height; y++)
            {
                GameObject tile_gameObject = new GameObject();
                Tile tile_data = world.GetTileAt(x, y);
                tile_gameObject.name = ("Tile_" + x + "_" + y);
                tile_gameObject.transform.position = new Vector3(tile_data.X, tile_data.Y, 0.0f);

                //Add a sprite renderer but dont bother to set a sprite since all tiles are empty right now
                tile_gameObject.AddComponent<SpriteRenderer>();
            }
        }

        world.RandomizeTiles();
	}

    void OnTileTypeChanged(Tile tile_data, GameObject tile_gameObject)
    {
        if (tile_data.Type == Tile.TileType.Floor)
        {
            tile_gameObject.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (tile_data.Type == Tile.TileType.Empty)
        {
            tile_gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.LogError("OnTileTypeChanged: unrecognized tile type");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
