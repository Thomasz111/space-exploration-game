using UnityEngine;

public class CellCoordPosition : MonoBehaviour {
    public static double CellSize = 100.0;

    public double LocalX;
    public double LocalY;
    public double LocalZ;

    public long GlobalX;
    public long GlobalY;
    public long GlobalZ;

    public void SetLocalPosition(double LocalX, double LocalY, double LocalZ)
    {
        this.LocalX = LocalX;
        this.LocalY = LocalY;
        this.LocalZ = LocalZ;
    }

    public void SetGlobalPosition(long GlobalX, long GlobalY, long GlobalZ)
    {
        this.GlobalX = GlobalX;
        this.GlobalY = GlobalY;
        this.GlobalZ = GlobalZ;
    }

    public Vector3 GetLocalPos()
    {
        return new Vector3((float)LocalX, (float)LocalY, (float)LocalZ);
    }

    public Vector3 GetGlobalPos()
    {
        return new Vector3(GlobalX, GlobalX, GlobalX);
    }

    public bool OutOfCell() {
        return LocalX >= CellSize || LocalY >= CellSize || LocalZ >= CellSize ||
            LocalX < 0 || LocalY < 0 || LocalZ < 0;
    }

    public void UpdateGlobalPos()
    {
        if (LocalX >= CellSize)
        {
            GlobalX += (int)(LocalX / CellSize);
        }
        if (LocalY >= CellSize)
        {
            GlobalY += (int)(LocalY / CellSize);
        }
        if (LocalZ >= CellSize)
        {
            GlobalZ += (int)(LocalZ / CellSize);
        }
        if (LocalX < 0)
        {
            GlobalX -= (int)(LocalX / CellSize) + 1;
        }
        if (LocalY < 0)
        {
            GlobalY -= (int)(LocalY / CellSize) + 1;
        }
        if (LocalZ < 0)
        {
            GlobalZ -= (int)(LocalZ / CellSize) + 1;
        }
    }

    public void SnapCoordsBackToCell() {
        if (LocalX >= CellSize)
        {
            LocalX -= (int)(LocalX / CellSize) * CellSize;
        }
        if (LocalY >= CellSize)
        {
            LocalY -= (int)(LocalY / CellSize) * CellSize;
        }
        if (LocalZ >= CellSize)
        {
            LocalZ -= (int)(LocalZ / CellSize) * CellSize;
        }
        if (LocalX < 0)
        {
            LocalX += (Mathf.Abs((int)(LocalX / CellSize))+1) * CellSize;
        }
        if (LocalY < 0)
        {
            LocalY += (Mathf.Abs((int)(LocalY / CellSize)) + 1) * CellSize;
        }
        if (LocalZ < 0)
        {
            LocalZ += (Mathf.Abs((int)(LocalZ / CellSize)) + 1) * CellSize;
        }
    }

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