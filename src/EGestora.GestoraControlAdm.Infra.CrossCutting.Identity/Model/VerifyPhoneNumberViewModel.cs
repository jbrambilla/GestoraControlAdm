﻿using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Infra.CrossCutting.Identity.Model
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
