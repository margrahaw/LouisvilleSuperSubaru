using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using LouisvilleSuperSubaru.Models.Tables;
using System.ComponentModel.DataAnnotations;

namespace LouisvilleSuperSubaru.UI.Models
{
    public class VehicleAddViewModel
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> ConditionName { get; set; }
        public IEnumerable<SelectListItem> VehicleType { get; set; }
        public IEnumerable<SelectListItem> TransmissionType { get; set; }
        public IEnumerable<SelectListItem> CarColorName { get; set; }
        public IEnumerable<SelectListItem> InteriorColorName { get; set; }
        public Vehicle Vehicle { get; set; }
        public int MakeId { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Vehicle.Year))
            {
                errors.Add(new ValidationResult("Vehicle Year is required."));
            }
            if (Vehicle.SalesPrice <= 0)
            {
                errors.Add(new ValidationResult("Sales value is required."));
            }
            if (Vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP is required."));
            }
            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName).ToLower();

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be .jpg .png .gif or .jpeg"));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Image is required."));
            }
            return errors;
        }

    }
}