using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalendarAppFinal.Models.ViewModel
{
    public class EventoViewModel
    {
        public Evento Evento { get; set; }
        public List<SelectListItem> Etiqueta = new List<SelectListItem>();
        public string EtiquetaNome { get; set; }
        //public string UserId { get; set; }

        public EventoViewModel(Evento meuEvento, List<Etiqueta> etiquetas) //string userId
        {
            Evento = meuEvento;
            EtiquetaNome = meuEvento.Etiqueta.Nome;
        //    UserId = userId;
            foreach (var etq in etiquetas)
                Etiqueta.Add(new SelectListItem() { Text = etq.Nome });
        }

        public EventoViewModel(List<Etiqueta> etiquetas) //, string userId
        {
        //    UserId = userId;
            foreach (var etq in etiquetas)
                Etiqueta.Add(new SelectListItem() { Text = etq.Nome });
        }

        public EventoViewModel()
        {
        }
    }
}
