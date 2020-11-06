using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public class Frame
    {
        public uint ID { get; }
        public string Name { get; }

        public EFeatureFlags Features 
        {
            get;
            private set;
        }

        public Frame(uint id, string name)
        {
            ID = id;
            Name = name;
            Features = EFeatureFlags.Default;
        }

        public void ToggleFeatures(EFeatureFlags features)
        {
            this.Features = this.Features ^ features;
        }

        public void TurnOffFeatures(EFeatureFlags features)
        {
            this.Features = this.Features & ~features;
        }

        public void TurnOnFeatures(EFeatureFlags features)
        {
            this.Features = this.Features | features;
        }
    }
}
