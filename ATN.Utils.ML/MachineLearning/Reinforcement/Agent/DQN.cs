
using ATN.Utils.MachineLearning.Reinforcement.ReplayQue;

using System;

using System.Linq;

using ATN.Utils.MachineLearning.Reinforcement.Model;
using ATN.Utils.ObjectExt;
using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using ATN.Utils.CollectionsExt.ArrayExt;

namespace ATN.Utils.MachineLearning.Reinforcement.Agent
{
    public class DQN : Agent
    {
        double discountRate;
        int verbose;

        public DQN(
            ITargetChaserModels model, 
            IReplay replay, 
            bool training,
            double discountRate = 0.5, double epsilon= 0.05, int verbose = 0) : base(model, replay, epsilon, training)
        {
            this.discountRate = discountRate;
            this.verbose = verbose;
        }

        public override double Replay(int batchSize, int epochs)
        {
            Console.WriteLine("Replay");
            var memoryAnalyzer = new MemoryAnalyzer(replayQue.GetList());

            var states = memoryAnalyzer.GetStates();
            var actions = memoryAnalyzer.GetActions();
            var rewards = memoryAnalyzer.GetRewards();
            var resultingStates = memoryAnalyzer.GetResultingStates();

            var actionTargets = model.As<ITargetChaserModels>().PredictTarget(states).ToList();
            var nextActionTargets = model.As<ITargetChaserModels>().PredictTarget(resultingStates).ToList();

            for( int i = 0;i < replayQue.Count;i++)
            {
                var Q_next = nextActionTargets[i].actionRaw[0].Max();

                var action = actions[i].Action;

                actionTargets[i].actionRaw[0][action] = rewards[i] + this.discountRate * Q_next;
            }

            var loss =  model.Fit(states, actionTargets, batchSize, epochs);

            return loss;
        }
    }
}
