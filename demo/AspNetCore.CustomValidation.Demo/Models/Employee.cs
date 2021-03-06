﻿using AspNetCore.CustomValidation.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.CustomValidation.Demo.Models
{
    public class Employee : IValidatableObject
    {
        public string EmployeeId { get; set; }

        [TinyMceRequired(MinLength = 5, MaxLength = 10)]
        public string Name { get; set; }

        [MaxAge(1,0,0)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        //[MinDate(2019,1,1)] // 2019 January 1
        //[MaxDate(2019,10,1)] // 2019 October 1

        [CompareTo(nameof(DateOfBirth), ComparisonType.GreaterThan)]
        public DateTime? JoiningDate { get; set; }

        [Display(Name = "First Number")]
        public int FirstNumber { get; set; }

        [CompareTo(nameof(FirstNumber),ComparisonType.GreaterThanOrEqual)]
        public int? SecondNumber { get; set; }

        [File(new []{FileType.DocX, FileType.Xlsx})]
        public IFormFile Photo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            //FileOptions fileOptions = new FileOptions()
            //{
            //    FileTypes = new FileType[] {FileType.Jpeg,FileType.Jpg},
            //    MinSize = 124,
            //    MaxSize = Convert.ToInt32(AppSettings.GetValue("DemoSettings:MaxFileSize"))
            //};

            //ValidationResult fileValidationResult = validationContext.ValidateFile(nameof(Photo), fileOptions);
            //validationResults.Add(fileValidationResult);

            //ValidationResult minAgeValidationResult = validationContext.ValidateMinAge(nameof(DateOfBirth), 10, 0, 0);
            //validationResults.Add(minAgeValidationResult);
           
            return validationResults;
        }
    }
}
