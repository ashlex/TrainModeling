using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace TrainModeling.Tests
{
	[TestClass()]
	public class BezierCurveTests
	{
		[TestMethod()]
		public void BernstainsBazisTest()
		{
		}

		[TestMethod()]
		public void GetPointTest()
		{
			Matrix<double> m = DenseMatrix.OfArray(new double[,] {{0, 0}, {5, 10}, {10, 0}});
			Console.WriteLine(m);
            var a=BezierCurve.GetPoint(m, 0.25);
			Console.WriteLine(a);
			a =BezierCurve.GetPoint(m, 0.5);
			Console.WriteLine(a);
			a =BezierCurve.GetPoint(m, 0.875);
			Console.WriteLine(a);
		}

		[TestMethod()]
		public void GetPointGeneralTest()
		{
		}

		[TestMethod()]
		public void GetPoint1Test()
		{
		}

		[TestMethod()]
		public void GetPointDef2Test()
		{
			Matrix<double> m = DenseMatrix.OfArray(new double[,] { { 0, 0 }, { 5, 10 }, { 10, 0 } });
			Console.WriteLine(m);
			var a = BezierCurve.GetPointDef2(m, 0);
			Console.WriteLine(a);
			a = BezierCurve.GetPointDef2(m, 0.5);
			Console.WriteLine(a);
			a = BezierCurve.GetPointDef2(m, 0.875);
			Console.WriteLine(a);
		}

		[TestMethod()]
		public void GetPoint3Test()
		{
		}
	}
}