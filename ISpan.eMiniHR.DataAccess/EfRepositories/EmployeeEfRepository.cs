using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Helpers;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using static ISpan.eMiniHR.DataAccess.Helpers.IdGenerator;

namespace ISpan.eMiniHR.DataAccess.EfRepositories
{
    public class EmployeeEfRepository
    {
        public static int Add(EmployeeDto emp)
        {
            try
            {
                using var db = new EFDbContext();

                var generatorParam = new IdGeneratorParams
                {
                    tableName = "Employee",
                    columnName = "EmpId",
                    //prefix = DateTime.Now.ToString("yyMM"), // 例：2507
                    SerialLength = 6 // 流水號最大位數
                };

                string newId = GetNextId(generatorParam); // 取得編號

                var item = MapperHelper.Mapper.Map<EmployeeEntity>(emp);

                item.EmpId = newId;

                db.Employees.Add(item);

                return db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public static int Update(EmployeeDto emp)
        {
            try
            {
                using var db = new EFDbContext();
                var empId = emp.EmpId?.Trim();
                if (string.IsNullOrEmpty(empId))
                {
                    throw new Exception("員工編號不可為空");
                }

                var item = db.Employees.Find(empId);
                if (item == null) {
                    throw new Exception("找不到資料!");
                }

                // 將 emp 的值更新到 entity，保留 EmpId
                MapperHelper.Mapper.Map(emp, item);

                return db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public static int Delete(string empId)
        {
            try
            {
                using var db = new EFDbContext();
                var emp = db.Employees.Find(empId);
                if (emp != null)
                {
                    db.Employees.Remove(emp);
                    return db.SaveChanges();
                }
                return 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
