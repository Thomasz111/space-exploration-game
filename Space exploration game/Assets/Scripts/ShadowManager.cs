using UnityEngine;
using System.Collections;

public class ShadowManager : MonoBehaviour {

	public GameObject[] planet = new GameObject[10];

	public void Init(int length)
	{
		int		i = -1;
		if (length > 10 || length <= 0) // Our shadowing system can only compute the shadow of 10 object for each object
			return;
		while (++i < length)  // looping trough our solar system
		{
			if (planet[i].GetComponent<Planet>())
			{
				int		x = -1;
				int		x2 = -1;
				planet[i].GetComponent<Planet>().setShadowNumber(length - 1); // first we need to set the number of object we want ( - 1 because we wont give own coordinates)
				while (++x < length) // giving each planet the coordinates of all the other planet
				{
					if (x != i) // we don't pass own shadow to the object
					{
						x2++;
						planet[i].GetComponent<Planet>().setShadow(planet[x].transform, x2);
					}
				}
			}
		}
	}
}
