using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetManager
{
    public class GridDataSet
    {
        public GridDataSet(double delta, XYBoundary xYBoundary)
        {
            Delta = delta;
            XYBoundary = xYBoundary;
            NX = (int)(XYBoundary.DX / delta) + 1;
            NY = (int)(XYBoundary.DY / delta) + 1;
            GridData = new List<XYZ>[NX][];
            for (int i = 0; i < NX; i++)
            {
                GridData[i] = new List<XYZ>[NY];
                for (int j = 0; j < NY; j++)
                {
                    GridData[i][j] = new List<XYZ>();
                }
            }
        }

        public GridDataSet( XYBoundary xYBoundary, double delta, List<XYZ> data) : this(delta, xYBoundary)
        {
            foreach (XYZ point in data) AddXYZ(point);
        }

        public double Delta { get; private set; }
        public XYBoundary XYBoundary { get; private set; }
        public int NX { get; set; }
        public int NY { get; set; }
        public List<XYZ>[][] GridData { get; private set; }
       
        public void AddXYZ(XYZ point)
        {
            if ((point.X < XYBoundary.MinX) || (point.Y < XYBoundary.MinY) || (point.X > XYBoundary.MaxX) || (point.Y > XYBoundary.MaxY))
            {
                throw new DataSetManagerException("Out of bounds");
            }
            int i = (int)((point.X - XYBoundary.MinX) / Delta);
            int j = (int)((point.Y - XYBoundary.MinY) / Delta);
            if (i == NX) i--;
            if (j == NY) j--;
            GridData[i][j].Add(point);
        }

    }
}
