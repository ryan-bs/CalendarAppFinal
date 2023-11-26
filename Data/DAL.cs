using CalendarAppFinal.Interfaces;
using CalendarAppFinal.Models;

namespace CalendarAppFinal.Data
{
    public class DAL : IDAL
    {
        private ApplicationDbContext _context;

        public DAL()
        {
            _context = new ApplicationDbContext();
        }

        #region [EVENTO]

        #region [Create]
        public void CreateEvento(IFormCollection form)
        {
            var nomeEtiqueta = form["Etiqueta"].ToString();
            var user = _context.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var novoEvento = new Evento(form, _context.Etiquetas.FirstOrDefault(x => x.Nome == nomeEtiqueta), user);

            _context.Eventos.Add(novoEvento);
            _context.SaveChanges();
        }
        #endregion

        #region [Update]
        public void UpdateEvento(IFormCollection form)
        {
            var nomeEtiqueta = form["Etiqueta"].ToString();
            var eventoId = int.Parse(form["Evento.Id"]);
            var meuEvento = _context.Eventos.FirstOrDefault(x => x.Id == eventoId);
            var etiqueta = _context.Etiquetas.FirstOrDefault(x => x.Nome == nomeEtiqueta);
            var user = _context.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            meuEvento.UpdateEvento(form, etiqueta, user);

            _context.Entry(meuEvento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        #endregion

        #region [Delete]
        public void DeleteEvento(int id)
        {
            var evento = _context.Eventos.Find(id);
            _context.Eventos.Remove(evento);
            _context.SaveChanges();
        }
        #endregion

        #region [Read]
        public Evento GetEvento(int id)
        {
            return _context.Eventos.FirstOrDefault(x => x.Id == id);
        }

        public List<Evento> GetEventos()
        {
            return _context.Eventos.ToList();
        }

        public List<Evento> GetMeusEventos(string userId)
        {
            var meusEventos = _context.Eventos.ToList();
            return meusEventos;
        }
        #endregion

        #endregion

        #region [ETIQUETA]

        #region [Create]
        public void CreateEtiqueta(Etiqueta etiqueta)
        {
            _context.Etiquetas.Add(etiqueta);
            _context.SaveChanges();
        }
        #endregion

        #region [Read]
        public Etiqueta GetEtiqueta(int id)
        {
            return _context.Etiquetas.Find(id);
        }

        public List<Etiqueta> GetEtiquetas()
        {
            return _context.Etiquetas.ToList();
        }
        #endregion

        #endregion
    }
}
