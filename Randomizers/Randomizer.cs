using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bartz24.Docs;

namespace FF13Randomizer
{
    public class Randomizer
    {
        protected FormMain main;
        protected RandomizerManager randomizers;

        public Randomizer(FormMain formMain, RandomizerManager randomizers)
        {
            this.main = formMain;
            this.randomizers = randomizers;
        }

        public virtual void Load()
        {

        }

        public virtual void Randomize(BackgroundWorker backgroundWorker)
        {

        }

        public virtual void Save()
        {

        }

        public virtual HTMLPage GetDocumentation()
        {
            return null;
        }

        public virtual string GetProgressMessage()
        {
            return "Progressing...";
        }
        public virtual string GetID()
        {
            return "NONE";
        }
    }
}
