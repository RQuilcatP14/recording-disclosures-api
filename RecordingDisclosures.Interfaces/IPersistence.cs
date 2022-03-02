using RecordingDisclosures.Domain;

namespace RecordingDisclosures.Interfaces
{
    public interface IPersistence
    {
        bool InsertCarrierPlan(CarrierPlanItem request);
    }
}
