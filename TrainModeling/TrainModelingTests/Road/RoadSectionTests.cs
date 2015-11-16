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
	public class RoadSectionTests
	{
		[TestMethod()]
		public void RoadSectionTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void RoadSectionTest1()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetPointBeginTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetCoordinateTest()
		{
			Matrix<double> points=DenseMatrix.OfArray(new double[,] { {0,0}, {10,0} });
			IRoadSection rs=new RoadSection(points);
			Assert.IsTrue(new Coordinate2D(new DenseVector(new double[] {5,0})).Equals(rs.GetCoordinate(0.5)));
			Assert.AreEqual(new Coordinate2D(new DenseVector(new double[] {1,0})),(rs.GetCoordinate(0.1)));
			Assert.IsTrue(new Coordinate2D(new DenseVector(new double[] {2,0})).Equals(rs.GetCoordinate(0.2)));
			Assert.IsTrue(new Coordinate2D(new DenseVector(new double[] {3, 0})).Equals(rs.GetCoordinate(0.3)));


			points = DenseMatrix.OfArray(new double[,] { { 0, 0 }, { 10, 10 } });
			rs = new RoadSection(points);
			Assert.IsTrue(new Coordinate2D(new DenseVector(new double[] { 1, 1 })).Equals(rs.GetCoordinate(0.1)));
			Assert.IsTrue(new Coordinate2D(new DenseVector(new double[] { 2, 2 })).Equals(rs.GetCoordinate(0.2)));
			Assert.IsTrue(new Coordinate2D(new DenseVector(new double[] { 3, 3 })).Equals(rs.GetCoordinate(0.3)));
		}

		[TestMethod()]
		public void ChangeStateTest()
		{
			Assert.Fail();
		}
	}
}