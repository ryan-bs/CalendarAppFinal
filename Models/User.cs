using Microsoft.AspNetCore.Identity;

namespace CalendarAppFinal.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
