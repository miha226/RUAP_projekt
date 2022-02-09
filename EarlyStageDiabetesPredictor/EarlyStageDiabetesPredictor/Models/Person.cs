using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EarlyStageDiabetesPredictor.Models
{
    public class Person
    {
        [Display(Name ="Age")]
        [Range(1,120, ErrorMessage ="You need to enter a valid age")]
        [Required(ErrorMessage ="You need to enter age")]
        public int age { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "You need to enter your gender")]
        public string gender { get; set; }
        
        public string Polyuria { get; set; }
        public string Polydipsia { get; set; }
        [Display(Name ="Sudden weight loss")]
        [Required(ErrorMessage ="This information is required")]
        public string suddenWeightLoss { get; set; }
        [Display (Name ="Weakness")]
        [Required(ErrorMessage = "This information is required")]
        public string weakness { get; set; }
        public string Polyphagia { get; set; }
        [Display(Name = "Genital Thrush")]
        public string genitalThrush { get; set; }
        [Display(Name = "Visual blurring")]
        [Required(ErrorMessage = "This information is required")]
        public string visualBlurring { get; set; }
        [Display(Name = "Itching")]
        [Required(ErrorMessage = "This information is required")]
        public string itching { get; set; }
        [Display(Name = "Irritability")]
        [Required(ErrorMessage = "This information is required")]
        public string irritability { get; set; }
        [Display(Name = "Delayed healing")]
        [Required(ErrorMessage = "This information is required")]
        public string delayedHealing { get; set; }
        [Display(Name ="Partial paresis")]
        public string partialParesis { get; set; }
        [Display (Name ="Muscle stiffness")]
        public string muscleStiffness { get; set; }
        [Display(Name ="Alopecia")]
        public string alopecia { get; set; }
        [Display(Name = "Obesity")]
        [Required(ErrorMessage = "This information is required")]
        public string obesity { get; set; }
        public string outcome { get; set; }
        public string percentage { get; set; }
    }
}