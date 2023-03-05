using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public enum DutyStatus
    {
        [Display(Name = "Nierozpoczęty")]
        Nierozpoczęty = 0,
        [Display(Name = "W trakcie realizacji")]
        WTrakcieRealizacji = 1,
        [Display(Name = "Ukończony")]
        Ukończony = 2,
        [Display(Name = "Po terminie")]
        PoTerminie = 3,
        [Display(Name = "Anulowany")]
        Anulowany = 4

    }
}
