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
        SpawnCollectiblesAroundObjects();
	}

    private void SpawnCollectiblesAroundObjects()
    {
        //TODO fix so it works after all instantiations
        List<GameObject>  universeObjects = universe.GetUniverseObjects();
        for(int collectibleNum = 0; collectibleNum < NumOfCollectibles; collectibleNum++)
        {
            int randomElementIndex = Random.Range(0, Collectibles.Count);
            GameObject collectible = GameObject.Instantiate(Collectibles[randomElementIndex]);

            randomElementIndex = Random.Range(0, universeObjects.Count);
            CellCoordPosition randomObjectPosition = universeObjects[randomElementIndex].GetComponent<CellCoordPosition>();

            CellCoordPosition cellCoordPosition = (CellCoordPosition) collectible.AddComponent(typeof(CellCoordPosition));
            cellCoordPosition.SetCellSize(universe.GetCellSize());

            cellCoordPosition.SetLocalPosition(Random.Range(0, universe.GetCellSize()), 
                Random.Range(0, universe.GetCellSize()),
                Random.Range(0, universe.GetCellSize()));
            cellCoordPosition.SetGlobalPosition((long)randomObjectPosition.GetGlobalPos().x + Random.Range(-1, 1),
                (long)randomObjectPosition.GetGlobalPos().y + Random.Range(-1, 1), 
                (long)randomObjectPosition.GetGlobalPos().z + Random.Range(-1, 1));

            collectible.transform.position = cellCoordPosition.GetRealPosition();

            universe.AddUniverseObject(collectible);
        }
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
