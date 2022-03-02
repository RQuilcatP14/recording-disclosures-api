using RecordingDisclosures.Domain;
using System.Collections.Generic;

namespace RecordingDisclosures.Interfaces
{
    public interface IQuery
    {
        List<CarrierItem> ListCarriers();
        List<PlanItem> ListPlans();
    }
}
