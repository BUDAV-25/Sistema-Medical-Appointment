namespace MedicalAppointment.Consumption.Client
{
    public interface Interfaces<TModelAll, TModelBy, TSaveDto, TUpdateDto>
    {
        Task<TModelAll> GetAll();
        Task<TModelBy> GetById(int id);
        Task<TSaveDto> Save(TSaveDto saveDto);
        Task<TUpdateDto> Update(TUpdateDto updateDto);
    }
}
