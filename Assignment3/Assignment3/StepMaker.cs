using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            List<int> result = new List<int>();

            List<int> recursiveResult;

            int lastEle = steps[^1];

            for (int i = 0; i < steps.Length - 1; i++)
            {
                int pre = steps[i];
                int post = steps[i + 1];
                recursiveResult = makeStepsRecursive(pre, post, noise, 0);

                for (int j = 0; j < recursiveResult.Count - 1; j++)
                {
                    result.Add(recursiveResult[j]);
                }
            }

            result.Add(lastEle);

            return result;
        }

        private static List<int> makeStepsRecursive(int preStep, int postStep, INoise noise, int recursiveLevel)
        {
            List<int> newSteps = new List<int>();
            List<int> result = new List<int>();

            int diffTotal = postStep - preStep;
            int absDiffTotal = Math.Abs(diffTotal);

            double diffUnit;

            if (absDiffTotal > 10)
            {
                newSteps.Add(preStep);

                diffUnit = (double)diffTotal / 5;
                
                for (int i = 0; i < 4; i++)
                {
                    int noiseValue = noise.GetNext(recursiveLevel);

                    double addedStep = (double)preStep + (double)(postStep - preStep) * ((double)(i + 1) / 5);
                    //double toAdded = (((double)(i + 1) * diffUnit) + (double)noiseValue);
                    newSteps.Add((int)addedStep + noiseValue);
                }

                newSteps.Add(postStep);

                int lastEle = newSteps[^1];
                for (int i = 0; i < newSteps.Count - 1; i++)
                {
                    int pre = newSteps[i];
                    int post = newSteps[i + 1];

                    List<int> recursiveResult = makeStepsRecursive(pre, post, noise, recursiveLevel + 1);

                    for (int j = 0; j < recursiveResult.Count - 1; j++)
                    {
                        result.Add(recursiveResult[j]);
                    }                    
                }
                result.Add(lastEle);

                return result;
            }
            else
            {
                newSteps.Add(preStep);
                newSteps.Add(postStep);
                return newSteps;
            }
        }
    }
}