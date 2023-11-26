namespace CalendarAppFinal.Helpers
{
    public static class JSONListHelper
    {
        public static string GetEventListJSONString(List<Models.Evento> eventos)
        {
            var listaEventos = new List<Event>();
            foreach (var model in eventos)
            {
                var meuEvento = new Event()
                {
                    id = model.Id,
                    title = model.Nome,
                    start = model.StartTime,
                    end = model.EndTime,
                    resourceId = model.Etiqueta.Id,
                    description = model.Descricao,
                };
                listaEventos.Add(meuEvento);
            }
            return System.Text.Json.JsonSerializer.Serialize(listaEventos);
        }

        public static string GetResourceListJSONString(List<Models.Etiqueta> etiquetas)
        {
            var resourceList = new List<Resource>();

            foreach (var etq in etiquetas)
            {
                var resource = new Resource()
                {
                    id = etq.Id,
                    title = etq.Nome
                };
                resourceList.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourceList);
        }
    }

    #region [ModelosParaOFullCalendar]
    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int resourceId { get; set; }
        public string description { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
    }
    #endregion
}