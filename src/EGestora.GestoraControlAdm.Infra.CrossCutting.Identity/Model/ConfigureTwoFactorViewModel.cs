﻿using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Infra.CrossCutting.Identity.Model
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}
