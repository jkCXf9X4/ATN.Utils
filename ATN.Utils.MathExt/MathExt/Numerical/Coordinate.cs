/*
 * Created by SharpDevelop.
 * User: erxzr5
 * Date: 2018-04-11
 * Time: 13:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Spatial.Units;

namespace ATN.Utils.MathExt.Numerical
{

	[Serializable]
	public class Coordinate
	{
		public Vector<double> coordinate = Vector<double>.Build.Dense(3);
		//X,Y,Z
		
		public double X {
			get {
				return coordinate[0];
			}
			set {
				coordinate[0] = value;
			}
		}
		public double Y {
			get {
				return coordinate[1];
			}
			set {
				coordinate[1] = value;
			}
		}
		public double Z {
			get {
				return coordinate[2];
			}
			set {
				coordinate[2] = value;
			}
		}
		
		public Coordinate()
		{
		}
		
		public Coordinate(double X, double Y, double Z)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}
		
		public Coordinate(double[] array)
		{
			this.X = array[0];
			this.Y = array[1];
			this.Z = array[2];
		}
		
		public Coordinate(Vector<double> pos)
		{
			coordinate = pos;
		}
		
		public double[] ToArray()
		{
			return coordinate.ToArray();
		}
		
		public List<double> ToList()
		{
			return this.ToArray().ToList();
		}
		
		public Coordinate GetInverse()
		{
			return new Coordinate(-this.X,-this.Y, -this.Z);
		}
		
		public void Reset()
		{
			this.X = 0;
			this.Y = 0;
			this.Z = 0;
		}
		
		
		
		public static Coordinate operator + (Coordinate a, Coordinate b)
		{
			var c = a.coordinate + b.coordinate;
			return new Coordinate(c);
		}
		
		public static Coordinate operator - (Coordinate a, Coordinate b)
		{
			return new Coordinate(a.coordinate-b.coordinate);
		}
		
	}
}
