using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DipTestingExercises;

namespace DipTestingExercises.Tests.Mocks
{
    public class FakeMotorVehicle : MotorVehicle
    {
        public FakeMotorVehicle(IPerson pDriver, int pMax, int pCurrent, int pLitres) : base(pDriver, pMax, pCurrent, pLitres)
        { }
    }
}
