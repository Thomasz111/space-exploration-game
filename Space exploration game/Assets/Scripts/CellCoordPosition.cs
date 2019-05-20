using UnityEngine;

public class CellCoordPosition : MonoBehaviour {
    public static double CellSize = 500.0;

    public double LocalX;
    public double LocalY;
    public double LocalZ;

    public long GlobalX;
    public long GlobalY;
    public long GlobalZ;

    public CellCoordPosition(Vector3 localXYZ, double scale = 1){
        LocalX = localXYZ.x * scale;
        LocalY = localXYZ.y * scale;
        LocalZ = localXYZ.z * scale;

        GlobalX = GlobalY = GlobalZ = 0;

        SnapLocal();
    }

    public bool SnapLocal()
    {
        var updatePosition = false;
        var shiftX = CalculateShift(LocalX, CellSize);
        var shiftY = CalculateShift(LocalY, CellSize);
        var shiftZ = CalculateShift(LocalZ, CellSize);

        if (shiftX != 0)
        {
            GlobalX += shiftX;
            LocalX -= shiftX * CellSize;

            updatePosition = true;
        }

        if (shiftY != 0)
        {
            GlobalY += shiftY;
            LocalY -= shiftY * CellSize;

            updatePosition = true;
        }

        if (shiftZ != 0)
        {
            GlobalZ += shiftZ;
            LocalZ -= shiftZ * CellSize;

            updatePosition = true;
        }

        return updatePosition;
    }

    public override string ToString(){
        return "(" + LocalX + ", " + LocalY + ", " + LocalZ + " - " + GlobalX + ", " + GlobalY + ", " + GlobalZ + ")";
    }

    private long CalculateShift(double coordinate, double cellSize){
        var shift = coordinate / cellSize;

        return (long)shift;
    }

    public static CellCoordPosition operator +(CellCoordPosition a, CellCoordPosition b)
    {
        a.GlobalX += b.GlobalX;
        a.GlobalY += b.GlobalY;
        a.GlobalZ += b.GlobalZ;

        a.LocalX += b.LocalX;
        a.LocalY += b.LocalY;
        a.LocalZ += b.LocalZ;

        a.SnapLocal();

        return a;
    }
}