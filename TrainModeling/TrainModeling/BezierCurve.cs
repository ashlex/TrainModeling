using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace TrainModeling
{
	public class BezierCurve
	{
		public readonly static Matrix<double> MB3 = DenseMatrix.OfArray(new double[,]
		{
			{-1, 3,-3, 1},
			{ 3,-6, 3, 0},
			{-3, 3, 0, 0},
			{ 1, 0, 0, 0}
		});

		public readonly static Matrix<double> MB2 = DenseMatrix.OfArray(new double[,]
		{
			{ 1,-2, 1},
			{-2, 2, 0},
			{ 1, 0, 0}
		});

		public readonly static Matrix<double> MB1 = DenseMatrix.OfArray(new double[,]
		{
			{-1, 1},
			{ 1, 0}
		});

		public static double BernstainsBazis(int n, int i, double t)
		{
			double b = MathNet.Numerics.Fn.Factorial(n) / (Fn.Factorial(i) * Fn.Factorial(n - i));
			return b * Math.Pow(t, i) * Math.Pow(1 - t, n - i);
		}

		public static Vector<double> GetPoint(Matrix<double>_points,double distance )
		{
			switch (_points.ColumnCount)
			{
				case 4:
					return GetPoint3(_points, distance);
				case 3:
					return GetPoint2(_points, distance);
				case 2:
					return GetPoint1(_points, distance);
				default:
					return GetPointGeneral(_points, distance);
			}
		} 


		public static Vector<double> GetPointGeneral(Matrix<double>_points,double distance )
		{
			int i = 0;
			Vector<double> v = DenseVector.Create(_points.ColumnCount, 0);
			foreach (Vector<double> enumerateRow in _points.EnumerateRows())
			{
				Vector<double> tmp = enumerateRow.Multiply(BernstainsBazis(_points.RowCount - 1, i++, distance));
				v = v.Add(tmp);
			}
			return v;
		}
		public static Vector<double> GetPoint1(Matrix<double>_points,double distance )
		{
			Matrix<double> v = DenseMatrix.OfArray(new double[,]
			{
				{distance,1}
			});
			Console.Write(v);
			Console.Write(MB1);
			Console.Write(_points);
			v = v.Multiply(MB1);
			Console.Write(v);
			v = v.Multiply(_points);
			Console.Write(v);
			return v.Row(0);
		} 
		public static Vector<double> GetPoint2(Matrix<double>_points,double distance )
		{
			Matrix<double> v = DenseMatrix.OfArray(new double[,]
			{ 
				{Math.Pow(distance,2),distance,1}
			});
			v = v.Multiply(MB2).Multiply(_points);
			return v.Row(0);
		} 
		public static Vector<double> GetPoint3(Matrix<double>_points,double distance )
		{
			Matrix<double> v = DenseMatrix.OfArray(new double[,]
			{
				{ Math.Pow(distance, 3), Math.Pow(distance, 2), distance, 1 }
			});
			v = v.Multiply(MB3).Multiply(_points);
			return v.Row(0);
		} 
	}
}