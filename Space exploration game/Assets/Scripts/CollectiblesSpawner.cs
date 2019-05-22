using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSpawner : MonoBehaviour {

    public List<GameObject> Collectibles = new List<GameObject>();
    public int NumOfCollectibles = 10;
    public int SpawnAreaSize = 5;

    private Universe universe;

    void Start () {
        universe = (Universe) gameObject.GetComponent(typeof(Universe));
        SpawnStartingCollectibles();
	}

    private void SpawnStartingCollectibles()
    {
        for(int collectibleNum = 0; collectibleNum < NumOfCollectibles; collectibleNum++)
        {
            int randomElementIndex = Random.Range(0, Collectibles.Count);
            GameObject collectible = GameObject.Instantiate(Collectibles[randomElementIndex]);

            CellCoordPosition cellCoordPosition = (CellCoordPosition) collectible.AddComponent(typeof(CellCoordPosition));
            cellCoordPosition.SetCellSize(universe.GetCellSize());
            cellCoordPosition.SetLocalPosition(Random.Range(0, universe.GetCellSize()), Random.Range(0, universe.GetCellSize()), Random.Range(0, universe.GetCellSize()));
            cellCoordPosition.SetGlobalPosition(Random.Range(0, SpawnAreaSize), Random.Range(0, SpawnAreaSize), Random.Range(0, SpawnAreaSize));
            collectible.transform.position = cellCoordPosition.GetRealPosition();

            universe.AddUniverseObject(collectible);
        }
    }
}
