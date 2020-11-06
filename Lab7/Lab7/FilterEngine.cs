using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public static class FilterEngine
    {

        public static List<Frame> FilterFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> filteredFrames = new List<Frame>();

            foreach (Frame frame in frames)
            {
                EFeatureFlags filteredFlag = frame.Features & features;
                if ((int)filteredFlag != 0)
                {
                    filteredFrames.Add(frame);
                }
            }

            return filteredFrames;
        }

        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> filteredFrames = new List<Frame>();

            foreach (Frame frame in frames)
            {
                EFeatureFlags filteredFlag = frame.Features & features;
                if ((int)filteredFlag == 0)
                {
                    filteredFrames.Add(frame);
                }
            }

            return filteredFrames;
        }

        public static List<Frame> Intersect(List<Frame> frames, List<Frame> frames2)
        {
            List<Frame> intersectFrame = new List<Frame>();

            foreach (Frame frame1 in frames)
            {
                foreach (Frame frame2 in frames2)
                {
                    if (frame1.ID == frame2.ID && frame1.Name == frame2.Name && frame1.Features == frame2.Features)
                    {
                        intersectFrame.Add(frame1);
                    }
                }
            }

            return intersectFrame;
        }

        public static List<int> GetSortKeys(List<Frame> frames, List<EFeatureFlags> features)
        {
            List<int> sortKeys = new List<int>();
            for (int i = 0; i < frames.Count; i++)
            {
                Frame frame = frames[i];
                int sortKey = 0;
                for (int j = 0; j < features.Count; j++)
                {
                    EFeatureFlags featureFlags = features[j];
                    
                    if ((int)(frame.Features & featureFlags) != 0)
                    {
                        int bit = 0;
                        bit |= (1 << features.Count - j - 1);
                        sortKey |= bit;
                    }
                }
                sortKeys.Add(sortKey);
            }

            return sortKeys;
        }
    }
}
