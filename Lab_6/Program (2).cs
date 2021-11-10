using System;

using Psim.Particles;
using Psim.ModelComponents;
using Psim.Materials;

namespace Psim
{
	class Program
	{
		static void Main(string[] args)
		{
			DispersionData dData;
			dData.LaData = new double[] { -2.22e-7, 9260.0, 0.0 };
			dData.TaData = new double[] { -2.28e-7, 5240.0, 0.0 };
			dData.WMaxLa = 7.63916048e13;
			dData.WMaxTa = 3.0100793072e13;

			RelaxationData rData;
			rData.Bl = 1.3e-24;
			rData.Btn = 9e-13;
			rData.Btu = 1.9e-18;
			rData.BI = 1.2e-45;
			rData.W = 2.42e13;

			Material silicon = new Material(in dData, in rData);
			
			Model model = new Model(silicon, 300, 100, 5);

			int numCells = 5;
			for (int i = 0; i < numCells; ++i)
			{
				
				model.AddSensor(i, 200);
				model.AddCell(10, 5, i);

			}
		
			model.SetSurfaces(200);
			model.SetEmitPhonons(200, 5, 5e-9);

			Console.WriteLine(model);

		}
	}
}