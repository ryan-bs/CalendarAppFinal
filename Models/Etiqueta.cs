namespace CalendarAppFinal.Models
{
    public class Etiqueta
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        #region [Chave Estrangeira]
        public virtual ICollection<Evento> Eventos { get; set; }
        #endregion

        public Etiqueta()
        {
        }
    }
}
