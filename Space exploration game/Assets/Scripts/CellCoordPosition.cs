using UnityEngine;

public class CellCoordPosition : MonoBehaviour {
    public static readonly double CellSize = 500.0;

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

    public static double Distance(CellCoordPosition a, CellCoordPosition b){
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return System.Math.Sqrt(x * x + y * y + z * z);
    }

    public static double Distance(ref CellCoordPosition a, ref CellCoordPosition b){
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return System.Math.Sqrt(x * x + y * y + z * z);
    }

    public static double SqrDistance(CellCoordPosition a, CellCoordPosition b){
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return x * x + y * y + z * z;
    }

    public static double SqrDistance(ref CellCoordPosition a, ref CellCoordPosition b){
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;

        return x * x + y * y + z * z;
    }

    public static CellCoordPosition Delta(ref CellCoordPosition a, ref CellCoordPosition b){
        var o = default(CellCoordPosition);

        o.LocalX = a.LocalX - b.LocalX;
        o.LocalY = a.LocalY - b.LocalY;
        o.LocalZ = a.LocalZ - b.LocalZ;
        o.GlobalX = a.GlobalX - b.GlobalX;
        o.GlobalY = a.GlobalY - b.GlobalY;
        o.GlobalZ = a.GlobalZ - b.GlobalZ;

        return o;
    }

    public static bool Equal(ref CellCoordPosition a, ref CellCoordPosition b){
        if (a.GlobalX == b.GlobalX && a.GlobalY == b.GlobalY && a.GlobalZ == b.GlobalZ)
        {
            if (a.LocalX == b.LocalX && a.LocalY == b.LocalY && a.LocalZ == b.LocalZ)
            {
                return true;
            }
        }

        return false;
    }

    public static Vector3 Direction(ref CellCoordPosition a, ref CellCoordPosition b){
        var x = b.LocalX - a.LocalX + (b.GlobalX - a.GlobalX) * CellSize;
        var y = b.LocalY - a.LocalY + (b.GlobalY - a.GlobalY) * CellSize;
        var z = b.LocalZ - a.LocalZ + (b.GlobalZ - a.GlobalZ) * CellSize;
        var m = System.Math.Sqrt(x * x + y * y + z * z);

        if (m > 0.0)
        {
            x /= m;
            y /= m;
            z /= m;
        }

        return new Vector3((float)x, (float)y, (float)z);
    }

    public static CellCoordPosition Lerp(CellCoordPosition a, CellCoordPosition b, double t){
        var o = a;

        o.LocalX += ((b.GlobalX - a.GlobalX) * CellSize + b.LocalX - a.LocalX) * t;
        o.LocalY += ((b.GlobalY - a.GlobalY) * CellSize + b.LocalY - a.LocalY) * t;
        o.LocalZ += ((b.GlobalZ - a.GlobalZ) * CellSize + b.LocalZ - a.LocalZ) * t;

        o.SnapLocal();

        return o;
    }

    public static Vector3 Vector(CellCoordPosition a, CellCoordPosition b){
        var ax = a.LocalX + a.GlobalX * CellSize;
        var ay = a.LocalY + a.GlobalY * CellSize;
        var az = a.LocalZ + a.GlobalZ * CellSize;
        var bx = b.LocalX + b.GlobalX * CellSize;
        var by = b.LocalY + b.GlobalY * CellSize;
        var bz = b.LocalZ + b.GlobalZ * CellSize;

        var x = bx - ax;
        var y = by - ay;
        var z = bz - az;

        return new Vector3((float)x, (float)y, (float)z);
    }

    public bool SnapLocal(){
        var updatePosition = false;
        var shiftX         = CalculateShift(LocalX, CellSize);
        var shiftY         = CalculateShift(LocalY, CellSize);
        var shiftZ         = CalculateShift(LocalZ, CellSize);

        if (shiftX != 0)
        {
            GlobalX += shiftX;
            LocalX  -= shiftX * CellSize;

            updatePosition = true;
        }

        if (shiftY != 0)
        {
            GlobalY += shiftY;
            LocalY  -= shiftY * CellSize;

            updatePosition = true;
        }

        if (shiftZ != 0)
        {
            GlobalZ += shiftZ;
            LocalZ  -= shiftZ * CellSize;

            updatePosition = true;
        }

        return updatePosition;
    }

    public static CellCoordPosition operator + (CellCoordPosition a, CellCoordPosition b){
        a.GlobalX += b.GlobalX;
        a.GlobalY += b.GlobalY;
        a.GlobalZ += b.GlobalZ;

        a.LocalX += b.LocalX;
        a.LocalY += b.LocalY;
        a.LocalZ += b.LocalZ;

        a.SnapLocal();

        return a;
    }

    public override string ToString(){
        return "(" + LocalX + ", " + LocalY + ", " + LocalZ + " - " + GlobalX + ", " + GlobalY + ", " + GlobalZ + ")";
    }

    private long CalculateShift(double coordinate, double cellSize){
        var shift = coordinate / cellSize;

        return (long)shift;
    }
}