using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreMVC5._0.Enums
{
    public enum LanguageEnum
    {
        [Display(Name ="English Language")]
        English=5,
        [Display(Name ="Turkish Language")]
        Turkish=6,
        [Display(Name ="German Language")]
        German=7,
        [Display(Name ="French Language")]
        French=8,
        [Display(Name ="Spanish Language")]
        Spanish=9
    }
}
