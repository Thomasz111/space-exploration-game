using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSpawner : MonoBehaviour {

    public List<GameObject> Collectibles = new List<GameObject>();
    public int NumStartingOfCollectibles = 50;
    public int NumStartingOfAroundCollectibles = 50;
    public int SpawnAreaSize = 10;

    public void SpawnCollectiblesAroundObjects(Universe universe)
    { 
        List<GameObject>  universeObjects = universe.GetUniverseObjects();
        for (int collectibleNum = 0; collectibleNum < NumStartingOfAroundCollectibles; collectibleNum++)
        {
            int randomElementIndex = Random.Range(0, Collectibles.Count);
            GameObject collectible = GameObject.Instantiate(Collectibles[randomElementIndex]);

            randomElementIndex = Random.Range(0, universeObjects.Count);
            CellCoordPosition randomObjectPosition = universeObjects[randomElementIndex].GetComponent<CellCoordPosition>();

            CellCoordPosition cellCoordPosition = (CellCoordPosition) collectible.AddComponent(typeof(CellCoordPosition));
            cellCoordPosition.SetCellSize(universe.GetCellSize());

            cellCoordPosition.SetLocalPosition(randomObjectPosition.GetLocalPos().x + Random.Range(0, universe.GetCellSize()),
                randomObjectPosition.GetLocalPos().y + Random.Range(0, universe.GetCellSize()),
                randomObjectPosition.GetLocalPos().z + Random.Range(0, universe.GetCellSize()));
            cellCoordPosition.SetGlobalPosition((long)randomObjectPosition.GetGlobalPos().x + Random.Range(-1, 1),
                (long)randomObjectPosition.GetGlobalPos().y + Random.Range(-1, 1), 
                (long)randomObjectPosition.GetGlobalPos().z + Random.Range(-1, 1));

            collectible.transform.position = cellCoordPosition.GetRealPosition();

            universe.AddUniverseObject(collectible);
        }
    }

    public void SpawnStartingCollectibles(Universe universe)
    {
        for(int collectibleNum = 0; collectibleNum < NumStartingOfCollectibles; collectibleNum++)
        {
            int randomElementIndex = Random.Range(0, Collectibles.Count);
            GameObject collectible = GameObject.Instantiate(Collectibles[randomElementIndex]);

            CellCoordPosition cellCoordPosition = (CellCoordPosition) collectible.AddComponent(typeof(CellCoordPosition));
            cellCoordPosition.SetCellSize(universe.GetCellSize());
            cellCoordPosition.SetLocalPosition(Random.Range(0, universe.GetCellSize()), Random.Range(0, universe.GetCellSize()), Random.Range(0, universe.GetCellSize()));
            cellCoordPosition.SetGlobalPosition(Random.Range(-SpawnAreaSize, SpawnAreaSize), Random.Range(-SpawnAreaSize, SpawnAreaSize), Random.Range(-SpawnAreaSize, SpawnAreaSize));
            collectible.transform.position = cellCoordPosition.GetRealPosition();

            universe.AddUniverseObject(collectible);
        }
    }
}
