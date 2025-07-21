using AutoMapper;
using ISpan.eMiniHR.DataAccess.Models;
namespace ISpan.eMiniHR.DataAccess.Helpers
{
    public static class MapperHelper
    {

        /*
             全域共用 Mapper 實例
            var entity = MapperHelper.Mapper.Map<EmployeeEntity>(dto);     // DTO → Entity
            var dto = MapperHelper.Mapper.Map<EmployeeDto>(entity);         // Entity → DTO
            MapperHelper.Mapper.Map(dto, existingEntity);                   // 更新資料用

         */
        public static readonly IMapper Mapper;

        static MapperHelper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // 員工基本資料
                cfg.CreateMap<EmployeeDto, EmployeeEntity>()
                   .ForMember(dest => dest.EmpId, opt => opt.Ignore()) // EmpId 由 IdGenerator 自動產生
                   .ForMember(dest => dest.MgrId, opt => opt.MapFrom(src =>
                       src.MgrId.NullIfEmpty()));
                cfg.CreateMap<EmployeeEntity, EmployeeDto>();

                // 系統使用者
                cfg.CreateMap<UsersDto, UsersEntity>();
                cfg.CreateMap<UsersEntity, UsersDto>();

                // 部門
                //cfg.CreateMap<DeptDto, DeptEntity>();
                //cfg.CreateMap<DeptEntity, DeptDto>();

                //// 職等
                //cfg.CreateMap<JobGradeDto, JobGradeEntity>();
                //cfg.CreateMap<JobGradeEntity, JobGradeDto>();

                //// 請假
                //cfg.CreateMap<LeaveRequestDto, LeaveRequestEntity>();
                //cfg.CreateMap<LeaveRequestEntity, LeaveRequestDto>();

                // 更多...自己依需要加
            });

            Mapper = config.CreateMapper();
        }
    }
}
