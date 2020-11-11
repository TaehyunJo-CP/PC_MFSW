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
            for (int i = 0; i < steps.Length - 1; i++)
            {
                int pre = steps[i];
                int post = steps[i + 1];
                recursiveResult = MakeStepsRecursive(pre, post, noise, 0);

                if (i == 0)
                {
                    for (int j = 0; j < recursiveResult.Count; j++)
                    {
                        result.Add(recursiveResult[j]);
                    }
                }
                else
                {
                    for (int j = 1; j < recursiveResult.Count; j++)
                    {
                        result.Add(recursiveResult[j]);
                    }

                    if (i == steps.Length - 2)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        private static List<int> MakeStepsRecursive(int preStep, int postStep, INoise noise, int recursiveLevel)
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
                    double toAdded = (((double)(i + 1) * diffUnit) + (double)noiseValue);
                    newSteps.Add((int)(preStep + toAdded));
                }
                newSteps.Add(postStep);

                for (int i = 0; i < newSteps.Count - 1; i++)
                {
                    int pre = newSteps[i];
                    int post = newSteps[i + 1];

                    List<int> recursiveResult = MakeStepsRecursive(pre, post, noise, recursiveLevel + 1);

                    if (i == newSteps.Count - 2)
                    {
                        for (int j = 0; j < recursiveResult.Count; j++)
                        {
                            result.Add(recursiveResult[j]);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < recursiveResult.Count - 1; j++)
                        {
                            result.Add(recursiveResult[j]);
                        }
                    }
                }
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