namespace CalendarAppFinal.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        #region [ChaveEstrangeira]
        public virtual User User { get; set; }
        public virtual Etiqueta Etiqueta { get; set; }
        #endregion

        public Evento()
        {
        }
    }
}
