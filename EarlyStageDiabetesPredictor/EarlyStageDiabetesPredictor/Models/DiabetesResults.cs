using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EarlyStageDiabetesPredictor.Models
{
    public class DiabetesResults
    {
        private static DiabetesResults instance;
        public List<Person> Results;
        private DiabetesResults()
        {
            this.Results = new List<Person>();
        }
        public static DiabetesResults getDiabetesResultsInstance() 
        { 
            if(instance == null) 
            {
                instance = new DiabetesResults();
            }
            return instance; 
        }

    }
}