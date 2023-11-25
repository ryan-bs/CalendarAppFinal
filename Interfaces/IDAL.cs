using CalendarAppFinal.Models;

namespace CalendarAppFinal.Interfaces
{
    public interface IDAL
    {
        #region [METODOS PARA EVENTO]
        public void CreateEvento(IFormCollection form);
        public void UpdateEvento(IFormCollection form);
        public void DeleteEvento(int id);
        public Evento GetEvento(int id);
        public List<Evento> GetEventos();
        public List<Evento> GetMeusEventos(string userid);
        #endregion

        #region [METODOS PARA ETIQUETA]
        public List<Etiqueta> GetEtiquetas();
        public Etiqueta GetEtiqueta(int id);
        public void CreateEtiqueta(Etiqueta etiqueta);
        #endregion
    }
}
