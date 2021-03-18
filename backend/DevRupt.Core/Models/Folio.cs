using System.Collections;
using System.Collections.Generic;

namespace DevRupt.Core.Models
{
    public class Folio
    {
        public string Id { get; set; }
        public List<Charge> Charges { get; set; }
        public bool IsMainFolio { get; set; }
        public List<RelatedFolio> RelatedFolios { get; set; }
        
        public string ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }

    public class RelatedFolio
    {
        public string Id { get; set; }
    }
}