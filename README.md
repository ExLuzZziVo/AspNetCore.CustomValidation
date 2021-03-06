# AspNetCore.CustomValidation

 This is a common custom model validation library for ASP.NET Core projects.
 
## Whats new in Version 1.4.0?

   1. `GreaterThanOrEqual` and `SmallerThanOrEqual` ComparisonType  to CompareToAttribute along with its client side validation.
   2. ComparisonType `Equality` and `NotEquality` have renamed to `Equal` and `NotEqual` respectively.
   3. This release also include some imporant bug fixes.
 
## How do I get started?
 
 Configuring **TanvirArjel.CustomValidation** into your ASP.NET Core project is as simple as below:
 
 1. First install the lastest version of `AspNetCore.CustomValidation` [nuget package](https://www.nuget.org/packages/AspNetCore.CustomValidation) into your project as follows:
 
    `Install-Package AspNetCore.CustomValidation`
    
 2. Then decorate your class properties with appropriate Custom validation attributes as follows:
 
        public class Employee
        {
            public string EmployeeId { get; set; }

            public string Name { get; set; }

            [MaxAge(30,10,0)] // 30 Year 10 Months 0 Days
            [MinAge(10,10,0)] // 10 Year 10 Months 0 Days
            public DateTime DateOfBirth { get; set; }

            [MinDate(2019,1,1)] // 2019 January 1
            [MaxDate(2019,10,1)] // 2019 October 1
            public DateTime JoiningDate { get; set; }
            public int FirstNumber { get; set; }

            [CompareTo(nameof(FirstNumber),ComparisonType.GreaterThan)]
            public int SecondNumber { get; set; }

            [File(new FileType[]{FileType.Jpg, FileType.Jpeg}, MaxSize = 1024)]
            public IFormFile Photo { get; set; }
        }
        
  ## Client Side validation:
  
  To enable client client side validation, please add the latest version of `aspnetcore-custom-validation.min.js` file as follows:
  
    @section Scripts {
      @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
      <script type="text/javascript" src="~/lib/aspnetcore-custom-validation/aspnetcore-custom-validation.min.js"</script>
    }
    
    Or
    
    <script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>
    <script type="text/javascript" src="~/lib/aspnetcore-custom-validation/aspnetcore-custom-validation.min.js"</script>
    
You can download the `aspnetcore-custom-validation.min.js` from here [aspnetcore-custom-validation-npm](https://www.npmjs.com/package/aspnetcore-custom-validation)

Or using Visusl Studio **Libman** as follows:

    1 ) wwwroot > lib> Add > Client Side Libray

    2. Provider: jsdelivr
       Libray: aspnetcore-custom-validation
    3. Click install
  
        
  ## What contains in Version 1.4.0?
  
  In version 1.4.0 `AspNetCore.CustomValidation` contains the following validation attributes:
  
  **1. FileAttribute**
       To validate file type, file max size, file min size
       
  **2. MaxAgeAttribute**
       To validate maximum age against date of birth value of `DateTime` type
       
  **3. MinAgeAttribute**
       To validate minimum required age against a date of birth value of `DateTime` type.
       
  **4. MaxDateAttribute**
       To set max value validation for a `DateTime` field.
       
  **5. MinDateAttribute**
       To set min value validation for a `DateTime` field.
       
  **6. TinyMceRequiredAttribute**
       To enforce required valiaton attribute on the online text editors like TinyMCE, CkEditor etc.
       
  **7. CompareToAttribute**
       To compare one property value against another property value of the same object.
       
   # Dynamic Validation
   In version 1.4.0, validation against dynamic values from database, configuration file or any external source added for the following type:
    **1. File Type:** with `ValidateFile()` method
    **1. DateTime Type:** with `ValidateMaxAge()` and `ValidateMinAge()` method as follows:
    
    public class Employee : IValidatableObject
    {
        public DateTime? DateOfBirth { get; set; }
        public IFormFile Photo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            FileOptions fileOptions = new FileOptions()
            {
                FileTypes = new FileType[] {FileType.Jpeg,FileType.Jpg},
                MinSize = 124,
                MaxSize = Convert.ToInt32(AppSettings.GetValue("DemoSettings:MaxFileSize"))
            };

            ValidationResult minAgeValidationResult = validationContext.ValidateMinAge(nameof(DateOfBirth), 10, 0, 0);
            validationResults.Add(minAgeValidationResult);
            
            ValidationResult fileValidationResult = validationContext.ValidateFile(nameof(Photo), fileOptions);
            validationResults.Add(fileValidationResult);
            return validationResults;
        }
    }
    
       
   # Note
   
   Dont forget to request your desired validation  attribute by submitting an issue.
  
  
