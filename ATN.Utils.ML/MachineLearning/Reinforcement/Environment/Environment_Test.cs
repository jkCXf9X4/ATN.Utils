using Xunit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Environment
{

    public class Environment_Test
    {
        class Environment_Stub : Environment<int, int>
        {
            public Environment_Stub(IEnumerable<int> states) : base(states)
            {

            }

            public override int ActionCount { get { return 2; } }

            protected override double StepAction(int action)
            {
                return this.index*0.1;
            }
        }

        [Fact]
        public void Test1()
        {
            var states = new int[] { 1, 2, 5, 3, 7, 5 };

            var env = new Environment_Stub(states);

            while(!env.IsDone)
            {
                var state = env.State;

                var reward = env.Step(1);

                var resultingState = env.State;

                Debug.WriteLine($"{state}, {reward}, {resultingState}, {env.IsDone}");
            }
        }

    }
}
